using System;
using System.Windows.Forms;

namespace FolderSyncTestApp
{
    public partial class MainForm : Form
    {
        private bool serviceStarted = false;
        private EventSourcer eventSourcer;
        private Propagator propagator;

        public MainForm()
        {
            InitializeComponent();
            OnButtonStateChanged();
        }

        private void LogLine(String text)
        {
            //TextBoxLogs.AppendText(text + Environment.NewLine);
        }

        protected void OnButtonStateChanged()
        {
            ButtonStart.Enabled = serviceStarted == false && !String.IsNullOrEmpty(TextBoxSourceFolder.Text) && !String.IsNullOrEmpty(TextBoxTargetFolder.Text);
            ButtonStop.Enabled = serviceStarted == true;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (serviceStarted)
            {
                ButtonStop_Click(this, new EventArgs());
            }

            Close();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (TextBoxSourceFolder.Text.Equals(""))
            {
                MessageBox.Show("No source folder to monitor!");
                return;
            }

            if (TextBoxTargetFolder.Text.Equals(""))
            {
                MessageBox.Show("No target folder to replicate to!");
                return;
            }

            propagator = new Propagator(new LocalFolderReplica(TextBoxTargetFolder.Text));
            eventSourcer = new EventSourcer(TextBoxSourceFolder.Text);
            eventSourcer.EventNotifier += new EventSourcerObserver(EventNotifier);

            LogLine("Start service - Monitoring " + TextBoxSourceFolder.Text);
            serviceStarted = true;
            OnButtonStateChanged();

            eventSourcer.Start();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            eventSourcer.Stop();

            LogLine("Stop service");
            serviceStarted = false;
            OnButtonStateChanged();

            if (propagator != null) 
            {
                LogLine("Total events [Propagator]: " + propagator.EventCount);
            }
        }

        private void ButtonBrowseSource_Click(object sender, EventArgs e)
        {
            FolderBrowser.ShowNewFolderButton = false;
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                TextBoxSourceFolder.Text = FolderBrowser.SelectedPath;
            }
            OnButtonStateChanged();
        }

        private void ButtonBrowseTarget_Click(object sender, EventArgs e)
        {
            FolderBrowser.ShowNewFolderButton = true;
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                TextBoxTargetFolder.Text = FolderBrowser.SelectedPath;
            }
            OnButtonStateChanged();
        }

        private void EventNotifier(ItemNotification item)
        {
            LogLine("Event: " + item.ItemType.ToString() + " " + item.Name + " (" + item.FullPath + ")");
            propagator.Accept(item);
        }
    }
}

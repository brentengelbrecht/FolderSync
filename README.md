# FolderSync

<!--- These are examples. See https://shields.io for others or to customize this set of shields. You might want to include dependencies, project status and licence info here --->
![GitHub repo size](https://img.shields.io/github/repo-size/Zooloo2014/FolderSync)
![GitHub contributors](https://img.shields.io/github/contributors/Zooloo2014/FolderSync)
![GitHub stars](https://img.shields.io/github/stars/Zooloo2014/FolderSync?style=social)
![GitHub forks](https://img.shields.io/github/forks/Zooloo2014/FolderSync?style=social)
![Twitter Follow](https://img.shields.io/twitter/follow/brent_zooloo?style=social)

FolderSync is a `Windows service` that maintains a replica of a file system directory tree in a different file system location

## Prerequisites

Before you begin, ensure you have met the following requirements:
<!--- These are just example requirements. Add, duplicate or remove as required --->
* You have installed the latest version of `Visual Studio 2017`
* You have a `Windows` machine

## Installing or removing FolderSync (Windows only)

To install:
```
InstallUtil <path/to/>FolderSync.exe
```

To uninstall:
```
InstallUtil /u <path/to/>FolderSync.exe
```

## Using FolderSync

### Create a configuration for folder to be monitored

Use regedit to create a subkey under HKEY_LOCAL_MACHINE\SOFTWARE\Zooloo\FolderSync
Add string items for SourcePath (folder to be monitored) and TargetPath (location to hold the replica)

### Start the service

Open the Services applet
Find the service named `Folder Synchronisation Service`
Start the service

## Open an issue

For feature requests or bug fixes

## Contributing to FolderSync
<!--- If your README is long or you have some specific process or steps you want contributors to follow, consider creating a separate CONTRIBUTING.md file--->

To contribute to FolderSync, follow these steps:

1. Fork this repository.
2. Create a branch: `git checkout -b <branch_name>`.
3. Make your changes and commit them: `git commit -m '<commit_message>'`
4. Push to the original branch: `git push origin <project_name>/<location>`
5. Create the pull request.

Alternatively see the GitHub documentation on [creating a pull request](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request).

## License
<!--- If you're not sure which open license to use see https://choosealicense.com/--->

This project uses the following license: [GNU General Public License v3.0](https://www.gnu.org/licenses/gpl-3.0.en.html).

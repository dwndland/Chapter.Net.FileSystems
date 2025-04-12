![Chapter](https://raw.githubusercontent.com/dwndland/Chapter.Net.FileSystems/master/Icon.png)


# Chapter.Net.FileSystems Library

## Overview
Chapter.Net.FileSystems brings wrappers and extensions to work with the local file system.

## Features
- **IDirectory:** Gives access to all static Directory.* methods.
- **IFile:** Gives access to all static File.* methods.
- **IPath:** Gives access to all static Path.* methods.
- **IFileSystem:** Gives simple access to the IDirectory, IFile and IPath.
- **Directory Extension:** Provides extensions to the Directory accessible directly or by using the IDirectory.

## Getting Started

1. **Installation:**
    - Install the Chapter.Net.FileSystems library via NuGet Package Manager:
    ```bash
    dotnet add package Chapter.Net.FileSystems
    ```

2. **IDirectory:**
    - Usage
    ```csharp
    public class ViewModel : ObservableObject
    {
        private readonly IDirectory _directory;

        public ViewModel(IDirectory directory)
        {
            _directory = directory;
        }

        public string GetLogFolder()
        {
            var directory = @".\Logs";
            if (!_directory.Exists(directory))
                _directory.CreateDirectory(directory);
            return directory;
        }
    }

    [TestFixture]
    public class ViewModelTests
    {
        private Mock<IDirectory> _directory;
        privaze ViewModel _target;

        [SetUp]
        public void Setup()
        {
            _directory = new Mock<IDirectory>();

            _target = new ViewModel(_directory.Object);
        }

        [Test]
        public void GetLogFolder_SubFolderDoesNotExists_CreatesIt()
        {
            _directory.Setup(x => x.Exists(Args.Any<string>())).Returns(false);

            var result = _target.GetLogFolder();

            _directory.Verify(x => x.CreateDirectory(result), Times.Once);
            Assert.That(result, Is.EqualTo(@".\Logs");
        }

        [Test]
        public void GetLogFolder_SubFolderExists_DoesNotCreatIt()
        {
            _directory.Setup(x => x.Exists(Args.Any<string>())).Returns(true);

            var result = _target.GetLogFolder();

            _directory.Verify(x => x.CreateDirectory(result), Times.Never);
            Assert.That(result, Is.EqualTo(@".\Logs");
        }
    }
    ```

3. **IFile:**
    - Usage
    ```csharp
    public class ViewModel : ObservableObject
    {
        private readonly IFile _file;

        public ViewModel(IFile file)
        {
            _file = file;
        }

        public void CopyTo(string destinationPath)
        {
            var file = @".\Settings.xml";
            if (_file.Exists(file))
                _file.Copy(file, destinationPath);
        }
    }

    [TestFixture]
    public class ViewModelTests
    {
        private Mock<IFile> _file;
        privaze ViewModel _target;

        [SetUp]
        public void Setup()
        {
            _file = new Mock<IFile>();

            _target = new ViewModel(_file.Object);
        }

        [Test]
        public void CopyTo_FileExists_CopiesIt()
        {
            _file.Setup(x => x.Exists(Args.Any<string>())).Returns(true);

            var result = _target.CopyTo("Destination");

            _file.Verify(x => x.Copy(Args.Any<string>(), "Destination"), Times.Once);
        }

        [Test]
        public void CopyTo_FileDoesNotExist_DoesNotCopyIt()
        {
            _file.Setup(x => x.Exists(Args.Any<string>())).Returns(false);

            var result = _target.CopyTo("Destination");

            _file.Verify(x => x.Copy(Args.Any<string>(), "Destination"), Times.Never);
        }
    }
    ```

4. **IPath:**
    - Usage
    ```csharp
    public class ViewModel : ObservableObject
    {
        private readonly IDirectory _directory;
        private readonly IPath _path;

        public ViewModel(IDirectory directory, IPath path)
        {
            _directory = directory;
            _path = path;
        }

        public string GetRelativeTo(string path)
        {
            var currentDir = _directory.GetCurrentDirectory();
            return _path.GetRelativePath(currentDir, path);
        }
    }

    [TestFixture]
    public class ViewModelTests
    {
        private Mock<IDirectory> _directory;
        private Mock<IPath> _path;
        privaze ViewModel _target;

        [SetUp]
        public void Setup()
        {
            _directory = new Mock<IDirectory>();
            _path = new Mock<IPath>();

            _target = new ViewModel(_directory.Object, _path.Object);
        }

        [Test]
        public void GetRelativeTo_SubFolder_CreatesRelative()
        {
            _directory.Setup(x => x.GetCurrentDirectory()).Returns(@"C:\MyFolder");
            _path.Setup(x => x.GetRelativePath(@"C:\MyFolder", @"C:\SomethingElse")).Returns(@"..\SomethingElse");

            var result = _target.GetRelativeTo(@"C:\SomethingElse");

            Assert.That(result, Is.EqualTo(@"..\SomethingElse");
        }
    }
    ```

5. **IFileSystem:**
    - Usage
    ```csharp
    public class ViewModel : ObservableObject
    {
        private readonly IFileSystem _fileSystem;

        public ViewModel(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string GetRelativeTo(string path)
        {
            var currentDir = _fileSystem.Directory.GetCurrentDirectory();
            return _fileSystem.Path.GetRelativePath(currentDir, path);
        }
    }

    [TestFixture]
    public class ViewModelTests
    {
        private Mock<IFileSystem> _fileSystem;
        private Mock<IDirectory> _directory;
        private Mock<IPath> _path;
        privaze ViewModel _target;

        [SetUp]
        public void Setup()
        {
            _directory = new Mock<IDirectory>();
            _path = new Mock<IPath>();
            _fileSystem = new Mock<IFileSystem>();
            _fileSystem.Setup(x => x.File).Returns(_directory.Object);
            _fileSystem.Setup(x => x.Path).Returns(_path.Object);

            _target = new ViewModel(_fileSystem.Object);
        }

        [Test]
        public void GetRelativeTo_SubFolder_CreatesRelative()
        {
            _directory.Setup(x => x.GetCurrentDirectory()).Returns(@"C:\MyFolder");
            _path.Setup(x => x.GetRelativePath(@"C:\MyFolder", @"C:\SomethingElse")).Returns(@"..\SomethingElse");

            var result = _target.GetRelativeTo(@"C:\SomethingElse");

            Assert.That(result, Is.EqualTo(@"..\SomethingElse");
        }
    }
    ```

6. **Directory Extension:**
    - Usage
    ```csharp
    public class ViewModel : ObservableObject
    {
        public void EnsureCopied(string destination)
        {
            if (!Directory.Exists(destination))
                DirectoryEx.Copy(@"C:\MyData", destination);
        }
    }
    ```

## Links
* [NuGet](https://www.nuget.org/packages/Chapter.Net.FileSystems)
* [GitHub](https://github.com/dwndland/Chapter.Net.FileSystems)

## License
Copyright (c) David Wendland. All rights reserved.
Licensed under the MIT License. See LICENSE file in the project root for full license information.

// 
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 

// ReSharper disable once CheckNamespace

namespace Chapter.Net.FileSystems
{
    /// <inheritdoc />
    public class FileSystem : IFileSystem
    {
        /// <summary>
        ///     Creates a new instance of <see cref="FileSystem" />.
        /// </summary>
        public FileSystem()
        {
            File = new FileWrapper();
            Directory = new DirectoryWrapper();
            Path = new PathWrapper();
        }

        /// <inheritdoc />
        public IFile File { get; }

        /// <inheritdoc />
        public IDirectory Directory { get; }

        /// <inheritdoc />
        public IPath Path { get; }
    }
}
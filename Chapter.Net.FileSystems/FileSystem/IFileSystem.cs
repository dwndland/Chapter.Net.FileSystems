// 
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 

// ReSharper disable once CheckNamespace

namespace Chapter.Net.FileSystems;

/// <summary>
///     Provides access to the File, Directory or Path objects.
/// </summary>
public interface IFileSystem
{
    /// <summary>
    ///     Provides static methods for the creation, copying, deletion, moving, and opening of a single file, and aids in the
    ///     creation of FileStream objects.
    /// </summary>
    IFile File { get; }

    /// <summary>
    ///     Exposes static methods for creating, moving, and enumerating through directories and subdirectories. This class
    ///     cannot be inherited.
    /// </summary>
    IDirectory Directory { get; }

    /// <summary>
    ///     Performs operations on String instances that contain file or directory path information. These operations are
    ///     performed in a cross-platform manner.
    /// </summary>
    IPath Path { get; }
}
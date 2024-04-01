// 
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 

using System;
using System.IO;
using System.Security;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.FileSystems
{
    /// <summary>
    ///     Provides copy directories and move over system partitions.
    /// </summary>
    public static class DirectoryEx
    {
        /// <summary>
        ///     Copies the source directory and its content to a destination.
        /// </summary>
        /// <param name="sourceDirName">The source directory to copy.</param>
        /// <param name="destDirName">The destination it should copy to.</param>
        /// <exception cref="DirectoryNotFoundException">Source directory does not exist or could not be found.</exception>
        /// <exception cref="IOException">The destination directory already exists.</exception>
        /// <exception cref="IOException">An error occurs, or in the destination a file already exists.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentNullException">sourceDirName is null.</exception>
        /// <exception cref="ArgumentNullException">destDirName is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="NotSupportedException">destDirName contains a colon (:) in the middle of the string.</exception>
        public static void Copy(string sourceDirName, string destDirName)
        {
            Copy(sourceDirName, destDirName, false);
        }

        /// <summary>
        ///     Copies the source directory and its content to a destination.
        /// </summary>
        /// <param name="sourceDirName">The source directory to copy.</param>
        /// <param name="destDirName">The destination it should copy to.</param>
        /// <param name="overwrite">Indicates if files in the destination shall be overwritten.</param>
        /// <exception cref="DirectoryNotFoundException">Source directory does not exist or could not be found.</exception>
        /// <exception cref="IOException">The destination directory already exists and overwrite is false.</exception>
        /// <exception cref="IOException">An error occurs, or in the destination a file already exists and overwrite is false.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentNullException">sourceDirName is null.</exception>
        /// <exception cref="ArgumentNullException">destDirName is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="NotSupportedException">destDirName contains a colon (:) in the middle of the string.</exception>
        public static void Copy(string sourceDirName, string destDirName, bool overwrite)
        {
            if (sourceDirName == null)
                throw new ArgumentNullException(nameof(sourceDirName));
            if (destDirName == null)
                throw new ArgumentNullException(nameof(destDirName));

            var dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found");

            if (!overwrite && Directory.Exists(destDirName))
                throw new IOException("The destination directory already exists.");

            if (!Directory.Exists(destDirName))
                Directory.CreateDirectory(destDirName);

            foreach (var file in dir.GetFiles())
            {
                var tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, overwrite);
            }

            foreach (var subdir in dir.GetDirectories())
            {
                var tempPath = Path.Combine(destDirName, subdir.Name);
                Copy(subdir.FullName, tempPath, overwrite);
            }
        }

        /// <summary>
        ///     Moves the source directory and its content to a destination.
        /// </summary>
        /// <param name="sourceDirName">The source directory to move.</param>
        /// <param name="destDirName">The destination it should moved to.</param>
        /// <exception cref="DirectoryNotFoundException">Source directory does not exist or could not be found.</exception>
        /// <exception cref="IOException">The destination directory already exists.</exception>
        /// <exception cref="IOException">An error occurs, or the in the destination a file already exists.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentNullException">sourceDirName is null.</exception>
        /// <exception cref="ArgumentNullException">destDirName is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="NotSupportedException">destDirName contains a colon (:) in the middle of the string.</exception>
        public static void Move(string sourceDirName, string destDirName)
        {
            Move(sourceDirName, destDirName, false);
        }

        /// <summary>
        ///     Moves the source directory and its content to a destination.
        /// </summary>
        /// <param name="sourceDirName">The source directory to move.</param>
        /// <param name="destDirName">The destination it should move to.</param>
        /// <param name="overwrite">Indicates if files in the destination shall be overwritten.</param>
        /// <exception cref="DirectoryNotFoundException">Source directory does not exist or could not be found.</exception>
        /// <exception cref="IOException">The destination directory already exists and overwrite is false.</exception>
        /// <exception cref="IOException">An error occurs, or in the destination a file already exists and overwrite is false.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentNullException">sourceDirName is null.</exception>
        /// <exception cref="ArgumentNullException">destDirName is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="NotSupportedException">destDirName contains a colon (:) in the middle of the string.</exception>
        public static void Move(string sourceDirName, string destDirName, bool overwrite)
        {
            var srcRoot = Directory.GetDirectoryRoot(sourceDirName);
            var dstRoot = Directory.GetDirectoryRoot(destDirName);

            if (srcRoot == dstRoot)
            {
                if (overwrite && Directory.Exists(destDirName))
                    Directory.Delete(destDirName, true);
                Directory.Move(sourceDirName, destDirName);
                return;
            }

            Copy(sourceDirName, destDirName, overwrite);
            Directory.Delete(sourceDirName, true);
        }
    }
}
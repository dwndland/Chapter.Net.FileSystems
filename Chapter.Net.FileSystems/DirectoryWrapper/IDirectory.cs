// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IDirectory.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Security;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.FileSystems
{
    /// <summary>
    ///     Exposes static methods for creating, moving, and enumerating through directories and subdirectories. This class
    ///     cannot be inherited.
    /// </summary>
    public interface IDirectory
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
        void Copy(string sourceDirName, string destDirName);

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
        void Copy(string sourceDirName, string destDirName, bool overwrite);

        /// <summary>
        ///     Creates all directories and subdirectories in the specified path unless they already exist.
        /// </summary>
        /// <param name="path">The directory to create.</param>
        /// <returns>
        ///     An object that represents the directory at the specified path. This object is returned regardless of whether a
        ///     directory at the specified path already exists.
        /// </returns>
        /// <exception cref="IOException">
        ///     The directory specified by path is a file.
        ///     -or-
        ///     The network name is not known.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more invalid characters. You can query
        ///     for invalid characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     path is prefixed with, or contains, only a colon character(:).
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="NotSupportedException">path contains a colon character (:) that is not part of a drive label ("C:\").</exception>
        DirectoryInfo CreateDirectory(string path);

        /// <summary>
        ///     Deletes an empty directory from a specified path.
        /// </summary>
        /// <param name="path">The name of the empty directory to remove. This directory must be writable and empty.</param>
        /// <exception cref="IOException">
        ///     A file with the same name and location specified by path exists.
        ///     -or-
        ///     The directory is the application's current working directory.
        ///     -or-
        ///     The directory specified by path is not empty.
        ///     -or-
        ///     The directory is read-only or contains a read-only file.
        ///     -or-
        ///     The directory is being used by another process.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     path does not exist or could not be found.
        ///     -or-
        ///     The specified path is invalid(for example, it is on an unmapped drive).
        /// </exception>
        void Delete(string path);

        /// <summary>
        ///     Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
        /// </summary>
        /// <param name="path">The name of the directory to remove.</param>
        /// <param name="recursive">True to remove directories, subdirectories, and files in path; otherwise, false.</param>
        /// <exception cref="IOException">
        ///     A file with the same name and location specified by path exists.
        ///     -or-
        ///     The directory specified by path is read-only, or recursive is false and path is not an empty directory.
        ///     -or-
        ///     The directory is the application's current working directory.
        ///     -or-
        ///     The directory contains a read-only file.
        ///     -or-
        ///     The directory is being used by another process.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     path does not exist or could not be found.
        ///     -or-
        ///     The specified path is invalid(for example, it is on an unmapped drive).
        /// </exception>
        void Delete(string path, bool recursive);

        /// <summary>
        ///     Returns an enumerable collection of directory full names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the directories in the directory specified by
        ///     path.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid
        ///     characters. You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateDirectories(string path);

        /// <summary>
        ///     Returns an enumerable collection of directory full names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories in path. This parameter can
        ///     contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular
        ///     expressions.
        /// </param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the directories in the directory specified by
        ///     path and that match the specified search pattern.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid characters. You can query for invalid
        ///     characters with the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     path is null.
        ///     -or-
        ///     searchPattern is null.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern);

#if !NETSTANDARD2_0 && !NET45
        /// <summary>
        ///     Returns an enumerable collection of the directory full names that match a search pattern in a specified path, and
        ///     optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories in path. This parameter can
        ///     contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular
        ///     expressions.
        /// </param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the directories in the directory specified by
        ///     path and that match the specified search pattern and enumeration options.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid characters. You can query for invalid
        ///     characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">path or searchPattern is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">searchOption is not a valid SearchOption value.</exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions);
#endif
        /// <summary>
        ///     Returns an enumerable collection of directory full names that match a search pattern in a specified path, and
        ///     optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories in path. This parameter can
        ///     contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular
        ///     expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.
        /// </param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the directories in the directory specified by
        ///     path and that match the specified search pattern and search option.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid characters. You can query for invalid
        ///     characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     path is null.
        ///     -or-
        ///     searchPattern is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">searchOption is not a valid SearchOption value.</exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption);

        /// <summary>
        ///     The relative or absolute path to the directory to search. This string is not case-sensitive.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid
        ///     characters. You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateFiles(string path);

        /// <summary>
        ///     Returns an enumerable collection of full file names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files in path. This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.
        /// </param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the files in the directory specified by path
        ///     and that match the specified search pattern.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid characters. You can query for invalid
        ///     characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     path is null.
        ///     -or-
        ///     searchPattern is null.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateFiles(string path, string searchPattern);

#if !NETSTANDARD2_0 && !NET45
        /// <summary>
        ///     Returns an enumerable collection of full file names that match a search pattern and enumeration options in a
        ///     specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files in path. This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.
        /// </param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the files in the directory specified by path
        ///     and that match the specified search pattern and enumeration options.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid characters. You can query for invalid
        ///     characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     path is null.
        ///     -or-
        ///     searchPattern is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">searchOption is not a valid SearchOption value.</exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateFiles(string path, string searchPattern, EnumerationOptions enumerationOptions);
#endif
        /// <summary>
        ///     Returns an enumerable collection of full file names that match a search pattern in a specified path, and optionally
        ///     searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files in path. This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.
        /// </param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the files in the directory specified by path
        ///     and that match the specified search pattern and search option.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid characters. You can query for invalid
        ///     characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     path is null.
        ///     -or-
        ///     searchPattern is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">searchOption is not a valid SearchOption value.</exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);

        /// <summary>
        ///     Returns an enumerable collection of file names and directory names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path.</returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid
        ///     characters. You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateFileSystemEntries(string path);

        /// <summary>
        ///     Returns an enumerable collection of file names and directory names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of file-system entries in path. This parameter
        ///     can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular
        ///     expressions.
        /// </param>
        /// <returns>
        ///     An enumerable collection of file-system entries in the directory specified by path and that match the
        ///     specified search pattern.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid characters. You can query for invalid
        ///     characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     path is null.
        ///     -or-
        ///     searchPattern is null.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);

#if !NETSTANDARD2_0 && !NET45
        /// <summary>
        ///     Returns an enumerable collection of file names and directory names that match a search pattern and enumeration
        ///     options in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of subdirectories in path. This parameter can
        ///     contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.
        /// </param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>
        ///     An enumerable collection of file-system entries in the directory specified by path, that match the specified
        ///     search pattern and the specified enumeration options.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid characters. You can query for invalid
        ///     characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     path is null.
        ///     -or-
        ///     searchPattern is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">searchOption is not a valid SearchOption value.</exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions);
#endif
        /// <summary>
        ///     Returns an enumerable collection of file names and directory names that match a search pattern in a specified path,
        ///     and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against file-system entries in path. This parameter can contain
        ///     a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.
        /// </param>
        /// <returns>
        ///     An enumerable collection of file-system entries in the directory specified by path and that match the
        ///     specified search pattern and option.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid characters. You can query for invalid
        ///     characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     path is null.
        ///     -or-
        ///     searchPattern is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">searchOption is not a valid SearchOption value.</exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption);

        /// <summary>
        ///     Determines whether the given path refers to an existing directory on disk.
        /// </summary>
        /// <param name="path">The path to test.</param>
        /// <returns>
        ///     True if path refers to an existing directory; false if the directory does not exist or an error occurs when
        ///     trying to determine if the specified directory exists.
        /// </returns>
        bool Exists(string path);

        /// <summary>
        ///     Gets the creation date and time of a directory.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns>
        ///     A structure that is set to the creation date and time for the specified directory. This value is expressed in
        ///     local time.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        DateTime GetCreationTime(string path);

        /// <summary>
        ///     Gets the creation date and time, in Coordinated Universal Time (UTC) format, of a directory.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns>
        ///     A structure that is set to the creation date and time for the specified directory. This value is expressed in
        ///     UTC time.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        DateTime GetCreationTimeUtc(string path);

        /// <summary>
        ///     Gets the current working directory of the application.
        /// </summary>
        /// <returns>
        ///     A string that contains the absolute path of the current working directory, and does not end with a backslash
        ///     (\).
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException">
        ///     The operating system is Windows CE, which does not have current directory functionality.
        ///     This method is available in the.NET Compact Framework, but is not currently supported.
        /// </exception>
        string GetCurrentDirectory();

        /// <summary>
        ///     Returns the names of subdirectories (including their paths) in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>
        ///     An array of the full names (including paths) of subdirectories in the specified path, or an empty array if no
        ///     directories are found.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        string[] GetDirectories(string path);

        /// <summary>
        ///     Returns the names of subdirectories (including their paths) that match the specified search pattern in the
        ///     specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of subdirectories in path. This parameter can
        ///     contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.
        /// </param>
        /// <returns>
        ///     An array of the full names (including paths) of the subdirectories that match the search pattern in the
        ///     specified directory, or an empty array if no directories are found.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more invalid characters. You can query
        ///     for invalid characters by using GetInvalidPathChars().
        ///     -or-
        ///     searchPattern doesn't contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">path or searchPattern is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        string[] GetDirectories(string path, string searchPattern);

#if !NETSTANDARD2_0 && !NET45
        /// <summary>
        ///     Returns the names of subdirectories (including their paths) that match the specified search pattern and enumeration
        ///     options in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of subdirectories in path. This parameter can
        ///     contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.
        /// </param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>
        ///     An array of the full names (including paths) of the subdirectories that match the search pattern and
        ///     enumeration options in the specified directory, or an empty array if no directories are found.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more invalid characters. You can query
        ///     for invalid characters by using GetInvalidPathChars().
        ///     -or-
        ///     searchPattern doesn't contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">path or searchPattern is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions);
#endif
        /// <summary>
        ///     Returns the names of the subdirectories (including their paths) that match the specified search pattern in the
        ///     specified directory, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of subdirectories in path. This parameter can
        ///     contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include all
        ///     subdirectories or only the current directory.
        /// </param>
        /// <returns>
        ///     An array of the full names (including paths) of the subdirectories that match the specified criteria, or an
        ///     empty array if no directories are found.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more invalid characters. You can query
        ///     for invalid characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">path or searchPattern is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">searchOption is not a valid SearchOption value.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);

        /// <summary>
        ///     Returns the volume information, root information, or both for the specified path.
        /// </summary>
        /// <param name="path">The path of a file or directory.</param>
        /// <returns>A string that contains the volume information, root information, or both for the specified path.</returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with GetInvalidPathChars().
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        string GetDirectoryRoot(string path);

        /// <summary>
        ///     Returns the names of files (including their paths) in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>
        ///     An array of the full names (including paths) for the files in the specified directory, or an empty array if no
        ///     files are found.
        /// </returns>
        /// <exception cref="IOException">
        ///     path is a file name.
        ///     -or-
        ///     A network error has occurred.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     The specified path is not found or is invalid (for example, it is on an
        ///     unmapped drive).
        /// </exception>
        string[] GetFiles(string path);

        /// <summary>
        ///     Returns the names of files (including their paths) that match the specified search pattern in the specified
        ///     directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files in path. This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.
        /// </param>
        /// <returns>
        ///     An array of the full names (including paths) for the files in the specified directory that match the specified
        ///     search pattern, or an empty array if no files are found.
        /// </returns>
        /// <exception cref="IOException">
        ///     path is a file name.
        ///     -or-
        ///     A network error has occurred.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more invalid characters. You can query
        ///     for invalid characters by using GetInvalidPathChars().
        ///     -or-
        ///     searchPattern doesn't contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">path or searchPattern is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     The specified path is not found or is invalid (for example, it is on an
        ///     unmapped drive).
        /// </exception>
        string[] GetFiles(string path, string searchPattern);

#if !NETSTANDARD2_0 && !NET45
        /// <summary>
        ///     Returns the names of files (including their paths) that match the specified search pattern and enumeration options
        ///     in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of subdirectories in path. This parameter can
        ///     contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.
        /// </param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>
        ///     An array of the full names (including paths) for the files in the specified directory that match the specified
        ///     search pattern and enumeration options, or an empty array if no files are found.
        /// </returns>
        /// <exception cref="IOException">
        ///     path is a file name.
        ///     -or-
        ///     A network error has occurred.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more invalid characters. You can query
        ///     for invalid characters by using GetInvalidPathChars().
        ///     -or-
        ///     searchPattern doesn't contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">path or searchPattern is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     The specified path is not found or is invalid (for example, it is on an
        ///     unmapped drive).
        /// </exception>
        string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions);
#endif
        /// <summary>
        ///     Returns the names of files (including their paths) that match the specified search pattern in the specified
        ///     directory, using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files in path. This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include all
        ///     subdirectories or only the current directory.
        /// </param>
        /// <returns>
        ///     An array of the full names (including paths) for the files in the specified directory that match the specified
        ///     search pattern and option, or an empty array if no files are found.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more invalid characters. You can query
        ///     for invalid characters with the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">path or searchpattern is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">searchOption is not a valid SearchOption value.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     The specified path is not found or is invalid (for example, it is on an
        ///     unmapped drive).
        /// </exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="IOException">
        ///     path is a file name.
        ///     -or-
        ///     A network error has occurred.
        /// </exception>
        string[] GetFiles(string path, string searchPattern, SearchOption searchOption);

        /// <summary>
        ///     Returns the names of all files and subdirectories in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>
        ///     An array of the names of files and subdirectories in the specified directory, or an empty array if no files or
        ///     subdirectories are found.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with GetInvalidPathChars().
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        string[] GetFileSystemEntries(string path);

        /// <summary>
        ///     Returns an array of file names and directory names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of file and directories in path. This
        ///     parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support
        ///     regular expressions.
        /// </param>
        /// <returns>
        ///     An array of file names and directory names that match the specified search criteria, or an empty array if no
        ///     files or directories are found.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more invalid characters. You can query
        ///     for invalid characters with the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">path or searchPattern is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        string[] GetFileSystemEntries(string path, string searchPattern);

#if !NETSTANDARD2_0 && !NET45
        /// <summary>
        ///     Returns an array of file names and directory names that match a search pattern and enumeration options in a
        ///     specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of subdirectories in path. This parameter can
        ///     contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.
        /// </param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>
        ///     An array of file names and directory names that match the specified search pattern and enumeration options, or
        ///     an empty array if no files or directories are found.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more invalid characters. You can query
        ///     for invalid characters with the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">path or searchPattern is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        string[] GetFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions);
#endif
        /// <summary>
        ///     Returns an array of all the file names and directory names that match a search pattern in a specified path, and
        ///     optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files and directories in path. This
        ///     parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support
        ///     regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.
        /// </param>
        /// <returns>
        ///     An array of file the file names and directory names that match the specified search criteria, or an empty
        ///     array if no files or directories are found.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains invalid characters. You can query for invalid
        ///     characters by using the GetInvalidPathChars() method.
        ///     -or-
        ///     searchPattern does not contain a valid pattern.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     path is null.
        ///     -or-
        ///     searchPattern is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">searchOption is not a valid SearchOption value.</exception>
        /// <exception cref="DirectoryNotFoundException">path is invalid, such as referring to an unmapped drive.</exception>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or combined exceed the system-defined maximum
        ///     length.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption);

        /// <summary>
        ///     Returns the date and time the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information.</param>
        /// <returns>
        ///     A structure that is set to the date and time the specified file or directory was last accessed. This value is
        ///     expressed in local time.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="NotSupportedException">The path parameter is in an invalid format.</exception>
        DateTime GetLastAccessTime(string path);

        /// <summary>
        ///     Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was
        ///     last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information.</param>
        /// <returns>
        ///     A structure that is set to the date and time the specified file or directory was last accessed. This value is
        ///     expressed in UTC time.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="NotSupportedException">The path parameter is in an invalid format.</exception>
        DateTime GetLastAccessTimeUtc(string path);

        /// <summary>
        ///     Returns the date and time the specified file or directory was last written to.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain modification date and time information.</param>
        /// <returns>
        ///     A structure that is set to the date and time the specified file or directory was last written to. This value
        ///     is expressed in local time.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        DateTime GetLastWriteTime(string path);

        /// <summary>
        ///     Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was
        ///     last written to.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain modification date and time information.</param>
        /// <returns>
        ///     A structure that is set to the date and time the specified file or directory was last written to. This value
        ///     is expressed in UTC time.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        DateTime GetLastWriteTimeUtc(string path);

        /// <summary>
        ///     Retrieves the names of the logical drives on this computer in the form "drive letter:\".
        /// </summary>
        /// <returns>The logical drives on this computer.</returns>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error).</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        string[] GetLogicalDrives();

        /// <summary>
        ///     Retrieves the parent directory of the specified path, including both absolute and relative paths.
        /// </summary>
        /// <param name="path">The path for which to retrieve the parent directory.</param>
        /// <returns>The parent directory, or null if path is the root directory, including the root of a UNC server or share name.</returns>
        /// <exception cref="IOException">The directory specified by path is read-only.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or both exceed the system-defined maximum length.
        ///     For more information, see the PathTooLongException topic.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">The specified path was not found.</exception>
        /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
        /// <exception cref="SecurityException">.NET Framework only: The caller does not have the required permissions.</exception>
        DirectoryInfo GetParent(string path);

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
        void Move(string sourceDirName, string destDirName);

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
        void Move(string sourceDirName, string destDirName, bool overwrite);

        /// <summary>
        ///     Sets the creation date and time for the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to set the creation date and time information.</param>
        /// <param name="creationTime">
        ///     The date and time the file or directory was last written to. This value is expressed in
        ///     local time.
        /// </param>
        /// <exception cref="FileNotFoundException">The specified path was not found.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     creationTime specifies a value outside the range of dates or times
        ///     permitted for this operation.
        /// </exception>
        /// <exception cref="PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        void SetCreationTime(string path, DateTime creationTime);

        /// <summary>
        ///     Sets the creation date and time, in Coordinated Universal Time (UTC) format, for the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to set the creation date and time information.</param>
        /// <param name="creationTimeUtc">
        ///     The date and time the directory or file was created. This value is expressed in local
        ///     time.
        /// </param>
        /// <exception cref="FileNotFoundException">The specified path was not found.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     creationTime specifies a value outside the range of dates or times
        ///     permitted for this operation.
        /// </exception>
        /// <exception cref="PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        void SetCreationTimeUtc(string path, DateTime creationTimeUtc);

        /// <summary>
        ///     Sets the date and time the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to set the access date and time information.</param>
        /// <param name="lastAccessTime">
        ///     An object that contains the value to set for the access date and time of path. This value
        ///     is expressed in local time.
        /// </param>
        /// <exception cref="FileNotFoundException">The specified path was not found.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     lastAccessTime specifies a value outside the range of dates or times
        ///     permitted for this operation.
        /// </exception>
        void SetLastAccessTime(string path, DateTime lastAccessTime);

        /// <summary>
        ///     Sets the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last
        ///     accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to set the access date and time information.</param>
        /// <param name="lastAccessTimeUtc">
        ///     An object that contains the value to set for the access date and time of path. This
        ///     value is expressed in UTC time.
        /// </param>
        /// <exception cref="FileNotFoundException">The specified path was not found.</exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     lastAccessTimeUtc specifies a value outside the range of dates or times
        ///     permitted for this operation.
        /// </exception>
        void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);

        /// <summary>
        ///     Sets the date and time a directory was last written to.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <param name="lastWriteTime">The date and time the directory was last written to. This value is expressed in local time.</param>
        /// <exception cref="FileNotFoundException">
        ///     path was not found (for example, the directory doesn't exist or it is on an
        ///     unmapped drive).
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     path was not found (for example, the directory doesn't exist or it is on
        ///     an unmapped drive).
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     lastWriteTime specifies a value outside the range of dates or times
        ///     permitted for this operation.
        /// </exception>
        void SetLastWriteTime(string path, DateTime lastWriteTime);

        /// <summary>
        ///     Sets the date and time, in Coordinated Universal Time (UTC) format, that a directory was last written to.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <param name="lastWriteTimeUtc">
        ///     The date and time the directory was last written to. This value is expressed in UTC
        ///     time.
        /// </param>
        /// <exception cref="FileNotFoundException">
        ///     path was not found (for example, the directory doesn't exist or it is on an
        ///     unmapped drive).
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     path was not found (for example, the directory doesn't exist or it is on
        ///     an unmapped drive).
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters. You can query for invalid characters with the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     lastWriteTimeUtc specifies a value outside the range of dates or times
        ///     permitted for this operation.
        /// </exception>
        void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
    }
}
// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IFile.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.FileSystems;

/// <summary>
///     Provides static methods for the creation, copying, deletion, moving, and opening of a single file, and aids in the
///     creation of FileStream objects.
/// </summary>
public interface IFile
{
    /// <summary>
    ///     Appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a
    ///     file, writes the specified lines to the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
    /// <param name="contents">The lines to append to the file.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one more
    ///     invalid characters defined by the GetInvalidPathChars() method.
    /// </exception>
    /// <exception cref="ArgumentNullException">Either path or contents is null.</exception>
    /// <exception cref="DirectoryNotFoundException">
    ///     path is invalid (for example, the directory doesn't exist or it is on an
    ///     unmapped drive).
    /// </exception>
    /// <exception cref="FileNotFoundException">The file specified by path was not found.</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="PathTooLongException">path exceeds the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have permission to write to the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specifies a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path is a directory.
    /// </exception>
    void AppendAllLines(string path, IEnumerable<string> contents);

    /// <summary>
    ///     Appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not
    ///     exist, this method creates a file, writes the specified lines to the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
    /// <param name="contents">The lines to append to the file.</param>
    /// <param name="encoding">The character encoding to use.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one more
    ///     invalid characters defined by the GetInvalidPathChars() method.
    /// </exception>
    /// <exception cref="ArgumentNullException">Either path, contents, or encoding is null.</exception>
    /// <exception cref="DirectoryNotFoundException">
    ///     path is invalid (for example, the directory doesn't exist or it is on an
    ///     unmapped drive).
    /// </exception>
    /// <exception cref="FileNotFoundException">The file specified by path was not found.</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="PathTooLongException">path exceeds the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specifies a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path is a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);

    /// <summary>
    ///     Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this
    ///     method creates a file, writes the specified string to the file, then closes the file.
    /// </summary>
    /// <param name="path">The file to append the specified string to.</param>
    /// <param name="contents">The string to append to the file.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">
    ///     The specified path is invalid (for example, the directory doesn't exist or
    ///     it is on an unmapped drive).
    /// </exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    void AppendAllText(string path, string contents);

    /// <summary>
    ///     Appends the specified string to the file using the specified encoding, creating the file if it does not already
    ///     exist.
    /// </summary>
    /// <param name="path">The file to append the specified string to.</param>
    /// <param name="contents">The string to append to the file.</param>
    /// <param name="encoding">The character encoding to use.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">
    ///     The specified path is invalid (for example, the directory doesn't exist or
    ///     it is on an unmapped drive).
    /// </exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    void AppendAllText(string path, string contents, Encoding encoding);

    /// <summary>
    ///     Creates a StreamWriter that appends UTF-8 encoded text to an existing file, or to a new file if the specified file
    ///     does not exist.
    /// </summary>
    /// <param name="path">The path to the file to append to.</param>
    /// <returns>A stream writer that appends UTF-8 encoded text to the specified file or to a new file.</returns>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">
    ///     The specified path is invalid (for example, the directory doesn't exist or
    ///     it is on an unmapped drive).
    /// </exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    StreamWriter AppendText(string path);

    /// <summary>
    ///     Copies an existing file to a new file. Overwriting a file of the same name is not allowed.
    /// </summary>
    /// <param name="sourceFileName">The file to copy.</param>
    /// <param name="destFileName">The name of the destination file. This cannot be a directory or an existing file.</param>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="ArgumentException">
    ///     sourceFileName or destFileName is a zero-length string, contains only white space, or contains one or more invalid
    ///     characters as defined by InvalidPathChars.
    ///     -or-
    ///     sourceFileName or destFileName specifies a directory.
    /// </exception>
    /// <exception cref="ArgumentNullException">sourceFileName or destFileName is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">
    ///     The path specified in sourceFileName or destFileName is invalid (for
    ///     example, it is on an unmapped drive).
    /// </exception>
    /// <exception cref="FileNotFoundException">sourceFileName was not found.</exception>
    /// <exception cref="IOException">
    ///     destFileName exists.
    ///     -or-
    ///     An I/O error has occurred.
    /// </exception>
    /// <exception cref="NotSupportedException">sourceFileName or destFileName is in an invalid format.</exception>
    void Copy(string sourceFileName, string destFileName);

    /// <summary>
    ///     Copies an existing file to a new file. Overwriting a file of the same name is allowed.
    /// </summary>
    /// <param name="sourceFileName">The file to copy.</param>
    /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
    /// <param name="overwrite">True if the destination file can be overwritten; otherwise, false.</param>
    /// <exception cref="UnauthorizedAccessException">
    ///     The caller does not have the required permission.
    ///     -or-
    ///     destFileName is read-only.
    ///     -or-
    ///     overwrite is true, destFileName exists and is hidden, but sourceFileName is not hidden.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     sourceFileName or destFileName is a zero-length string, contains only white space, or contains one or more invalid
    ///     characters as defined by InvalidPathChars.
    ///     -or-
    ///     sourceFileName or destFileName specifies a directory.
    /// </exception>
    /// <exception cref="ArgumentNullException">sourceFileName or destFileName is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">
    ///     The path specified in sourceFileName or destFileName is invalid (for
    ///     example, it is on an unmapped drive).
    /// </exception>
    /// <exception cref="FileNotFoundException">sourceFileName was not found.</exception>
    /// <exception cref="IOException">
    ///     destFileName exists and overwrite is false.
    ///     -or-
    ///     An I/O error has occurred.
    /// </exception>
    /// <exception cref="NotSupportedException">sourceFileName or destFileName is in an invalid format.</exception>
    void Copy(string sourceFileName, string destFileName, bool overwrite);

    /// <summary>
    ///     Creates or overwrites a file in the specified path.
    /// </summary>
    /// <param name="path">The path and name of the file to create.</param>
    /// <returns>A FileStream that provides read/write access to the file specified in path.</returns>
    /// <exception cref="UnauthorizedAccessException">
    ///     The caller does not have the required permission.
    ///     -or-
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while creating the file.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    FileStream Create(string path);

    /// <summary>
    ///     Creates or overwrites a file in the specified path, specifying a buffer size.
    /// </summary>
    /// <param name="path">The path and name of the file to create.</param>
    /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file.</param>
    /// <returns>A FileStream with the specified buffer size that provides read/write access to the file specified in path.</returns>
    /// <exception cref="UnauthorizedAccessException">
    ///     The caller does not have the required permission.
    ///     -or-
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while creating the file.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    FileStream Create(string path, int bufferSize);

    /// <summary>
    ///     Creates or overwrites a file in the specified path, specifying a buffer size and options that describe how to
    ///     create or overwrite the file.
    /// </summary>
    /// <param name="path">The path and name of the file to create.</param>
    /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file.</param>
    /// <param name="options">One of the FileOptions values that describes how to create or overwrite the file.</param>
    /// <returns>A new file with the specified buffer size.</returns>
    /// <exception cref="UnauthorizedAccessException">
    ///     The caller does not have the required permission.
    ///     -or-
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive.</exception>
    /// <exception cref="IOException">An I/O error occurred while creating the file.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    FileStream Create(string path, int bufferSize, FileOptions options);

    /// <summary>
    ///     Creates or opens a file for writing UTF-8 encoded text. If the file already exists, its contents are overwritten.
    /// </summary>
    /// <param name="path">The file to be opened for writing.</param>
    /// <returns>A StreamWriter that writes to the specified file using UTF-8 encoding.</returns>
    /// <exception cref="UnauthorizedAccessException">
    ///     The caller does not have the required permission.
    ///     -or-
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    StreamWriter CreateText(string path);

    /// <summary>
    ///     Decrypts a file that was encrypted by the current account using the Encrypt(String) method.
    /// </summary>
    /// <param name="path">A path that describes a file to decrypt.</param>
    /// <exception cref="ArgumentException">
    ///     The path parameter is a zero-length string, contains only white space, or contains
    ///     one or more invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">The path parameter is null.</exception>
    /// <exception cref="DriveNotFoundException">An invalid drive was specified.</exception>
    /// <exception cref="FileNotFoundException">The file described by the path parameter could not be found.</exception>
    /// <exception cref="IOException">
    ///     An I/O error occurred while opening the file. For example, the encrypted file is already open.
    ///     -or-
    ///     This operation is not supported on the current platform.
    /// </exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
    /// <exception cref="NotSupportedException">The file system is not NTFS.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     The path parameter specified a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     The path parameter specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    [SupportedOSPlatform("windows")]
    void Decrypt(string path);

    /// <summary>
    ///     Deletes the specified file.
    /// </summary>
    /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">
    ///     The specified file is in use.
    ///     -or-
    ///     There is an open handle on the file, and the operating system is Windows XP or earlier.This open handle can result
    ///     from enumerating directories and files.For more information, see How to: Enumerate Directories and Files.
    /// </exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     The caller does not have the required permission.
    ///     -or-
    ///     The file is an executable file that is in use.
    ///     -or-
    ///     path is a directory.
    ///     -or-
    ///     path specified a read-only file.
    /// </exception>
    void Delete(string path);

    /// <summary>
    ///     Encrypts a file so that only the account used to encrypt the file can decrypt it.
    /// </summary>
    /// <param name="path">A path that describes a file to encrypt.</param>
    /// <exception cref="ArgumentException">
    ///     The path parameter is a zero-length string, contains only white space, or contains
    ///     one or more invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">The path parameter is null.</exception>
    /// <exception cref="DriveNotFoundException">An invalid drive was specified.</exception>
    /// <exception cref="FileNotFoundException">The file described by the path parameter could not be found.</exception>
    /// <exception cref="IOException">
    ///     An I/O error occurred while opening the file.
    ///     -or-
    ///     This operation is not supported on the current platform.
    /// </exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
    /// <exception cref="NotSupportedException">The file system is not NTFS.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     The path parameter specified a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     The path parameter specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    [SupportedOSPlatform("windows")]
    void Encrypt(string path);

    /// <summary>
    ///     Determines whether the specified file exists.
    /// </summary>
    /// <param name="path">The file to check.</param>
    /// <returns>
    ///     True if the caller has the required permissions and path contains the name of an existing file; otherwise,
    ///     false. This method also returns false if path is null, an invalid path, or a zero-length string. If the caller does
    ///     not have sufficient permissions to read the specified file, no exception is thrown and the method returns false
    ///     regardless of the existence of path.
    /// </returns>
    bool Exists(string path);

    /// <summary>
    ///     Gets the FileAttributes of the file on the path.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <returns>The FileAttributes of the file on the path.</returns>
    /// <exception cref="ArgumentException">path is empty, contains only white spaces, or contains invalid characters.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="FileNotFoundException">
    ///     path represents a file and is invalid, such as being on an unmapped drive, or
    ///     the file cannot be found.
    /// </exception>
    /// <exception cref="DirectoryNotFoundException">
    ///     path represents a directory and is invalid, such as being on an unmapped
    ///     drive, or the directory cannot be found.
    /// </exception>
    /// <exception cref="IOException">This file is being used by another process.</exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    FileAttributes GetAttributes(string path);

    /// <summary>
    ///     Returns the creation date and time of the specified file or directory.
    /// </summary>
    /// <param name="path">The file or directory for which to obtain creation date and time information.</param>
    /// <returns>
    ///     A DateTime structure set to the creation date and time for the specified file or directory. This value is
    ///     expressed in local time.
    /// </returns>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    DateTime GetCreationTime(string path);

    /// <summary>
    ///     Returns the creation date and time, in coordinated universal time (UTC), of the specified file or directory.
    /// </summary>
    /// <param name="path">The file or directory for which to obtain creation date and time information.</param>
    /// <returns>
    ///     A DateTime structure set to the creation date and time for the specified file or directory. This value is
    ///     expressed in UTC time.
    /// </returns>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    DateTime GetCreationTimeUtc(string path);

    /// <summary>
    ///     Returns the date and time the specified file or directory was last accessed.
    /// </summary>
    /// <param name="path">The file or directory for which to obtain access date and time information.</param>
    /// <returns>
    ///     A DateTime structure set to the date and time that the specified file or directory was last accessed. This
    ///     value is expressed in local time.
    /// </returns>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    DateTime GetLastAccessTime(string path);

    /// <summary>
    ///     Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last
    ///     accessed.
    /// </summary>
    /// <param name="path">The file or directory for which to obtain access date and time information.</param>
    /// <returns>
    ///     A DateTime structure set to the date and time that the specified file or directory was last accessed. This
    ///     value is expressed in UTC time.
    /// </returns>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    DateTime GetLastAccessTimeUtc(string path);

    /// <summary>
    ///     Returns the date and time the specified file or directory was last written to.
    /// </summary>
    /// <param name="path">The file or directory for which to obtain write date and time information.</param>
    /// <returns>
    ///     A DateTime structure set to the date and time that the specified file or directory was last written to. This
    ///     value is expressed in local time.
    /// </returns>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    DateTime GetLastWriteTime(string path);

    /// <summary>
    ///     Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last
    ///     written to.
    /// </summary>
    /// <param name="path">The file or directory for which to obtain write date and time information.</param>
    /// <returns>
    ///     A DateTime structure set to the date and time that the specified file or directory was last written to. This
    ///     value is expressed in UTC time.
    /// </returns>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    DateTime GetLastWriteTimeUtc(string path);

    /// <summary>
    ///     Moves a specified file to a new location, providing the option to specify a new file name.
    /// </summary>
    /// <param name="sourceFileName">The name of the file to move. Can include a relative or absolute path.</param>
    /// <param name="destFileName">The new path and name for the file.</param>
    /// <exception cref="IOException">
    ///     destFileName already exists.
    ///     -or-
    ///     An I/O error has occurred, e.g. while copying the file across disk volumes.
    /// </exception>
    /// <exception cref="FileNotFoundException">sourceFileName was not found.</exception>
    /// <exception cref="ArgumentNullException">sourceFileName or destFileName is null.</exception>
    /// <exception cref="ArgumentException">
    ///     sourceFileName or destFileName is a zero-length string, contains only white space,
    ///     or contains invalid characters as defined in InvalidPathChars.
    /// </exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">
    ///     The path specified in sourceFileName or destFileName is invalid, (for
    ///     example, it is on an unmapped drive).
    /// </exception>
    /// <exception cref="NotSupportedException">sourceFileName or destFileName is in an invalid format.</exception>
    void Move(string sourceFileName, string destFileName);

    /// <summary>
    ///     Moves a specified file to a new location, providing the options to specify a new file name and to overwrite the
    ///     destination file if it already exists.
    /// </summary>
    /// <param name="sourceFileName">The name of the file to move. Can include a relative or absolute path.</param>
    /// <param name="destFileName">The new path and name for the file.</param>
    /// <param name="overwrite">True to overwrite the destination file if it already exists; false otherwise.</param>
    /// <exception cref="IOException">
    ///     destFileName already exists and overwrite is false.
    ///     -or-
    ///     An I/O error has occurred, e.g. while copying the file across disk volumes.
    /// </exception>
    /// <exception cref="FileNotFoundException">sourceFileName was not found.</exception>
    /// <exception cref="ArgumentNullException">sourceFileName or destFileName is null.</exception>
    /// <exception cref="ArgumentException">
    ///     sourceFileName or destFileName is a zero-length string, contains only white space,
    ///     or contains invalid characters as defined in InvalidPathChars.
    /// </exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">
    ///     The path specified in sourceFileName or destFileName is invalid, (for
    ///     example, it is on an unmapped drive).
    /// </exception>
    /// <exception cref="NotSupportedException">sourceFileName or destFileName is in an invalid format.</exception>
    void Move(string sourceFileName, string destFileName, bool overwrite);

    /// <summary>
    ///     Opens a FileStream on the specified path with read/write access with no sharing.
    /// </summary>
    /// <param name="path">The file to open.</param>
    /// <param name="mode">
    ///     A FileMode value that specifies whether a file is created if one does not exist, and determines
    ///     whether the contents of existing files are retained or overwritten.
    /// </param>
    /// <returns>A FileStream opened in the specified mode and path, with read/write access and not shared.</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    ///     -or-
    ///     mode is Create and the specified file is a hidden file.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">mode specified an invalid value.</exception>
    /// <exception cref="FileNotFoundException">The file specified in path was not found.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    FileStream Open(string path, FileMode mode);

    /// <summary>
    ///     Opens a FileStream on the specified path, with the specified mode and access with no sharing.
    /// </summary>
    /// <param name="path">The file to open.</param>
    /// <param name="mode">
    ///     A FileMode value that specifies whether a file is created if one does not exist, and determines
    ///     whether the contents of existing files are retained or overwritten.
    /// </param>
    /// <param name="access">A FileAccess value that specifies the operations that can be performed on the file.</param>
    /// <returns>An unshared FileStream that provides access to the specified file, with the specified mode and access.</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more invalid characters as defined by
    ///     InvalidPathChars.
    ///     -or-
    ///     access specified Read and mode specified Create, CreateNew, Truncate, or Append.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only and access is not Read.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    ///     -or-
    ///     mode is Create and the specified file is a hidden file.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">mode or access specified an invalid value.</exception>
    /// <exception cref="FileNotFoundException">The file specified in path was not found.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    FileStream Open(string path, FileMode mode, FileAccess access);

    /// <summary>
    ///     Opens a FileStream on the specified path, having the specified mode with read, write, or read/write access and the
    ///     specified sharing option.
    /// </summary>
    /// <param name="path">The file to open.</param>
    /// <param name="mode">
    ///     A FileMode value that specifies whether a file is created if one does not exist, and determines
    ///     whether the contents of existing files are retained or overwritten.
    /// </param>
    /// <param name="access">A FileAccess value that specifies the operations that can be performed on the file.</param>
    /// <param name="share">A FileShare value specifying the type of access other threads have to the file.</param>
    /// <returns>
    ///     A FileStream on the specified path, having the specified mode with read, write, or read/write access and the
    ///     specified sharing option.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more invalid characters as defined by
    ///     InvalidPathChars.
    ///     -or-
    ///     access specified Read and mode specified Create, CreateNew, Truncate, or Append.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only and access is not Read.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    ///     -or-
    ///     mode is Create and the specified file is a hidden file.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">mode, access, or share specified an invalid value.</exception>
    /// <exception cref="FileNotFoundException">The file specified in path was not found.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    FileStream Open(string path, FileMode mode, FileAccess access, FileShare share);

    /// <summary>
    ///     Opens an existing file for reading.
    /// </summary>
    /// <param name="path">The file to be opened for reading.</param>
    /// <returns>A read-only FileStream on the specified path.</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="FileNotFoundException">The file specified in path was not found.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    FileStream OpenRead(string path);

    /// <summary>
    ///     Opens an existing UTF-8 encoded text file for reading.
    /// </summary>
    /// <param name="path">The file to be opened for reading.</param>
    /// <returns>A StreamReader on the specified path.</returns>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
    /// <exception cref="FileNotFoundException">The file specified in path was not found.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    StreamReader OpenText(string path);

    /// <summary>
    ///     Opens an existing file or creates a new file for writing.
    /// </summary>
    /// <param name="path">The file to be opened for writing.</param>
    /// <returns>An unshared FileStream object on the specified path with Write access.</returns>
    /// <exception cref="UnauthorizedAccessException">
    ///     The caller does not have the required permission.
    ///     -or-
    ///     path specified a read-only file or directory.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    FileStream OpenWrite(string path);

    /// <summary>
    ///     Opens a binary file, reads the contents of the file into a byte array, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <returns>A byte array containing the contents of the file.</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="FileNotFoundException">The file specified in path was not found.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    byte[] ReadAllBytes(string path);

    /// <summary>
    ///     Asynchronously opens a binary file, reads the contents of the file into a byte array, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>
    ///     A task that represents the asynchronous read operation, which wraps the byte array containing the contents of
    ///     the file.
    /// </returns>
    Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Opens a text file, reads all lines of the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <returns>A string array containing all lines of the file.</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="FileNotFoundException">The file specified in path was not found.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    string[] ReadAllLines(string path);

    /// <summary>
    ///     Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <param name="encoding">The encoding applied to the contents of the file.</param>
    /// <returns>A string array containing all lines of the file.</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="FileNotFoundException">The file specified in path was not found.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    string[] ReadAllLines(string path, Encoding encoding);

    /// <summary>
    ///     Opens a text file, reads all the text in the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <returns>A string containing all the text in the file.</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="FileNotFoundException">The file specified in path was not found.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    string ReadAllText(string path);

    /// <summary>
    ///     Opens a file, reads all text in the file with the specified encoding, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <param name="encoding">The encoding applied to the contents of the file.</param>
    /// <returns>A string containing all text in the file.</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="FileNotFoundException">The file specified in path was not found.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    string ReadAllText(string path, Encoding encoding);

    /// <summary>
    ///     Reads the lines of a file.
    /// </summary>
    /// <param name="path">The file to read.</param>
    /// <returns>All the lines of the file, or the lines that are the result of a query.</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters defined by the GetInvalidPathChars() method.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="DirectoryNotFoundException">path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="FileNotFoundException">The file specified by path was not found.</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="PathTooLongException">path exceeds the system-defined maximum length.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specifies a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path is a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    IEnumerable<string> ReadLines(string path);

    /// <summary>
    ///     Read the lines of a file that has a specified encoding.
    /// </summary>
    /// <param name="path">The file to read.</param>
    /// <param name="encoding">The encoding that is applied to the contents of the file.</param>
    /// <returns>All the lines of the file, or the lines that are the result of a query.</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by the GetInvalidPathChars() method.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="DirectoryNotFoundException">path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="FileNotFoundException">The file specified by path was not found.</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="PathTooLongException">path exceeds the system-defined maximum length.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specifies a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path is a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    IEnumerable<string> ReadLines(string path, Encoding encoding);

    /// <summary>
    ///     Replaces the contents of a specified file with the contents of another file, deleting the original file, and
    ///     creating a backup of the replaced file.
    /// </summary>
    /// <param name="sourceFileName">The name of a file that replaces the file specified by destinationFileName.</param>
    /// <param name="destinationFileName">The name of the file being replaced.</param>
    /// <param name="destinationBackupFileName">The name of the backup file.</param>
    /// <exception cref="ArgumentException">
    ///     The path described by the destinationFileName parameter was not of a legal form.
    ///     -or-
    ///     The path described by the destinationBackupFileName parameter was not of a legal form.
    /// </exception>
    /// <exception cref="ArgumentNullException">The destinationFileName parameter is null.</exception>
    /// <exception cref="DriveNotFoundException">An invalid drive was specified.</exception>
    /// <exception cref="FileNotFoundException">
    ///     The file described by the current FileInfo object could not be found.
    ///     -or-
    ///     The file described by the destinationBackupFileName parameter could not be found.
    /// </exception>
    /// <exception cref="IOException">
    ///     An I/O error occurred while opening the file.
    ///     -or-
    ///     The sourceFileName and destinationFileName parameters specify the same file.
    /// </exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     The sourceFileName or destinationFileName parameter specifies a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     Source or destination parameters specify a directory instead of a file.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName);

    /// <summary>
    ///     Replaces the contents of a specified file with the contents of another file, deleting the original file, and
    ///     creating a backup of the replaced file and optionally ignores merge errors.
    /// </summary>
    /// <param name="sourceFileName">The name of a file that replaces the file specified by destinationFileName.</param>
    /// <param name="destinationFileName">The name of the file being replaced.</param>
    /// <param name="destinationBackupFileName">The name of the backup file.</param>
    /// <param name="ignoreMetadataErrors">
    ///     True to ignore merge errors (such as attributes and access control lists (ACLs))
    ///     from the replaced file to the replacement file; otherwise, false.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     The path described by the destinationFileName parameter was not of a legal form.
    ///     -or-
    ///     The path described by the destinationBackupFileName parameter was not of a legal form.
    /// </exception>
    /// <exception cref="ArgumentNullException">The destinationFileName parameter is null.</exception>
    /// <exception cref="DriveNotFoundException">An invalid drive was specified.</exception>
    /// <exception cref="FileNotFoundException">
    ///     The file described by the current FileInfo object could not be found.
    ///     -or-
    ///     The file described by the destinationBackupFileName parameter could not be found.
    /// </exception>
    /// <exception cref="IOException">
    ///     An I/O error occurred while opening the file.
    ///     -or-
    ///     The sourceFileName and destinationFileName parameters specify the same file.
    /// </exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     The sourceFileName or destinationFileName parameter specifies a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     Source or destination parameters specify a directory instead of a file.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors);

    /// <summary>
    ///     Sets the specified FileAttributes of the file on the specified path.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="fileAttributes">A bitwise combination of the enumeration values.</param>
    /// <exception cref="ArgumentException">
    ///     path is empty, contains only white spaces, contains invalid characters, or the file
    ///     attribute is invalid.
    /// </exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    void SetAttributes(string path, FileAttributes fileAttributes);

    /// <summary>
    ///     Sets the date and time the file was created.
    /// </summary>
    /// <param name="path">The file for which to set the creation date and time information.</param>
    /// <param name="creationTime">
    ///     A DateTime containing the value to set for the creation date and time of path. This value is
    ///     expressed in local time.
    /// </param>
    /// <exception cref="FileNotFoundException">The specified path was not found.</exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="IOException">An I/O error occurred while performing the operation.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     creationTime specifies a value outside the range of dates, times, or both
    ///     permitted for this operation.
    /// </exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    void SetCreationTime(string path, DateTime creationTime);

    /// <summary>
    ///     Sets the date and time, in coordinated universal time (UTC), that the file was created.
    /// </summary>
    /// <param name="path">The file for which to set the creation date and time information.</param>
    /// <param name="creationTimeUtc">
    ///     A DateTime containing the value to set for the creation date and time of path. This value
    ///     is expressed in UTC time.
    /// </param>
    /// <exception cref="FileNotFoundException">The specified path was not found.</exception>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="IOException">An I/O error occurred while performing the operation.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     creationTime specifies a value outside the range of dates, times, or both
    ///     permitted for this operation.
    /// </exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    void SetCreationTimeUtc(string path, DateTime creationTimeUtc);

    /// <summary>
    ///     Sets the date and time the specified file was last accessed.
    /// </summary>
    /// <param name="path">The file for which to set the access date and time information.</param>
    /// <param name="lastAccessTime">
    ///     A DateTime containing the value to set for the last access date and time of path. This
    ///     value is expressed in local time.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="FileNotFoundException">The specified path was not found.</exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     lastAccessTime specifies a value outside the range of dates or times
    ///     permitted for this operation.
    /// </exception>
    void SetLastAccessTime(string path, DateTime lastAccessTime);

    /// <summary>
    ///     Sets the date and time, in coordinated universal time (UTC), that the specified file was last accessed.
    /// </summary>
    /// <param name="path">The file for which to set the access date and time information.</param>
    /// <param name="lastAccessTimeUtc">
    ///     A DateTime containing the value to set for the last access date and time of path. This
    ///     value is expressed in UTC time.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="FileNotFoundException">The specified path was not found.</exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     lastAccessTimeUtc specifies a value outside the range of dates or times
    ///     permitted for this operation.
    /// </exception>
    void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);

    /// <summary>
    ///     Sets the date and time that the specified file was last written to.
    /// </summary>
    /// <param name="path">The file for which to set the date and time information.</param>
    /// <param name="lastWriteTime">
    ///     A DateTime containing the value to set for the last write date and time of path. This value
    ///     is expressed in local time.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="FileNotFoundException">The specified path was not found.</exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     lastWriteTime specifies a value outside the range of dates or times
    ///     permitted for this operation.
    /// </exception>
    void SetLastWriteTime(string path, DateTime lastWriteTime);

    /// <summary>
    ///     Sets the date and time, in coordinated universal time (UTC), that the specified file was last written to.
    /// </summary>
    /// <param name="path">The file for which to set the date and time information.</param>
    /// <param name="lastWriteTimeUtc">
    ///     A DateTime containing the value to set for the last write date and time of path. This
    ///     value is expressed in UTC time.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="FileNotFoundException">The specified path was not found.</exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     lastWriteTimeUtc specifies a value outside the range of dates or times
    ///     permitted for this operation.
    /// </exception>
    void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);

    /// <summary>
    ///     Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file
    ///     already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="bytes">The bytes to write to the file.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null or the byte array is empty.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    void WriteAllBytes(string path, byte[] bytes);

    /// <summary>
    ///     Asynchronously creates a new file, writes the specified byte array to the file, and then closes the file. If the
    ///     target file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="bytes">The bytes to write to the file.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new file, writes a collection of strings to the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The lines to write to the file.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters defined by the GetInvalidPathChars() method.
    /// </exception>
    /// <exception cref="ArgumentNullException">Either path or contents is null.</exception>
    /// <exception cref="DirectoryNotFoundException">path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="PathTooLongException">path exceeds the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path is a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    void WriteAllLines(string path, IEnumerable<string> contents);

    /// <summary>
    ///     Creates a new file, write the specified string array to the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The string array to write to the file.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">Either path or contents is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    void WriteAllLines(string path, string[] contents);

    /// <summary>
    ///     Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the
    ///     file.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The lines to write to the file.</param>
    /// <param name="encoding">The character encoding to use.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters defined by the GetInvalidPathChars() method.
    /// </exception>
    /// <exception cref="ArgumentNullException">Either path, contents, or encoding is null.</exception>
    /// <exception cref="DirectoryNotFoundException">path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="PathTooLongException">path exceeds the system-defined maximum length.</exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path is a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);

    /// <summary>
    ///     Creates a new file, writes the specified string array to the file by using the specified encoding, and then closes
    ///     the file.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The string array to write to the file.</param>
    /// <param name="encoding">An Encoding object that represents the character encoding applied to the string array.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">Either path or contents is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    void WriteAllLines(string path, string[] contents, Encoding encoding);

    /// <summary>
    ///     Creates a new file, writes the specified string to the file, and then closes the file. If the target file already
    ///     exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The string to write to the file.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    void WriteAllText(string path, string contents);

    /// <summary>
    ///     Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file.
    ///     If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The string to write to the file.</param>
    /// <param name="encoding">The encoding to apply to the string.</param>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more
    ///     invalid characters as defined by InvalidPathChars.
    /// </exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
    /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">
    ///     path specified a file that is read-only.
    ///     -or-
    ///     path specified a file that is hidden.
    ///     -or-
    ///     This operation is not supported on the current platform.
    ///     -or-
    ///     path specified a directory.
    ///     -or-
    ///     The caller does not have the required permission.
    /// </exception>
    /// <exception cref="NotSupportedException">path is in an invalid format.</exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    void WriteAllText(string path, string contents, Encoding encoding);

    /// <summary>
    ///     Asynchronously appends lines to a file, and then closes the file. If the specified file does not exist, this method
    ///     creates a file, writes the specified lines to the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
    /// <param name="contents">The lines to append to the file.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>A task that represents the asynchronous append operation.</returns>
    Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously appends lines to a file by using a specified encoding, and then closes the file. If the specified
    ///     file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
    /// <param name="contents">The lines to append to the file.</param>
    /// <param name="encoding">The character encoding to use.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>A task that represents the asynchronous append operation.</returns>
    Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously opens a file or creates a file if it does not already exist, appends the specified string to the
    ///     file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to append the specified string to.</param>
    /// <param name="contents">The string to append to the file.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>A task that represents the asynchronous append operation.</returns>
    Task AppendAllTextAsync(string path, string contents, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the
    ///     file using the specified encoding, and then closes the file.
    /// </summary>
    /// <param name="path">The file to append the specified string to.</param>
    /// <param name="contents">The string to append to the file.</param>
    /// <param name="encoding">The character encoding to use.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>A task that represents the asynchronous append operation.</returns>
    Task AppendAllTextAsync(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously opens a text file, reads all lines of the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>
    ///     A task that represents the asynchronous read operation, which wraps the string array containing all lines of
    ///     the file.
    /// </returns>
    Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously opens a text file, reads all lines of the file with the specified encoding, and then closes the
    ///     file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <param name="encoding">The encoding applied to the contents of the file.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>
    ///     A task that represents the asynchronous read operation, which wraps the string array containing all lines of
    ///     the file.
    /// </returns>
    Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously opens a text file, reads all the text in the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>
    ///     A task that represents the asynchronous read operation, which wraps the string containing all text in the
    ///     file.
    /// </returns>
    Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously opens a text file, reads all text in the file with the specified encoding, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <param name="encoding">The encoding applied to the contents of the file.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>
    ///     A task that represents the asynchronous read operation, which wraps the string containing all text in the
    ///     file.
    /// </returns>
    Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously creates a new file, writes the specified lines to the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The lines to write to the file.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously creates a new file, write the specified lines to the file by using the specified encoding, and then
    ///     closes the file.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The lines to write to the file.</param>
    /// <param name="encoding">The character encoding to use.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously creates a new file, writes the specified string to the file, and then closes the file. If the target
    ///     file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The string to write to the file.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteAllTextAsync(string path, string contents, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Asynchronously creates a new file, writes the specified string to the file using the specified encoding, and then
    ///     closes the file. If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The string to write to the file.</param>
    /// <param name="encoding">The encoding to apply to the string.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteAllTextAsync(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default);
}
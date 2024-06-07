// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IPath.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Security;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.FileSystems;

/// <summary>
///     Performs operations on String instances that contain file or directory path information. These operations are
///     performed in a cross-platform manner.
/// </summary>
public interface IPath
{
    /// <summary>
    ///     Provides a platform-specific alternate character used to separate directory levels in a path string that reflects a
    ///     hierarchical file system organization.
    /// </summary>
    char AltDirectorySeparatorChar { get; }

    /// <summary>
    ///     Provides a platform-specific character used to separate directory levels in a path string that reflects a
    ///     hierarchical file system organization.
    /// </summary>
    char DirectorySeparatorChar { get; }

    /// <summary>
    ///     A platform-specific separator character used to separate path strings in environment variables.
    /// </summary>
    char PathSeparator { get; }

    /// <summary>
    ///     Provides a platform-specific volume separator character.
    /// </summary>
    char VolumeSeparatorChar { get; }

    /// <summary>
    ///     Changes the extension of a path string.
    /// </summary>
    /// <param name="path">The path information to modify.</param>
    /// <param name="extension">
    ///     The new extension (with or without a leading period). Specify null to remove an existing
    ///     extension from path.
    /// </param>
    /// <returns>
    ///     The modified path information.
    ///     On Windows-based desktop platforms, if path is null or an empty string (""), the path information is returned
    ///     unmodified.If extension is null, the returned string contains the specified path with its extension removed.If path
    ///     has no extension, and extension is not null, the returned path string contains extension appended to the end of
    ///     path.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: path contains one or more of
    ///     the invalid characters defined in GetInvalidPathChars().
    /// </exception>
    string ChangeExtension(string path, string extension);

    /// <summary>
    ///     Combines an array of strings into a path.
    /// </summary>
    /// <param name="paths">An array of parts of the path.</param>
    /// <returns>The combined paths.</returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: One of the strings in the
    ///     array contains one or more of the invalid characters defined in GetInvalidPathChars().
    /// </exception>
    /// <exception cref="ArgumentNullException">One of the strings in the array is null.</exception>
    string Combine(params string[] paths);

    /// <summary>
    ///     Combines two strings into a path.
    /// </summary>
    /// <param name="path1">The first path to combine.</param>
    /// <param name="path2">The second path to combine.</param>
    /// <returns>
    ///     The combined paths. If one of the specified paths is a zero-length string, this method returns the other path.
    ///     If path2 contains an absolute path, this method returns path2.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: path1 or path2 contains one
    ///     or more of the invalid characters defined in GetInvalidPathChars().
    /// </exception>
    /// <exception cref="ArgumentNullException">path1 or path2 is null.</exception>
    string Combine(string path1, string path2);

    /// <summary>
    ///     Combines three strings into a path.
    /// </summary>
    /// <param name="path1">The first path to combine.</param>
    /// <param name="path2">The second path to combine.</param>
    /// <param name="path3">The third path to combine.</param>
    /// <returns>The combined paths.</returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: path1, path2, or path3
    ///     contains one or more of the invalid characters defined in GetInvalidPathChars().
    /// </exception>
    /// <exception cref="ArgumentNullException">path1, path2, or path3 is null.</exception>
    string Combine(string path1, string path2, string path3);

    /// <summary>
    ///     Combines four strings into a path.
    /// </summary>
    /// <param name="path1">The first path to combine.</param>
    /// <param name="path2">The second path to combine.</param>
    /// <param name="path3">The third path to combine.</param>
    /// <param name="path4">The fourth path to combine.</param>
    /// <returns>The combined paths.</returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: path1, path2, path3, or path4
    ///     contains one or more of the invalid characters defined in GetInvalidPathChars().
    /// </exception>
    /// <exception cref="ArgumentNullException">path1, path2, path3, or path4 is null.</exception>
    string Combine(string path1, string path2, string path3, string path4);

    /// <summary>
    ///     Returns the directory information for the specified path.
    /// </summary>
    /// <param name="path">The path of a file or directory.</param>
    /// <returns>
    ///     Directory information for path, or null if path denotes a root directory or is null. Returns Empty if path
    ///     does not contain directory information.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: The path parameter contains
    ///     invalid characters, is empty, or contains only white spaces.
    /// </exception>
    /// <exception cref="PathTooLongException">The path parameter is longer than the system-defined maximum length.</exception>
    string GetDirectoryName(string path);

    /// <summary>
    ///     Returns the extension of a file path that is represented by a read-only character span.
    /// </summary>
    /// <param name="path">The file path from which to get the extension.</param>
    /// <returns>
    ///     The extension of the specified path (including the period, "."), or Empty if path does not have extension
    ///     information.
    /// </returns>
    ReadOnlySpan<char> GetExtension(ReadOnlySpan<char> path);

    /// <summary>
    ///     Returns the extension (including the period ".") of the specified path string.
    /// </summary>
    /// <param name="path">The path string from which to get the extension.</param>
    /// <returns>
    ///     The extension of the specified path (including the period "."), or null, or Empty. If path is null,
    ///     GetExtension(String) returns null. If path does not have extension information, GetExtension(String) returns Empty.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: path contains one or more of
    ///     the invalid characters defined in GetInvalidPathChars().
    /// </exception>
    string GetExtension(string path);

    /// <summary>
    ///     Returns the file name and extension of a file path that is represented by a read-only character span.
    /// </summary>
    /// <param name="path">A read-only span that contains the path from which to obtain the file name and extension.</param>
    /// <returns>The characters after the last directory separator character in path.</returns>
    ReadOnlySpan<char> GetFileName(ReadOnlySpan<char> path);

    /// <summary>
    ///     Returns the file name and extension of the specified path string.
    /// </summary>
    /// <param name="path">The path string from which to obtain the file name and extension.</param>
    /// <returns>
    ///     The characters after the last directory separator character in path. If the last character of path is a
    ///     directory or volume separator character, this method returns Empty. If path is null, this method returns null.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: path contains one or more of
    ///     the invalid characters defined in GetInvalidPathChars().
    /// </exception>
    string GetFileName(string path);

    /// <summary>
    ///     Returns the file name without the extension of a file path that is represented by a read-only character span.
    /// </summary>
    /// <param name="path">A read-only span that contains the path from which to obtain the file name without the extension.</param>
    /// <returns>
    ///     The characters in the read-only span returned by <see cref="GetFileName(System.ReadOnlySpan{char})" />, minus the
    ///     last period (.) and all characters following it.
    /// </returns>
    ReadOnlySpan<char> GetFileNameWithoutExtension(ReadOnlySpan<char> path);

    /// <summary>
    ///     Returns the file name of the specified path string without the extension.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>
    ///     The string returned by <see cref="GetFileName(System.ReadOnlySpan{char})" />, minus the last period (.) and all
    ///     characters following it.
    /// </returns>
    string GetFileNameWithoutExtension(string path);

    /// <summary>
    ///     Returns the absolute path for the specified path string.
    /// </summary>
    /// <param name="path">The file or directory for which to obtain absolute path information.</param>
    /// <returns>The fully qualified location of path, such as "C:\MyFile.txt".</returns>
    /// <exception cref="ArgumentException">
    ///     path is a zero-length string, contains only white space, or contains one or more of the invalid characters defined
    ///     in GetInvalidPathChars().
    ///     -or-
    ///     The system could not retrieve the absolute path.
    /// </exception>
    /// <exception cref="SecurityException">The caller does not have the required permissions.</exception>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    /// <exception cref="NotSupportedException">
    ///     path contains a colon (":") that is not part of a volume identifier (for
    ///     example, "c:\").
    /// </exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    string GetFullPath(string path);

    /// <summary>
    ///     Returns an absolute path from a relative path and a fully qualified base path.
    /// </summary>
    /// <param name="path">A relative path to concatenate to basePath.</param>
    /// <param name="basePath">The beginning of a fully qualified path.</param>
    /// <returns>The absolute path.</returns>
    /// <exception cref="ArgumentNullException">path or basePath is null.</exception>
    /// <exception cref="ArgumentException">
    ///     basePath is not a fully qualified path.
    ///     -or-
    ///     path or basePath contains one or more of the invalid characters defined in GetInvalidPathChars().
    /// </exception>
    string GetFullPath(string path, string basePath);

    /// <summary>
    ///     Gets an array containing the characters that are not allowed in file names.
    /// </summary>
    /// <returns>An array containing the characters that are not allowed in file names.</returns>
    char[] GetInvalidFileNameChars();

    /// <summary>
    ///     Gets an array containing the characters that are not allowed in path names.
    /// </summary>
    /// <returns>An array containing the characters that are not allowed in path names.</returns>
    char[] GetInvalidPathChars();

    /// <summary>
    ///     Gets the root directory information from the path contained in the specified character span.
    /// </summary>
    /// <param name="path">A read-only span of characters containing the path from which to obtain root directory information.</param>
    /// <returns>A read-only span of characters containing the root directory of path.</returns>
    ReadOnlySpan<char> GetPathRoot(ReadOnlySpan<char> path);

    /// <summary>
    ///     Gets the root directory information from the path contained in the specified string.
    /// </summary>
    /// <param name="path">A string containing the path from which to obtain root directory information.</param>
    /// <returns>
    ///     The root directory of path if it is rooted.
    ///     -or-
    ///     Empty if path does not contain root directory information.
    ///     -or-
    ///     null if path is null or is effectively empty.
    /// </returns>
    string GetPathRoot(string path);

    /// <summary>
    ///     Returns a random folder name or file name.
    /// </summary>
    /// <returns>A random folder name or file name.</returns>
    string GetRandomFileName();

    /// <summary>
    ///     Returns a relative path from one path to another.
    /// </summary>
    /// <param name="relativeTo">
    ///     The source path the result should be relative to. This path is always considered to be a
    ///     directory.
    /// </param>
    /// <param name="path">The destination path.</param>
    /// <returns>The relative path, or path if the paths don't share the same root.</returns>
    /// <exception cref="ArgumentNullException">relativeTo or path is null.</exception>
    /// <exception cref="ArgumentException">relativeTo or path is effectively empty.</exception>
    string GetRelativePath(string relativeTo, string path);

    /// <summary>
    ///     Creates a uniquely named, zero-byte temporary file on disk and returns the full path of that file.
    /// </summary>
    /// <returns>The full path of the temporary file.</returns>
    /// <exception cref="IOException">
    ///     An I/O error occurs, such as no unique temporary file name is available.
    ///     -or-
    ///     This method was unable to create a temporary file.
    /// </exception>
    string GetTempFileName();

    /// <summary>
    ///     Returns the path of the current user's temporary folder.
    /// </summary>
    /// <returns>The path to the temporary folder, ending with a DirectorySeparatorChar.</returns>
    /// <exception cref="SecurityException">The caller does not have the required permissions.</exception>
    string GetTempPath();

    /// <summary>
    ///     Determines whether the path represented by the specified character span includes a file name extension.
    /// </summary>
    /// <param name="path">The path to search for an extension.</param>
    /// <returns>
    ///     true if the characters that follow the last directory separator character or volume separator in the path
    ///     include a period (".") followed by one or more characters; otherwise, false.
    /// </returns>
    bool HasExtension(ReadOnlySpan<char> path);

    /// <summary>
    ///     Determines whether a path includes a file name extension.
    /// </summary>
    /// <param name="path">The path to search for an extension.</param>
    /// <returns>
    ///     true if the characters that follow the last directory separator (\ or /) or volume separator (:) in the path
    ///     include a period (.) followed by one or more characters; otherwise, false.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: path contains one or more of
    ///     the invalid characters defined in GetInvalidPathChars().
    /// </exception>
    bool HasExtension(string path);

    /// <summary>
    ///     Returns a value indicating whether the specified path string contains a root.
    /// </summary>
    /// <param name="path">The path to test.</param>
    /// <returns>true if path contains a root; otherwise, false.</returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: path contains one or more of
    ///     the invalid characters defined in GetInvalidPathChars().
    /// </exception>
    bool IsPathRooted(string path);

    /// <summary>
    ///     Returns a value that indicates whether the path, specified as a read-only span, ends in a directory separator.
    /// </summary>
    /// <param name="path">The path to analyze.</param>
    /// <returns>true if the path ends in a directory separator; otherwise, false.</returns>
    bool EndsInDirectorySeparator(ReadOnlySpan<char> path);

    /// <summary>
    ///     Returns the directory information for the specified path.
    /// </summary>
    /// <param name="path">The path of a file or directory.</param>
    /// <returns>
    ///     Directory information for path, or null if path denotes a root directory or is null. Returns Empty if path
    ///     does not contain directory information.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: The path parameter contains
    ///     invalid characters, is empty, or contains only white spaces.
    /// </exception>
    /// <exception cref="PathTooLongException">The path parameter is longer than the system-defined maximum length.</exception>
    ReadOnlySpan<char> GetDirectoryName(ReadOnlySpan<char> path);

    /// <summary>
    ///     Returns a value that indicates whether the file path represented by the specified character span is fixed to a
    ///     specific drive or UNC path.
    /// </summary>
    /// <param name="path">A file path.</param>
    /// <returns>
    ///     true if the path is fixed to a specific drive or UNC path; false if the path is relative to the current drive
    ///     or working directory.
    /// </returns>
    bool IsPathFullyQualified(ReadOnlySpan<char> path);

    /// <summary>
    ///     Returns a value that indicates whether the specified file path is fixed to a specific drive or UNC path.
    /// </summary>
    /// <param name="path">A file path.</param>
    /// <returns>
    ///     true if the path is fixed to a specific drive or UNC path; false if the path is relative to the current drive
    ///     or working directory.
    /// </returns>
    /// <exception cref="ArgumentNullException">path is null.</exception>
    bool IsPathFullyQualified(string path);

    /// <summary>
    ///     Returns a value that indicates whether the specified character span that represents a file path contains a root.
    /// </summary>
    /// <param name="path">The path to test.</param>
    /// <returns>true if path contains a root; otherwise, false.</returns>
    bool IsPathRooted(ReadOnlySpan<char> path);

    /// <summary>
    ///     Concatenates two path components into a single path.
    /// </summary>
    /// <param name="path1">A character span that contains the first path to join.</param>
    /// <param name="path2">A character span that contains the second path to join.</param>
    /// <returns>The combined paths.</returns>
    string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2);

    /// <summary>
    ///     Concatenates three path components into a single path.
    /// </summary>
    /// <param name="path1">A character span that contains the first path to join.</param>
    /// <param name="path2">A character span that contains the second path to join.</param>
    /// <param name="path3">A character span that contains the third path to join.</param>
    /// <returns>The concatenated path.</returns>
    string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3);

    /// <summary>
    ///     Concatenates four path components into a single path.
    /// </summary>
    /// <param name="path1">A character span that contains the first path to join.</param>
    /// <param name="path2">A character span that contains the second path to join.</param>
    /// <param name="path3">A character span that contains the third path to join.</param>
    /// <param name="path4">A character span that contains the fourth path to join.</param>
    /// <returns>The concatenated path.</returns>
    string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, string path3, ReadOnlySpan<char> path4);

    /// <summary>
    ///     Concatenates an array of paths into a single path.
    /// </summary>
    /// <param name="paths">An array of paths.</param>
    /// <returns>The concatenated path.</returns>
    string Join(params string[] paths);

    /// <summary>
    ///     Concatenates two paths into a single path.
    /// </summary>
    /// <param name="path1">The first path to join.</param>
    /// <param name="path2">The second path to join.</param>
    /// <returns>The concatenated path.</returns>
    string Join(string path1, string path2);

    /// <summary>
    ///     Concatenates three paths into a single path.
    /// </summary>
    /// <param name="path1">The first path to join.</param>
    /// <param name="path2">The second path to join.</param>
    /// <param name="path3">The third path to join.</param>
    /// <returns>The concatenated path.</returns>
    string Join(string path1, string path2, string path3);

    /// <summary>
    ///     Concatenates four paths into a single path.
    /// </summary>
    /// <param name="path1">The first path to join.</param>
    /// <param name="path2">The second path to join.</param>
    /// <param name="path3">The third path to join.</param>
    /// <param name="path4">The fourth path to join.</param>
    /// <returns>The concatenated path.</returns>
    string Join(string path1, string path2, string path3, string path4);

    /// <summary>
    ///     Trims one trailing directory separator beyond the root of the specified path.
    /// </summary>
    /// <param name="path">The path to trim.</param>
    /// <returns>The path without any trailing directory separators.</returns>
    ReadOnlySpan<char> TrimEndingDirectorySeparator(ReadOnlySpan<char> path);

    /// <summary>
    ///     Trims one trailing directory separator beyond the root of the specified path.
    /// </summary>
    /// <param name="path">The path to trim.</param>
    /// <returns>The path without any trailing directory separators.</returns>
    string TrimEndingDirectorySeparator(string path);

    /// <summary>
    ///     Attempts to concatenate two path components to a single preallocated character span, and returns a value that
    ///     indicates whether the operation succeeded.
    /// </summary>
    /// <param name="path1">A character span that contains the first path to join.</param>
    /// <param name="path2">A character span that contains the second path to join.</param>
    /// <param name="destination">A character span to hold the concatenated path.</param>
    /// <param name="charsWritten">
    ///     When the method returns, a value that indicates the number of characters written to the
    ///     destination.
    /// </param>
    /// <returns>true if the concatenation operation is successful; otherwise, false.</returns>
    bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, Span<char> destination, out int charsWritten);

    /// <summary>
    ///     Attempts to concatenate two path components to a single preallocated character span, and returns a value that
    ///     indicates whether the operation succeeded.
    /// </summary>
    /// <param name="path1">A character span that contains the first path to join.</param>
    /// <param name="path2">A character span that contains the second path to join.</param>
    /// <param name="path3">A character span that contains the third path to join.</param>
    /// <param name="destination">A character span to hold the concatenated path.</param>
    /// <param name="charsWritten">
    ///     When the method returns, a value that indicates the number of characters written to the
    ///     destination.
    /// </param>
    /// <returns>true if the concatenation operation is successful; otherwise, false.</returns>
    bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, Span<char> destination, out int charsWritten);
}
﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="PathWrapper.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.IO;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.FileSystems;

/// <summary>
///     Performs operations on String instances that contain file or directory path information. These operations are
///     performed in a cross-platform manner.
/// </summary>
public sealed class PathWrapper : IPath
{
    /// <inheritdoc />
    public char AltDirectorySeparatorChar => Path.AltDirectorySeparatorChar;

    /// <inheritdoc />
    public char DirectorySeparatorChar => Path.DirectorySeparatorChar;

    /// <inheritdoc />
    public char PathSeparator => Path.PathSeparator;

    /// <inheritdoc />
    public char VolumeSeparatorChar => Path.VolumeSeparatorChar;

    /// <inheritdoc />
    public string ChangeExtension(string path, string extension)
    {
        return Path.ChangeExtension(path, extension);
    }

    /// <inheritdoc />
    public string Combine(params string[] paths)
    {
        return Path.Combine(paths);
    }

    /// <inheritdoc />
    public string Combine(string path1, string path2)
    {
        return Path.Combine(path1, path2);
    }

    /// <inheritdoc />
    public string Combine(string path1, string path2, string path3)
    {
        return Path.Combine(path1, path2, path3);
    }

    /// <inheritdoc />
    public string Combine(string path1, string path2, string path3, string path4)
    {
        return Path.Combine(path1, path2, path3, path4);
    }

    /// <inheritdoc />
    public string GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> GetExtension(ReadOnlySpan<char> path)
    {
        return Path.GetExtension(path);
    }

    /// <inheritdoc />
    public string GetExtension(string path)
    {
        return Path.GetExtension(path);
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> GetFileName(ReadOnlySpan<char> path)
    {
        return Path.GetFileName(path);
    }

    /// <inheritdoc />
    public string GetFileName(string path)
    {
        return Path.GetFileName(path);
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> GetFileNameWithoutExtension(ReadOnlySpan<char> path)
    {
        return Path.GetFileNameWithoutExtension(path);
    }

    /// <inheritdoc />
    public string GetFileNameWithoutExtension(string path)
    {
        return Path.GetFileNameWithoutExtension(path);
    }

    /// <inheritdoc />
    public string GetFullPath(string path)
    {
        return Path.GetFullPath(path);
    }

    /// <inheritdoc />
    public string GetFullPath(string path, string basePath)
    {
        return Path.GetFullPath(path, basePath);
    }

    /// <inheritdoc />
    public char[] GetInvalidFileNameChars()
    {
        return Path.GetInvalidFileNameChars();
    }

    /// <inheritdoc />
    public char[] GetInvalidPathChars()
    {
        return Path.GetInvalidPathChars();
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> GetPathRoot(ReadOnlySpan<char> path)
    {
        return Path.GetPathRoot(path);
    }

    /// <inheritdoc />
    public string GetPathRoot(string path)
    {
        return Path.GetPathRoot(path);
    }

    /// <inheritdoc />
    public string GetRandomFileName()
    {
        return Path.GetRandomFileName();
    }

    /// <inheritdoc />
    public string GetRelativePath(string relativeTo, string path)
    {
        return Path.GetRelativePath(relativeTo, path);
    }

    /// <inheritdoc />
    public string GetTempFileName()
    {
        return Path.GetTempFileName();
    }

    /// <inheritdoc />
    public string GetTempPath()
    {
        return Path.GetTempPath();
    }

    /// <inheritdoc />
    public bool HasExtension(ReadOnlySpan<char> path)
    {
        return Path.HasExtension(path);
    }

    /// <inheritdoc />
    public bool HasExtension(string path)
    {
        return Path.HasExtension(path);
    }

    /// <inheritdoc />
    public bool IsPathRooted(string path)
    {
        return Path.IsPathRooted(path);
    }

    /// <inheritdoc />
    public bool EndsInDirectorySeparator(ReadOnlySpan<char> path)
    {
        return Path.EndsInDirectorySeparator(path);
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> GetDirectoryName(ReadOnlySpan<char> path)
    {
        return Path.GetDirectoryName(path);
    }

    /// <inheritdoc />
    public bool IsPathFullyQualified(ReadOnlySpan<char> path)
    {
        return Path.IsPathFullyQualified(path);
    }

    /// <inheritdoc />
    public bool IsPathFullyQualified(string path)
    {
        return Path.IsPathFullyQualified(path);
    }

    /// <inheritdoc />
    public bool IsPathRooted(ReadOnlySpan<char> path)
    {
        return Path.IsPathRooted(path);
    }

    /// <inheritdoc />
    public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2)
    {
        return Path.Join(path1, path2);
    }

    /// <inheritdoc />
    public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3)
    {
        return Path.Join(path1, path2, path3);
    }

    /// <inheritdoc />
    public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, string path3, ReadOnlySpan<char> path4)
    {
        return Path.Join(path1, path2, path3, path4);
    }

    /// <inheritdoc />
    public string Join(params string[] paths)
    {
        return Path.Join(paths);
    }

    /// <inheritdoc />
    public string Join(string path1, string path2)
    {
        return Path.Join(path1, path2);
    }

    /// <inheritdoc />
    public string Join(string path1, string path2, string path3)
    {
        return Path.Join(path1, path2, path3);
    }

    /// <inheritdoc />
    public string Join(string path1, string path2, string path3, string path4)
    {
        return Path.Join(path1, path2, path3, path4);
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> TrimEndingDirectorySeparator(ReadOnlySpan<char> path)
    {
        return Path.TrimEndingDirectorySeparator(path);
    }

    /// <inheritdoc />
    public string TrimEndingDirectorySeparator(string path)
    {
        return Path.TrimEndingDirectorySeparator(path);
    }

    /// <inheritdoc />
    public bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, Span<char> destination, out int charsWritten)
    {
        return Path.TryJoin(path1, path2, destination, out charsWritten);
    }

    /// <inheritdoc />
    public bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, Span<char> destination, out int charsWritten)
    {
        return Path.TryJoin(path1, path2, path3, destination, out charsWritten);
    }
}
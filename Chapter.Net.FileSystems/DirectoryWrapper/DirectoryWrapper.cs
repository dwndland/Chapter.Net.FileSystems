// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DirectoryWrapper.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.FileSystems;

/// <summary>
///     Exposes static methods for creating, moving, and enumerating through directories and subdirectories. This class
///     cannot be inherited.
/// </summary>
public sealed class DirectoryWrapper : IDirectory
{
    /// <inheritdoc />
    public void Copy(string sourceDirName, string destDirName)
    {
        DirectoryEx.Copy(sourceDirName, destDirName);
    }

    /// <inheritdoc />
    public void Copy(string sourceDirName, string destDirName, bool overwrite)
    {
        DirectoryEx.Copy(sourceDirName, destDirName, overwrite);
    }

    /// <inheritdoc />
    public DirectoryInfo CreateDirectory(string path)
    {
        return Directory.CreateDirectory(path);
    }

    /// <inheritdoc />
    public void Delete(string path)
    {
        Directory.Delete(path);
    }

    /// <inheritdoc />
    public void Delete(string path, bool recursive)
    {
        Directory.Delete(path, recursive);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateDirectories(string path)
    {
        return Directory.EnumerateDirectories(path);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateDirectories(string path, string searchPattern)
    {
        return Directory.EnumerateDirectories(path, searchPattern);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions)
    {
        return Directory.EnumerateDirectories(path, searchPattern, enumerationOptions);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption)
    {
        return Directory.EnumerateDirectories(path, searchPattern, searchOption);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateFiles(string path)
    {
        return Directory.EnumerateFiles(path);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateFiles(string path, string searchPattern)
    {
        return Directory.EnumerateFiles(path, searchPattern);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateFiles(string path, string searchPattern, EnumerationOptions enumerationOptions)
    {
        return Directory.EnumerateFiles(path, searchPattern, enumerationOptions);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
    {
        return Directory.EnumerateFiles(path, searchPattern, searchOption);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateFileSystemEntries(string path)
    {
        return Directory.EnumerateFileSystemEntries(path);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern)
    {
        return Directory.EnumerateFileSystemEntries(path, searchPattern);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions)
    {
        return Directory.EnumerateFileSystemEntries(path, searchPattern, enumerationOptions);
    }

    /// <inheritdoc />
    public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
    {
        return Directory.EnumerateFileSystemEntries(path, searchPattern, searchOption);
    }

    /// <inheritdoc />
    public bool Exists(string path)
    {
        return Directory.Exists(path);
    }

    /// <inheritdoc />
    public DateTime GetCreationTime(string path)
    {
        return Directory.GetCreationTime(path);
    }

    /// <inheritdoc />
    public DateTime GetCreationTimeUtc(string path)
    {
        return Directory.GetCreationTimeUtc(path);
    }

    /// <inheritdoc />
    public string GetCurrentDirectory()
    {
        return Directory.GetCurrentDirectory();
    }

    /// <inheritdoc />
    public string[] GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    /// <inheritdoc />
    public string[] GetDirectories(string path, string searchPattern)
    {
        return Directory.GetDirectories(path, searchPattern);
    }

    /// <inheritdoc />
    public string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions)
    {
        return Directory.GetDirectories(path, searchPattern, enumerationOptions);
    }

    /// <inheritdoc />
    public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
    {
        return Directory.GetDirectories(path, searchPattern, searchOption);
    }

    /// <inheritdoc />
    public string GetDirectoryRoot(string path)
    {
        return Directory.GetDirectoryRoot(path);
    }

    /// <inheritdoc />
    public string[] GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }

    /// <inheritdoc />
    public string[] GetFiles(string path, string searchPattern)
    {
        return Directory.GetFiles(path, searchPattern);
    }

    /// <inheritdoc />
    public string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions)
    {
        return Directory.GetFiles(path, searchPattern, enumerationOptions);
    }

    /// <inheritdoc />
    public string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
    {
        return Directory.GetFiles(path, searchPattern, searchOption);
    }

    /// <inheritdoc />
    public string[] GetFileSystemEntries(string path)
    {
        return Directory.GetFileSystemEntries(path);
    }

    /// <inheritdoc />
    public string[] GetFileSystemEntries(string path, string searchPattern)
    {
        return Directory.GetFileSystemEntries(path, searchPattern);
    }

    /// <inheritdoc />
    public string[] GetFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions)
    {
        return Directory.GetFileSystemEntries(path, searchPattern, enumerationOptions);
    }

    /// <inheritdoc />
    public string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
    {
        return Directory.GetFileSystemEntries(path, searchPattern, searchOption);
    }

    /// <inheritdoc />
    public DateTime GetLastAccessTime(string path)
    {
        return Directory.GetLastAccessTime(path);
    }

    /// <inheritdoc />
    public DateTime GetLastAccessTimeUtc(string path)
    {
        return Directory.GetLastAccessTimeUtc(path);
    }

    /// <inheritdoc />
    public DateTime GetLastWriteTime(string path)
    {
        return Directory.GetLastWriteTime(path);
    }

    /// <inheritdoc />
    public DateTime GetLastWriteTimeUtc(string path)
    {
        return Directory.GetLastWriteTimeUtc(path);
    }

    /// <inheritdoc />
    public string[] GetLogicalDrives()
    {
        return Directory.GetLogicalDrives();
    }

    /// <inheritdoc />
    public DirectoryInfo GetParent(string path)
    {
        return Directory.GetParent(path);
    }

    /// <inheritdoc />
    public void Move(string sourceDirName, string destDirName)
    {
        DirectoryEx.Move(sourceDirName, destDirName);
    }

    /// <inheritdoc />
    public void Move(string sourceDirName, string destDirName, bool overwrite)
    {
        DirectoryEx.Move(sourceDirName, destDirName, overwrite);
    }

    /// <inheritdoc />
    public void SetCreationTime(string path, DateTime creationTime)
    {
        Directory.SetCreationTime(path, creationTime);
    }

    /// <inheritdoc />
    public void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
    {
        Directory.SetCreationTimeUtc(path, creationTimeUtc);
    }

    /// <inheritdoc />
    public void SetLastAccessTime(string path, DateTime lastAccessTime)
    {
        Directory.SetLastAccessTime(path, lastAccessTime);
    }

    /// <inheritdoc />
    public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
    {
        Directory.SetLastAccessTimeUtc(path, lastAccessTimeUtc);
    }

    /// <inheritdoc />
    public void SetLastWriteTime(string path, DateTime lastWriteTime)
    {
        Directory.SetLastWriteTime(path, lastWriteTime);
    }

    /// <inheritdoc />
    public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
    {
        Directory.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
    }
}
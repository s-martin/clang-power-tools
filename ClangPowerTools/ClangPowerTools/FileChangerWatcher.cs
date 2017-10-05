﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangPowerTools
{
  public class FileChangerWatcher
  {
    #region Members

    FileSystemWatcher mWatcher = new FileSystemWatcher();

    #endregion

    #region Properties

    public FileSystemEventHandler OnChanged { get; set; }

    #endregion

    #region Public methods

    public void Run(string aDirectoryPath)
    {
      if (null == aDirectoryPath || string.IsNullOrWhiteSpace(aDirectoryPath))
        return;

      // Set the path property of FileSystemWatcher
      mWatcher.Path = aDirectoryPath;

      // Watch for changes in LastWrite time
      mWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;

      // Only watch .cpp files.
      mWatcher.Filter = "*.cpp";

      //Subdirectories will be also watched.
      mWatcher.IncludeSubdirectories = true;

      // Watch every file in the directory for changes
      mWatcher.Changed += OnChanged;
      mWatcher.Deleted += OnChanged;

      // Begin watching.
      mWatcher.EnableRaisingEvents = true;
    }

    #endregion

  }
}

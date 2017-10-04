using System;
using System.Collections.Generic;

namespace ClangPowerTools
{
  public class SilentFileChangerGuard : SilentFileChanger, IDisposable
  {
    #region Members

    private List<SilentFileChanger> mFileChangers = new List<SilentFileChanger>();

    #endregion

    #region Public methods

    public SilentFileChangerGuard() { }

    public SilentFileChangerGuard(IServiceProvider aSite, string aDocument, bool aReloadDocument)
      : base(aSite, aDocument, aReloadDocument) => Suspend();

    public void Add(SilentFileChanger aFileChanger)
    {
      aFileChanger.Suspend();
      mFileChangers.Add(aFileChanger);
    }

    public void Dispose()
    {
      foreach (SilentFileChanger file in mFileChangers)
        file.Resume();
      Resume();
    }
    #endregion
  }
}

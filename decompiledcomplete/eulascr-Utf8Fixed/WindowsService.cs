// Decompiled with JetBrains decompiler
// Type: WindowsService
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\AgileStringDecryptor-master\bin\Debug\net48\eulascr-Utf8Fixed.exe

using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text.RegularExpressions;

internal class WindowsService
{
  private static Regex _fileNameRegex;

  public string DisplayName
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
    [MethodImpl(MethodImplOptions.NoInlining)] private set
    {
    }
  }

  public string Name
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
    [MethodImpl(MethodImplOptions.NoInlining)] private set
    {
    }
  }

  public string CommandLine
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
    [MethodImpl(MethodImplOptions.NoInlining)] private set
    {
    }
  }

  public FileInfo Executable
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (FileInfo) null;
    [MethodImpl(MethodImplOptions.NoInlining)] private set
    {
    }
  }

  public FileVersionInfo Version
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (FileVersionInfo) null;
    [MethodImpl(MethodImplOptions.NoInlining)] private set
    {
    }
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public WindowsService(ServiceController service)
  {
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override string ToString() => (string) null;

    static WindowsService()
    {
        AgileDotNetRT.Initialize();
        AgileDotNetRT.PostInitialize();

        // Şifreli dizgenin çözülmüş hali
        string pattern = "*5G\x15A\x19<Uw C&\bs}.&\x1E4W(#f\x0E}&";
        _fileNameRegex = new Regex(AgileDotNetRT.oRM(pattern), RegexOptions.IgnoreCase);
    }
}

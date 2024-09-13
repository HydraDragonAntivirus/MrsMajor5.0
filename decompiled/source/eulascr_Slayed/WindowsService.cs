// Decompiled with JetBrains decompiler
// Type: WindowsService
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\decompiled\eulascr_Slayed.exe

using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text.RegularExpressions;

internal class WindowsService
{
  private static Regex _fileNameRegex = new Regex("((?<name>[A-Z]:.+?(\\.exe|\\Z))|(?:\"(?<name>.+?)\"))", RegexOptions.IgnoreCase);

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
}

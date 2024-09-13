// Decompiled with JetBrains decompiler
// Type: QEmuMachine
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Downloads\Release-1.0\eulascr-cleanstrings.exe

using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
internal class QEmuMachine : BaseVirtualEnvironment
{
  public override string Name
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override bool ContainsDisk(IEnumerable<DiskDrive> disks) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public QEmuMachine()
  {
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  static QEmuMachine()
  {
    \u003CAgileDotNetRT\u003E.Initialize();
    \u003CAgileDotNetRT\u003E.PostInitialize();
  }
}

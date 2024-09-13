// Decompiled with JetBrains decompiler
// Type: BIOS
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\decompiled\eulascr_Slayed.exe

using System.Collections.Generic;
using System.Management;
using System.Runtime.CompilerServices;

internal class BIOS : BaseWin32Entity
{
  public IEnumerable<BiosCharacteristics> Characteristics
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (IEnumerable<BiosCharacteristics>) null;
    [MethodImpl(MethodImplOptions.NoInlining)] private set
    {
    }
  }

  public string SerialNumber
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
    [MethodImpl(MethodImplOptions.NoInlining)] private set
    {
    }
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public BIOS(ManagementBaseObject obj)
    : base((ManagementBaseObject) null)
  {
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override string ToString() => (string) null;

  [MethodImpl(MethodImplOptions.NoInlining)]
  static BIOS()
  {
  }
}

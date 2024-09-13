// Decompiled with JetBrains decompiler
// Type: BiosCharacteristics
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Downloads\Release-1.0\eulascr-cleanstrings.exe

#nullable disable
internal enum BiosCharacteristics : ushort
{
  Reserved0 = 0,
  Reserved1 = 1,
  Unknown = 2,
  BIOS_Characteristics_Not_Supported = 3,
  ISA_is_supported = 4,
  MCA_is_supported = 5,
  EISA_is_supported = 6,
  PCI_is_supported = 7,
  PC_Card_PCMCIA_is_supported = 8,
  Plug_and_Play_is_supported = 9,
  APM_is_supported = 10, // 0x000A
  BIOS_is_Upgradeable_Flash = 11, // 0x000B
  BIOS_shadowing_is_allowed = 12, // 0x000C
  VL_VESA_is_supported = 13, // 0x000D
  ESCD_support_is_available = 14, // 0x000E
  Boot_from_CD_is_supported = 15, // 0x000F
  Selectable_Boot_is_supported = 16, // 0x0010
  BIOS_ROM_is_socketed = 17, // 0x0011
  Boot_From_PC_Card_PCMCIA_is_supported = 18, // 0x0012
  EDD_Enhanced_Disk_Drive_Specification_is_supported = 19, // 0x0013
  Int_13h_Japanese_Floppy_for_NEC_9800_is_supported = 20, // 0x0014
  Int_13h_Japanese_Floppy_for_Toshiba_is_supported = 21, // 0x0015
  Int_13h_5_25_360_KB_Floppy_Services_are_supported = 22, // 0x0016
  Int_13h_5_25_1_2MB_Floppy_Services_are_supported = 23, // 0x0017
  Int_13h_3_5_720_KB_Floppy_Services_are_supported = 24, // 0x0018
  Int_13h_3_5_2_88_MB_Floppy_Services_are_supported = 25, // 0x0019
  Int_5h_Print_Screen_Service_is_supported = 26, // 0x001A
  Int_9h_8042_Keyboard_services_are_supported = 27, // 0x001B
  Int_14h_Serial_Services_are_supported = 28, // 0x001C
  Int_17h_printer_services_are_supported = 29, // 0x001D
  Int_10h_CGA_Mono_Video_Services_are_supported = 30, // 0x001E
  NEC_PC_98 = 31, // 0x001F
  ACPI_supported = 32, // 0x0020
  USB_Legacy_is_supported = 33, // 0x0021
  AGP_is_supported = 34, // 0x0022
  I2O_boot_is_supported = 35, // 0x0023
  LS120_boot_is_supported = 36, // 0x0024
  ATAPI_ZIP_Drive_boot_is_supported = 37, // 0x0025
  Firewire_1394_boot_is_supported = 38, // 0x0026
  Smart_Battery_supported = 39, // 0x0027
  Reserved_Bios_Vendor_1 = 40, // 0x0028
  Reserved_Bios_Vendor_2 = 41, // 0x0029
  Reserved_Bios_Vendor_3 = 42, // 0x002A
  Reserved_Bios_Vendor_4 = 43, // 0x002B
  Reserved_Bios_Vendor_5 = 44, // 0x002C
  Reserved_Bios_Vendor_6 = 45, // 0x002D
  Reserved_Bios_Vendor_7 = 46, // 0x002E
  Reserved_System_Vendor_1 = 48, // 0x0030
  Reserved_System_Vendor_2 = 49, // 0x0031
  Reserved_System_Vendor_3 = 50, // 0x0032
  Reserved_System_Vendor_4 = 51, // 0x0033
  Reserved_System_Vendor_5 = 52, // 0x0034
  Reserved_System_Vendor_6 = 53, // 0x0035
  Reserved_System_Vendor_7 = 54, // 0x0036
  Reserved_System_Vendor_8 = 55, // 0x0037
  Reserved_System_Vendor_9 = 56, // 0x0038
  Reserved_System_Vendor_10 = 57, // 0x0039
  Reserved_System_Vendor_11 = 58, // 0x003A
  Reserved_System_Vendor_12 = 59, // 0x003B
  Reserved_System_Vendor_13 = 60, // 0x003C
  Reserved_System_Vendor_14 = 61, // 0x003D
  Reserved_System_Vendor_15 = 62, // 0x003E
  Reserved_System_Vendor_16 = 63, // 0x003F
}

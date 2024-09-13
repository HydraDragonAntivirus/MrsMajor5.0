// Decompiled with JetBrains decompiler
// Type: <AgileDotNetRT>
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Downloads\Release-1.0\eulascr-cleanstrings.exe

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

#nullable disable
[SecuritySafeCritical]
internal class \u003CAgileDotNetRT\u003E
{
  private static byte[] pRM\u003D;
  private static Hashtable sc = new Hashtable();
  private static bool inited;
  private static Assembly runtimeAssembly;

  [MethodImpl(MethodImplOptions.NoInlining)]
  static \u003CAgileDotNetRT\u003E()
  {
    \u003CAgileDotNetRT\u003E.pRM\u003D = new byte[114]
    {
      (byte) 2,
      (byte) 29,
      (byte) 120,
      (byte) 230,
      (byte) 123,
      (byte) 164,
      (byte) 44,
      (byte) 124,
      (byte) 147,
      (byte) 103,
      (byte) 190,
      (byte) 134,
      (byte) 156,
      (byte) 8,
      (byte) 224,
      (byte) 89,
      (byte) 211,
      (byte) 31,
      (byte) 107,
      (byte) 122,
      (byte) 38,
      (byte) 157,
      (byte) 233,
      (byte) 186,
      (byte) 15,
      (byte) 252,
      (byte) 39,
      (byte) 195,
      (byte) 7,
      (byte) 149,
      (byte) 188,
      (byte) 204,
      (byte) 28,
      (byte) 60,
      (byte) 192,
      (byte) 11,
      (byte) 107,
      (byte) 173,
      (byte) 185,
      (byte) 69,
      (byte) 70,
      (byte) 137,
      (byte) 72,
      (byte) 37,
      (byte) 66,
      (byte) 234,
      (byte) 4,
      (byte) 191,
      (byte) 163,
      (byte) 217,
      (byte) 99,
      (byte) 231,
      (byte) 62,
      (byte) 196,
      (byte) 147,
      (byte) 99,
      (byte) 51,
      (byte) 189,
      (byte) 215,
      (byte) 126,
      (byte) 125,
      (byte) 104,
      (byte) 116,
      (byte) 253,
      (byte) 169,
      (byte) 240,
      (byte) 106,
      (byte) 96,
      (byte) 70,
      (byte) 213,
      (byte) 237,
      (byte) 38,
      (byte) 100,
      (byte) 37,
      (byte) 52,
      (byte) 155,
      (byte) 84,
      (byte) 195,
      (byte) 119,
      (byte) 36,
      (byte) 247,
      (byte) 103,
      (byte) 31,
      (byte) 44,
      (byte) 49,
      (byte) 212,
      (byte) 142,
      (byte) 86,
      (byte) 167,
      (byte) 93,
      (byte) 214,
      (byte) 172,
      (byte) 212,
      (byte) 59,
      (byte) 199,
      (byte) 220,
      (byte) 21,
      (byte) 74,
      (byte) 123,
      (byte) 80,
      (byte) 127,
      (byte) 163,
      (byte) 120,
      (byte) 205,
      (byte) 235,
      (byte) 61,
      (byte) 130,
      (byte) 24,
      (byte) 144,
      (byte) 247,
      (byte) 14,
      (byte) 111,
      (byte) 69,
      (byte) 179
    };
  }

  internal static string oRM\u003D([In] string obj0)
  {
    Hashtable sc;
    矇.jgAAAA\u003D\u003D((object) (sc = \u003CAgileDotNetRT\u003E.sc));
    try
    {
      if (瞬.iwAAAA\u003D\u003D\u0025((object) \u003CAgileDotNetRT\u003E.sc, (object) obj0))
        return (string) 矈.jAAAAA\u003D\u003D\u0025((object) \u003CAgileDotNetRT\u003E.sc, (object) obj0);
      StringBuilder stringBuilder1 = new StringBuilder();
      for (int index = 0; index < obj0.Length; ++index)
      {
        StringBuilder stringBuilder2 = 矊.QgAAAA\u003D\u003D\u0025((object) stringBuilder1, 矉.WgAAAA\u003D\u003D((int) obj0[index] ^ (int) \u003CAgileDotNetRT\u003E.pRM\u003D[index % \u003CAgileDotNetRT\u003E.pRM\u003D.Length]));
      }
      矋.jQAAAA\u003D\u003D\u0025((object) \u003CAgileDotNetRT\u003E.sc, (object) obj0, (object) 瞍.AQAAAA\u003D\u003D\u0025((object) stringBuilder1));
      return 瞍.AQAAAA\u003D\u003D\u0025((object) stringBuilder1);
    }
    finally
    {
      矇.jwAAAA\u003D\u003D((object) sc);
    }
  }

  [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
  [MethodImpl(MethodImplOptions.ForwardRef)]
  private static extern IntPtr LoadLibraryA([In] string obj0);

  [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
  [MethodImpl(MethodImplOptions.ForwardRef)]
  private static extern IntPtr GetProcAddress([In] IntPtr obj0, [In] string obj1);

  [DllImport("AgileDotNetRT.dll", CharSet = CharSet.Ansi)]
  [MethodImpl(MethodImplOptions.ForwardRef)]
  private static extern int _Initialize([In] IntPtr obj0);

  [DllImport("AgileDotNetRT64.dll", CharSet = CharSet.Ansi)]
  [MethodImpl(MethodImplOptions.ForwardRef)]
  private static extern int _Initialize64([In] IntPtr obj0);

  [DllImport("AgileDotNetRT.dll", CharSet = CharSet.Ansi)]
  [MethodImpl(MethodImplOptions.ForwardRef)]
  private static extern void _AtExit();

  [DllImport("AgileDotNetRT64.dll", EntryPoint = "_AtExit", CharSet = CharSet.Ansi)]
  [MethodImpl(MethodImplOptions.ForwardRef)]
  private static extern void _AtExit64();

  internal static IntPtr Load()
  {
    Type type;
    // ISSUE: type reference
    矇.jgAAAA\u003D\u003D((object) (type = 瞰.MgAAAA\u003D\u003D(__typeref (\u003CAgileDotNetRT\u003E))));
    try
    {
      WindowsImpersonationContext impersonationContext;
      try
      {
        impersonationContext = WindowsIdentity.Impersonate(IntPtr.Zero);
        Assembly assembly = 瞩.BQAAAA\u003D\u003D();
        string name;
        string str1;
        if (矌.lgAAAA\u003D\u003D() == 4)
        {
          name = "d030ea86-a65f-4973-bac9-d77cf1987632";
          str1 = "AgileDotNetRT";
        }
        else
        {
          name = "5a530dfd-bc51-4992-a05d-f09d41a331d4";
          str1 = "AgileDotNetRT64";
        }
        BinaryReader binaryReader = new BinaryReader((Stream) new GZipStream(assembly.GetManifestResourceStream(name), CompressionMode.Decompress));
        byte[] numArray = 矍.kAAAAA\u003D\u003D\u0025((object) binaryReader, 瞓.kQAAAA\u003D\u003D\u0025((object) binaryReader));
        string str2 = 瞭.JAAAAA\u003D\u003D("{0}{1}\\", (object) 瞥.cwAAAA\u003D\u003D(), (object) name);
        DirectoryInfo directoryInfo = 矎.lwAAAA\u003D\u003D(str2);
        string str3 = 矏.KQAAAA\u003D\u003D(str2, str1, ".dll");
        if (!瞺.gwAAAA\u003D\u003D(str3))
        {
          FileStream fileStream = 矐.hAAAAA\u003D\u003D(str3);
          瞎.UAAAAA\u003D\u003D\u0025((object) fileStream, numArray, 0, numArray.Length);
          瞂.VAAAAA\u003D\u003D\u0025((object) fileStream);
          FileSystemAccessRule systemAccessRule = new FileSystemAccessRule((IdentityReference) new SecurityIdentifier("S-1-1-0"), FileSystemRights.ReadAndExecute, AccessControlType.Allow);
          FileSecurity fileSecurity = 矑.hQAAAA\u003D\u003D(str3);
          矒.mQAAAA\u003D\u003D\u0025((object) fileSecurity, systemAccessRule);
          矓.hgAAAA\u003D\u003D(str3, fileSecurity);
        }
        return \u003CAgileDotNetRT\u003E.LoadLibraryA(str3);
      }
      finally
      {
        impersonationContext.Undo();
      }
    }
    finally
    {
      矇.jwAAAA\u003D\u003D((object) type);
    }
  }

  internal static int InitializeThroughDelegate([In] IntPtr obj0)
  {
    IntPtr procAddress = \u003CAgileDotNetRT\u003E.GetProcAddress(\u003CAgileDotNetRT\u003E.Load(), "_Initialize");
    // ISSUE: type reference
    return ((InitializeDelegate) 矔.mgAAAA\u003D\u003D(procAddress, 瞰.MgAAAA\u003D\u003D(__typeref (InitializeDelegate))))(obj0);
  }

  internal static int InitializeThroughDelegate64([In] IntPtr obj0)
  {
    IntPtr procAddress = \u003CAgileDotNetRT\u003E.GetProcAddress(\u003CAgileDotNetRT\u003E.Load(), "_Initialize64");
    // ISSUE: type reference
    return ((InitializeDelegate) 矔.mgAAAA\u003D\u003D(procAddress, 瞰.MgAAAA\u003D\u003D(__typeref (InitializeDelegate))))(obj0);
  }

  internal static void ExitThroughDelegate()
  {
    IntPtr procAddress = \u003CAgileDotNetRT\u003E.GetProcAddress(\u003CAgileDotNetRT\u003E.Load(), "_AtExit");
    // ISSUE: type reference
    ((ExitDelegate) 矔.mgAAAA\u003D\u003D(procAddress, 瞰.MgAAAA\u003D\u003D(__typeref (ExitDelegate))))();
  }

  internal static void ExitThroughDelegate64()
  {
    IntPtr procAddress = \u003CAgileDotNetRT\u003E.GetProcAddress(\u003CAgileDotNetRT\u003E.Load(), "_AtExit64");
    // ISSUE: type reference
    ((ExitDelegate) 矔.mgAAAA\u003D\u003D(procAddress, 瞰.MgAAAA\u003D\u003D(__typeref (ExitDelegate))))();
  }

  internal static void DomainUnload([In] object obj0, [In] EventArgs obj1)
  {
    if (矌.lgAAAA\u003D\u003D() == 4)
      \u003CAgileDotNetRT\u003E.ExitThroughDelegate();
    else
      \u003CAgileDotNetRT\u003E.ExitThroughDelegate64();
  }

  internal static void Initialize()
  {
    if (\u003CAgileDotNetRT\u003E.inited)
      return;
    RuntimeMethodHandle runtimeMethodHandle = 矗.nwAAAA\u003D\u003D\u0025((object) 矖.ngAAAA\u003D\u003D\u0025((object) 矕.nQAAAA\u003D\u003D\u0025((object) new StackTrace(), 0)));
    if ((矌.lgAAAA\u003D\u003D() != 4 ? \u003CAgileDotNetRT\u003E.InitializeThroughDelegate64(runtimeMethodHandle.Value) : \u003CAgileDotNetRT\u003E.InitializeThroughDelegate(runtimeMethodHandle.Value)) == 1)
      矘.OgAAAA\u003D\u003D\u0025((object) 瞈.OAAAAA\u003D\u003D(), new EventHandler(\u003CAgileDotNetRT\u003E.DomainUnload));
    \u003CAgileDotNetRT\u003E.inited = true;
  }

  internal static void PostInitialize()
  {
  }
}

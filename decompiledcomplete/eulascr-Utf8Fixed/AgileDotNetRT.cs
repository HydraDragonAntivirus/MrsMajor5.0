using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

internal class AgileDotNetRT
{
    private static byte[] pRM = new byte[114]
    {
        2, 29, 120, 230, 123, 164, 44, 124, 147, 103, 190, 134, 156, 8, 224, 89,
        211, 31, 107, 122, 38, 157, 233, 186, 15, 252, 39, 195, 7, 149, 188, 204,
        28, 60, 192, 11, 107, 173, 185, 69, 70, 137, 72, 37, 66, 234, 4, 191,
        163, 217, 99, 231, 62, 196, 147, 99, 51, 189, 215, 126, 125, 104, 116, 253,
        169, 240, 106, 96, 70, 213, 237, 38, 100, 37, 52, 155, 84, 195, 119, 36,
        247, 103, 31, 44, 49, 212, 142, 86, 167, 93, 214, 172, 212, 59, 199, 220,
        21, 74, 123, 80, 127, 163, 120, 205, 235, 61, 130, 24, 144, 247, 14, 111, 69, 179
    };

    private static Hashtable sc = new Hashtable();
    private static bool inited;
    private static Assembly runtimeAssembly;

    // String decryption method
    internal static string oRM(string input)
    {
        lock (sc)
        {
            if (sc.ContainsKey(input))
                return (string)sc[input];

            StringBuilder decryptedString = new StringBuilder();

            for (int index = 0; index < input.Length; ++index)
            {
                decryptedString.Append((char)(input[index] ^ pRM[index % pRM.Length]));
            }

            string result = decryptedString.ToString();
            sc[input] = result;

            return result;
        }
    }

    // Load AgileDotNetRT DLL and perform required initialization
    public static IntPtr Load()
    {
        string resourceName = (IntPtr.Size == 4) ? "AgileDotNetRT" : "AgileDotNetRT64";
        string resourceKey = (IntPtr.Size == 4) ? "d030ea86-a65f-4973-bac9-d77cf1987632" : "5a530dfd-bc51-4992-a05d-f09d41a331d4";

        using (WindowsImpersonationContext impersonationContext = WindowsIdentity.Impersonate(IntPtr.Zero))
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (BinaryReader reader = new BinaryReader(new GZipStream(assembly.GetManifestResourceStream(resourceKey), CompressionMode.Decompress)))
            {
                byte[] dllData = reader.ReadBytes((int)reader.BaseStream.Length);
                string dllPath = Path.Combine(Path.GetTempPath(), resourceKey, resourceName + ".dll");
                Directory.CreateDirectory(Path.GetDirectoryName(dllPath));

                if (!File.Exists(dllPath))
                {
                    File.WriteAllBytes(dllPath, dllData);
                }

                return LoadLibrary(dllPath);
            }
        }
    }

    // Placeholder for LoadLibraryA - implemented in native code
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
    private static extern IntPtr LoadLibrary(string lpFileName);

    // Delegate initialization
    public static int InitializeThroughDelegate(IntPtr obj)
    {
        IntPtr procAddress = GetProcAddress(Load(), "_Initialize");
        var initDelegate = (InitializeDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(InitializeDelegate));
        return initDelegate(obj);
    }

    public static int InitializeThroughDelegate64(IntPtr obj)
    {
        IntPtr procAddress = GetProcAddress(Load(), "_Initialize64");
        var initDelegate = (InitializeDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(InitializeDelegate));
        return initDelegate(obj);
    }

    // Method to unload or terminate
    public static void ExitThroughDelegate()
    {
        IntPtr procAddress = GetProcAddress(Load(), "_AtExit");
        var exitDelegate = (ExitDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(ExitDelegate));
        exitDelegate();
    }

    public static void ExitThroughDelegate64()
    {
        IntPtr procAddress = GetProcAddress(Load(), "_AtExit64");
        var exitDelegate = (ExitDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(ExitDelegate));
        exitDelegate();
    }

    // Handle domain unload event
    public static void DomainUnload(object sender, EventArgs e)
    {
        if (IntPtr.Size == 4)
            ExitThroughDelegate();
        else
            ExitThroughDelegate64();
    }

    // Initialization method
    public static void Initialize()
    {
        if (inited)
            return;

        IntPtr methodHandle = MethodBase.GetCurrentMethod().MethodHandle.Value;

        if ((IntPtr.Size == 4 ? InitializeThroughDelegate(methodHandle) : InitializeThroughDelegate64(methodHandle)) == 1)
        {
            AppDomain.CurrentDomain.DomainUnload += new EventHandler(DomainUnload);
        }

        inited = true;
    }

    public static void PostInitialize()
    {
    }

    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    private delegate int InitializeDelegate(IntPtr obj);
    private delegate void ExitDelegate();
}

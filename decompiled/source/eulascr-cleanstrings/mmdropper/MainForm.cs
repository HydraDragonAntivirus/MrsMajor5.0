// Decompiled with JetBrains decompiler
// Type: mmdropper.MainForm
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Downloads\Release-1.0\eulascr-cleanstrings.exe

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace mmdropper
{
  public class MainForm : Form
  {
    private const int SPI_SETDESKWALLPAPER = 20;
    private const int SPIF_UPDATEINIFILE = 1;
    private const int SPIF_SENDWININICHANGE = 2;
    private string transdata;
    public static string dlink;
    private IContainer components;
    private Button button1;
    private Label label1;
    private TextBox textBox1;
    private Label label2;
    private Timer timer1;
    private Label label3;
    private Label label4;
    private Timer timer2;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public MainForm()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void MainFormLoad(object sender, EventArgs e)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string SHA256(string randomString) => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string Encrypt(string message, string password) => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string Decrypt(string encryptedMessage, string password) => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string strtohex(string input) => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string hextostr(string InputText) => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] FromHex(string hex) => (byte[]) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string readDrive(string uri) => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void win32msg(string winpath, string winmsg, string winico, string winFuncName)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getOSInfo() => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private string getRamInfo() => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private string getDL(string inp) => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void Run()
    {
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static extern int SystemParametersInfo(
      int uAction,
      int uParam,
      string lpvParam,
      int fuWinIni);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Set(string imgPath, MainForm.Style style)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
    {
      return (Assembly) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void Button1Click(object sender, EventArgs e)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void Timer1Tick(object sender, EventArgs e)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void Timer2Tick(object sender, EventArgs e)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected override void Dispose(bool disposing)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void InitializeComponent()
    {
    }

    static MainForm()
    {
      \u003CAgileDotNetRT\u003E.Initialize();
      \u003CAgileDotNetRT\u003E.PostInitialize();
      MainForm.dlink = "";
    }

    public enum Style
    {
      Tiled,
      Centered,
      Stretched,
    }
  }
}

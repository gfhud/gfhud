using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFHUD
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        Process[] MyProcess;
        ProcessModule mainModule;
        ProcessMemoryReader Mem = new ProcessMemoryReader();       
        baseaddress address = new baseaddress();
        offsets off = new offsets();
        int PlayerName;
        int PlayerHp;
        int PlayerHpCap;
        int PlayerMp;
        int PlayerMpCap;
        int PlayerLvl;
        int PlayerBuffCount;
        int Status;
        int PlayerAction;
        int PlayerCombat;
        int PlayerMoney;
        int PlayerCoordX;
        int PlayerCoordY;
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(HandleRef hwnd, out RECT lpRect);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);
        private void cb_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < MyProcess.Length; i++)
                {
                    if (cb_process.SelectedItem.ToString().Contains(MyProcess[i].ProcessName))
                    {
                        MyProcess[0] = Process.GetProcessById(int.Parse(cb_process.Text.Replace(MyProcess[i].ProcessName + "-", "")));
                        mainModule = MyProcess[0].MainModule;
                        Mem.ReadProcess = MyProcess[0];
                        Mem.OpenProcess();
                        timer1.Start();

                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to process " + ex.Message, "Error");
            }
        }

        private void cb_process_MouseClick(object sender, MouseEventArgs e)
        {
            cb_process.Items.Clear();
            MyProcess = Process.GetProcessesByName("GrandFantasia");
            for (int i = 0; i < MyProcess.Length; i++)
            {
                cb_process.Items.Add(MyProcess[i].ProcessName + "-" + MyProcess[i].Id);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PlayerName = Mem.ReadMultiLevelPointer(address.Player, 30, off.PlayerName);
            lb_nick.Text = Mem.ReadString(PlayerName).ToString();

            PlayerLvl = Mem.ReadMultiLevelPointer(address.Player, 4, off.PlayerLvl);
            lb_lvl.Text = Mem.ReadInt(PlayerLvl).ToString();

            PlayerHp = Mem.ReadMultiLevelPointer(address.Player, 4, off.PlayerHp);
            PlayerHpCap = Mem.ReadMultiLevelPointer(address.Player, 4, off.PlayerHpCap);
            pb_hp.Maximum = Mem.ReadInt(PlayerHpCap);
            pb_hp.Value = Mem.ReadInt(PlayerHp);
            lb_hp.Text = Mem.ReadInt(PlayerHp) + "/" + Mem.ReadInt(PlayerHpCap);

            PlayerMp = Mem.ReadMultiLevelPointer(address.Player, 4, off.PlayerMp);
            PlayerMpCap = Mem.ReadMultiLevelPointer(address.Player, 4, off.PlayerMpCap);
            pb_mp.Maximum = Mem.ReadInt(PlayerMpCap);
            pb_mp.Value = Mem.ReadInt(PlayerMp);
            lb_mp.Text = Mem.ReadInt(PlayerMp) + "/" + Mem.ReadInt(PlayerMpCap);

            PlayerCoordX = Mem.ReadMultiLevelPointer(address.Player,4,off.PlayerCoordX);
            PlayerCoordY = Mem.ReadMultiLevelPointer(address.Player, 4, off.PlayerCoordY);
            tb_localizacao.Text = "X.: " + Mem.ReadFloat(PlayerCoordX) + "  Y.: " + Mem.ReadFloat(PlayerCoordY);
        }
    }
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}

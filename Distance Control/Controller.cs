using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WebControlApplication
{
    class Controller
    {
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;

        public const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const int KEYEVENTF_KEYUP = 0x0002;

        private int mouseStep = 1;

        public void CallbackReceivedRun(JObject command)
        {
            string cmd = (string)command["cmd"];

            switch (cmd)
            {
                case "volume-up":
                    keybd_event((byte)Keys.VolumeUp, 0, 0, 0);
                    break;

                case "volume-down":
                    keybd_event((byte)Keys.VolumeDown, 0, 0, 0);
                    break;

                case "volume-mute":
                    keybd_event((byte)Keys.VolumeMute, 0, 0, 0);
                    break;

                case "shutdown":
                    //System.Diagnostics.Process.Start("shutdown", "/s /t 1 /f");
                    break;

                case "reboot":
                    //System.Diagnostics.Process.Start("shutdown", "/g /t 1 /f");
                    break;

                case "play":
                    keybd_event((byte)Keys.MediaPlayPause, 0, 0, 0);
                    break;

                case "key-right":
                    keybd_event((byte)Keys.Right, 0, 0, 0);
                    break;

                case "key-left":
                    keybd_event((byte)Keys.Left, 0, 0, 0);
                    break;

                case "key-next-youtube":
                    keybd_event((byte)Keys.LShiftKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    keybd_event((byte)Keys.N, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    keybd_event((byte)Keys.N, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event((byte)Keys.LShiftKey, 0, KEYEVENTF_KEYUP, 0);
                    break;

                case "mouse-left-click":
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, (UIntPtr)0);
                    Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, (UIntPtr)0);
                    break;

                case "mouse-move":
                    Cursor.Position = new Point(Cursor.Position.X + mouseStep * (int)command["x"], Cursor.Position.Y + mouseStep * (int)command["y"]);
                    break;
            }
        }
        
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
    }
}

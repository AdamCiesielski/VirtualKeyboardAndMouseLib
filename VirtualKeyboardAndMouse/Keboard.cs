using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace VirtualKeyboardAndMouse
{
    public class Keboard
    {
        /*
        TO DO think about special sights
        */
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        #region const
        private const int KEYEVENTF_KEYDOWN = 0x0000; // New definition
        private const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        private const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        private const int VK_LSHIFT = 0xA0; //Left Shift key code
        private const int VK_LCONTROL = 0xA2; //Left Control key code
        private const int VK_ESCAPE = 0x1B;
        private const int VK_RETURN = 0x0D;
        private const int A = 0x41; //A key code
        private const int C = 0x43; //C key code
        private const int SLASH = 0xBF;
        private const int ALT = 0x12;
        private const int F10 = 0x79;
        private const int TAB = 0x09;
        #endregion

        public static void PressKey(char key)
        {
            keybd_event((byte)Char.ToUpper(key), 0, KEYEVENTF_KEYDOWN, 0);
        }
        public static void ReleaseKey(char key)
        {
            keybd_event((byte)Char.ToUpper(key), 0, KEYEVENTF_KEYUP, 0);
        }
        public static void ClickKey(char key)
        {
            PressKey(key);
            ReleaseKey(key);
        }
        public static void PressKey(int key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, 0);
        }
        public static void ReleaseKey(int key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void ClickKey(int key)
        {
            PressKey(key);
            ReleaseKey(key);
        }
        public static void PressShift()
        {
            keybd_event(VK_LSHIFT, 0, KEYEVENTF_KEYDOWN, 0);
        }
        public static void ReleaseShift()
        {
            keybd_event(VK_LSHIFT, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void PressAlt()
        {
            keybd_event(ALT, 0, KEYEVENTF_KEYDOWN, 0);
        }
        public static void PressTab()
        {
            keybd_event(TAB, 0, KEYEVENTF_KEYDOWN, 0);
        }
        public static void ReleaseAlt()
        {
            keybd_event(ALT, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void ReleaseTab()
        {
            keybd_event(TAB, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void PressF10()
        {
            keybd_event(F10, 0, KEYEVENTF_KEYDOWN, 0);
        }
        public static void ReleaseF10()
        {
            keybd_event(F10, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void ClickESC()
        {
            keybd_event(VK_ESCAPE, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(VK_ESCAPE, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void ClickEnter()
        {
            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void ClickSlash()
        {
            keybd_event(SLASH, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(SLASH, 0, KEYEVENTF_KEYUP, 0);
        }
    }
}

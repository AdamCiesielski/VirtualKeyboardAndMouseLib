using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace VirtualKeyboardAndMouse
{
    public class Mouse
    {
        #region DLLImport
        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        #endregion

        #region SetPosition
        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }
        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }
        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }
        public static void MouseMoveTo(int x, int y, bool withMoveDelay = true, int moveDelay = 1)
        {

            MousePoint current = GetCursorPosition();
            double yy;

            if (current.X > x)
            {
                for (int i = current.X; i >= x; i -= 4)
                {
                    yy = (double)(((double)current.Y - (double)y) / ((double)current.X - (double)x)) * (double)i + ((double)current.Y - ((double)current.Y - (double)y) / ((double)current.X - (double)x) * (double)current.X);
                    SetCursorPosition(i, (int)yy);

                    if(withMoveDelay)  Thread.Sleep(moveDelay);
                }
            }
            else if (current.X < x)
            {
                for (int i = current.X; i <= x; i += 4)
                {
                    yy = (double)(((double)current.Y - (double)y) / ((double)current.X - (double)x)) * (double)i + ((double)current.Y - ((double)current.Y - (double)y) / ((double)current.X - (double)x) * (double)current.X);
                    SetCursorPosition(i, (int)yy);
                    if (withMoveDelay) Thread.Sleep(moveDelay);
                }
            }
        }
        #endregion

        #region ClickMouseButton
        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();
            mouse_event((int)value, position.X, position.Y, 0, 0);
        }
        public static void MouseEvent(MouseEventFlags value, MousePoint position)
        {
            mouse_event((int)value, position.X, position.Y, 0, 0);
        }
        public static void MouseEvent(MouseEventFlags value, MousePoint position, int dwData)
        {
            mouse_event((int)value, position.X, position.Y, dwData, 0);
        }

        public static void PressLMB()
        {
            MousePoint position = GetCursorPosition();
            MouseEvent(MouseEventFlags.LeftDown, position);
        }
        public static void PressLMB(MousePoint position)
        {
            MouseEvent(MouseEventFlags.LeftDown, position);
        }
        public static void ReleaseLMB()
        {
            MousePoint position = GetCursorPosition();
            MouseEvent(MouseEventFlags.LeftUp, position);
        }
        public static void ReleaseLMB(MousePoint position)
        {
            MouseEvent(MouseEventFlags.LeftUp, position);
        }
        public static void ClickLMB()
        {
            MousePoint position = GetCursorPosition();

            PressLMB(position);
            ReleaseLMB(position);
        }
        public static void ClickLMB(int pressTime)
        {
            MousePoint position = GetCursorPosition();

            PressLMB(position);
            Thread.Sleep(pressTime);
            ReleaseLMB(position);
        }

        public static void PressRMB()
        {
            MousePoint position = GetCursorPosition();
            MouseEvent(MouseEventFlags.RightDown, position);
        }
        public static void PressRMB(MousePoint position)
        {
            MouseEvent(MouseEventFlags.RightDown, position);
        }
        public static void ReleaseRMB()
        {
            MousePoint position = GetCursorPosition();
            MouseEvent(MouseEventFlags.RightUp, position);
        }
        public static void ReleaseRMB(MousePoint position)
        {
            MouseEvent(MouseEventFlags.RightUp, position);
        }
        public static void ClickRMB()
        {
            MousePoint position = GetCursorPosition();

            PressRMB(position);
            ReleaseRMB(position);
        }
        public static void ClickRMB(int pressTime)
        {
            MousePoint position = GetCursorPosition();

            PressRMB(position);
            Thread.Sleep(pressTime);
            ReleaseRMB(position);
        }

        public static void PressMMB()
        {
            MousePoint position = GetCursorPosition();
            MouseEvent(MouseEventFlags.MiddleDown, position);
        }
        public static void PressMMB(MousePoint position)
        {
            MouseEvent(MouseEventFlags.MiddleDown, position);
        }
        public static void ReleaseMMB()
        {
            MousePoint position = GetCursorPosition();
            MouseEvent(MouseEventFlags.MiddleUp, position);
        }
        public static void ReleaseMMB(MousePoint position)
        {
            MouseEvent(MouseEventFlags.MiddleUp, position);
        }
        public static void ClickMMB()
        {
            MousePoint position = GetCursorPosition();

            PressMMB(position);
            ReleaseMMB(position);
        }
        public static void ClickMMB(int pressTime)
        {
            MousePoint position = GetCursorPosition();

            PressMMB(position);
            Thread.Sleep(pressTime);
            ReleaseMMB(position);
        }
        public static void SpinMMB(int value)
        {
            MousePoint position = GetCursorPosition();
            MouseEvent(MouseEventFlags.Move, position, value);
        }
        #endregion 

    }
}

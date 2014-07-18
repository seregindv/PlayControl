using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PlayControl
{
    public static class Api
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SystemParametersInfo(int action, int param, ref int retval, int updini);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByClass(string lpClassName, IntPtr zeroPtr);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr zeroPtr, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaptionAndClass(string lpClassName, string lpWindowName);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", EntryPoint = "PostMessage", SetLastError = true)]
        static extern bool PostMessage_(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        private static object _handleWrapper = new object();

        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int SPI_GETSCREENSAVERRUNNING = 0x0072;

        public const int WM_COMMAND = 0x111;
        public const int WM_SYSCOMMAND = 0x112;
        public const int SC_SCREENSAVE = 0xF140;

        public static void DoMouseClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static bool IsScreensaverRunning()
        {
            var active = 0;
            SystemParametersInfo(SPI_GETSCREENSAVERRUNNING, 0, ref active, 0);
            System.Diagnostics.Debug.WriteLine("Screensaver active = " + active);
            return active == 1;
        }

        public static IntPtr FindWindow(string className, string caption)
        {
            if (caption == null && className == null)
                return IntPtr.Zero;
            if (caption == null)
                return FindWindowByClass(className, IntPtr.Zero);
            if (className == null)
                return FindWindowByCaption(IntPtr.Zero, caption);
            return FindWindowByCaptionAndClass(className, caption);
        }

        public static void PostMessage(HandleRef hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            bool returnValue = PostMessage_(hWnd, msg, wParam, lParam);
            if (!returnValue)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public static void PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            PostMessage(new HandleRef(_handleWrapper, hWnd), msg, wParam, lParam);
        }
    }
}

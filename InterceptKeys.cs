using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PlayControl
{
    public class InterceptKeys : IDisposable
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;    
        private LowLevelKeyboardProc _proc;
        private readonly IntPtr _hookID = IntPtr.Zero;

        public event KeyEventHandler KeyUp;
        public event KeyEventHandler KeyDown;

        protected virtual void OnKeyUp(Keys key)
        {
            if (KeyUp != null)
                KeyUp(this, new KeyEventArgs(key));
        }

        protected virtual void OnKeyDown(Keys key)
        {
            if (KeyDown != null)
                KeyDown(this, new KeyEventArgs(key));
        }
        
        public InterceptKeys()
        {
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~InterceptKeys()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                if (wParam == (IntPtr) WM_KEYUP)
                {
                    var vkCode = Marshal.ReadInt32(lParam);
                    OnKeyUp((Keys) vkCode);
                }
                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    var vkCode = Marshal.ReadInt32(lParam);
                    OnKeyDown((Keys)vkCode);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
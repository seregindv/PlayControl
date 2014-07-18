using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PlayControl.Controllers
{
    public class SkypeModel : ModelBase, IDisposable
    {
        private readonly InterceptKeys _keys;

        public SkypeModel(InterceptKeys keys)
        {
            _keys = keys;
            _keys.KeyUp += KeyUp;
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.MediaPlayPause && e.KeyCode != Keys.MediaStop)
                return; ;
            var hWnd = Api.FindWindow("tSkMainForm", null);
            //    Api.PostMessage(hWnd, Api.WM_COMMAND, new IntPtr(0x82), IntPtr.Zero);
            if (hWnd == IntPtr.Zero)
                return;
            Api.SetForegroundWindow(hWnd);
            Thread.Sleep(500);
            switch (e.KeyCode)
            {
                case Keys.MediaPlayPause:
                    SendKeys.SendWait("%{PGUP}");
                    break;
                case Keys.MediaNextTrack:
                    SendKeys.SendWait("%{PGDN}");
                    break;
            }


            // Skype
            // Call -> Call : WM_COMMAND (0x111), wParam = 0x80, wParam = 0
            // Call -> Hang up : WM_COMMAND (0x111), wParam = 0x89, wParam = 0
            // Call -> Answer : WM_COMMAND (0x111), wParam = 0x82, wParam = 0
        }

        public void Dispose()
        {
            _keys.KeyUp -= KeyUp;
        }

        public override string Name { get { return "Answer"; } }
    }
}

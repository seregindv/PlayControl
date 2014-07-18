using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PlayControl.Controllers
{
    public class PlayModel : ModelBase, IDisposable
    {
        private readonly InterceptKeys _interceptKeys;

        public PlayModel(InterceptKeys interceptKeys)
        {
            _interceptKeys = interceptKeys;
            _interceptKeys.KeyUp += KeyUp;
        }

        private static void PlayPause()
        {
            Api.DoMouseClick();
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.MediaPlayPause)
            {
                //System.Diagnostics.Debug.Write("-- KeyUp: ");
                //Api.IsScreensaverRunning();
                if (Enabled)
                    PlayPause();
            }
        }

        public void Dispose()
        {
            _interceptKeys.KeyUp -= KeyUp;
        }

        public override string Name { get { return "Play"; } }
    }
}

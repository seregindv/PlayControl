using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using PlayControl.Controllers;

namespace PlayControl
{
    public partial class PlayControl : Form
    {
        Presenter _presenter;
        //private readonly System.Threading.Timer _timer;

        protected override void OnClosed(EventArgs e)
        {
            _presenter.Dispose();
            base.OnClosed(e);
        }

        public PlayControl()
        {
            InitializeComponent();
            _presenter = new Presenter();
            radioPlay_CheckedChanged(radioPlay, EventArgs.Empty);
        }

        private void radioPlay_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.Switch("Play", radioPlay.Checked);
        }

        private void radioMove_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.Switch("Move", radioMove.Checked);
        }

        private void radioAnswer_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.Switch("Answer", radioAnswer.Checked);
        }

        private void PlayControl_Load(object sender, EventArgs e)
        {
            var earphonesBitmap =
                new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("PlayControl.Taskbar.Images.Earphones.png"));
            var checkBitmap =
                new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("PlayControl.Taskbar.Images.Checkmark.png"));
            var checkedBitmap = new Bitmap(earphonesBitmap, earphonesBitmap.Size);
            using (var g = Graphics.FromImage(checkedBitmap))
            {
                g.DrawImage(checkBitmap,
                    earphonesBitmap.Width - checkBitmap.Width,
                    earphonesBitmap.Height - checkBitmap.Height);
            }
            var playThumb = new ThumbnailToolBarButton(Icon.FromHandle(checkedBitmap.GetHicon()), "Play");
            playThumb.Click += PlayThumb_Click;
            var manager = new ThumbnailToolBarManager();
            manager.AddButtons(this.Handle,
                new ThumbnailToolBarButton(Icon.FromHandle(new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("PlayControl.Taskbar.Images.Skype.png")).GetHicon()), "Skype"),
                playThumb,
                new ThumbnailToolBarButton(Icon.FromHandle(new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("PlayControl.Taskbar.Images.Mouse.png")).GetHicon()), "Mouse")
                );
        }

        private void PlayThumb_Click(object sender, ThumbnailButtonClickedEventArgs e)
        {
            var button = sender as ThumbnailToolBarButton;
            if (button == null)
                return;
            button.Icon = Icon.FromHandle(new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("PlayControl.Taskbar.Images.Earphones.png")).GetHicon());
        }

        //private void PlayControl_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.MediaPlayPause)
        //    {
        //        System.Diagnostics.Debug.Write("-- KeyDown: ");
        //        Api.IsScreensaverRunning();
        //    }
        //}

        //private void TimerCallBack(object o)
        //{
        //    Api.IsScreensaverRunning();
        //}

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == Api.WM_SYSCOMMAND)
        //    {
        //        System.Diagnostics.Debug.WriteLine("WM_SysCommand");
        //        if (m.WParam.ToInt32() == Api.SC_SCREENSAVE)
        //        {
        //            System.Diagnostics.Debug.WriteLine("SC_ScreenSave");
        //        }
        //    }
        //    base.WndProc(ref m);
        //}
    }
}

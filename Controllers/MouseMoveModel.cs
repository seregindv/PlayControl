using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlayControl.Controllers
{
    public class MouseMoveModel : ModelBase
    {
        readonly Timer _timer;
        bool _moveLeft;

        public MouseMoveModel()
        {
            _timer = new Timer { Interval = 10000 };
            _timer.Tick += Tick;
        }

        void Tick(object sender, EventArgs e)
        {
            Move();
        }

        private void Move()
        {
            Cursor.Position = new Point(Cursor.Position.X + (_moveLeft ? -1 : 1), Cursor.Position.Y);
            _moveLeft = !_moveLeft;
        }

        public override bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                _timer.Enabled = value;
                base.Enabled = value;
            }
        }

        public override string Name { get { return "Move"; } }
    }
}

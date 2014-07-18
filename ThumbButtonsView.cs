using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayControl.Controllers;

namespace PlayControl
{
    public class ThumbButtonsView
    {
        private readonly Presenter _presenter;

        public ThumbButtonsView(Presenter presenter)
        {
            _presenter = presenter;
            _presenter.EnabledChanged += Presenter_EnabledChanged;
        }

        void Presenter_EnabledChanged(object sender, EnabledChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

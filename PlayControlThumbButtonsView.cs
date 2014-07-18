using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlayControl.Controllers;

namespace PlayControl
{
    public class PlayControlThumbButtonsView
    {
        private readonly Presenter _presenter;
        private readonly Control _form;

        public PlayControlThumbButtonsView(Presenter presenter, Control form)
        {
            _presenter = presenter;
            _form = form;
            Initialize();
        }

        private void Initialize()
        {
            _presenter.EnabledChanged += Presenter_EnabledChanged;
        }

        private void Presenter_EnabledChanged(object sender, EnabledChangedEventArgs e)
        {
            UpdateIcon(e.Model);
        }

        private void UpdateIcon(IModel model)
        {
            
        }
    }
}

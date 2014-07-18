using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;

namespace PlayControl.Controllers
{
    public class EnabledChangedEventArgs : EventArgs
    {
        public EnabledChangedEventArgs(IModel model)
        {
            Model = model;
        }
        public IModel Model { set; get; }
    }

    public class Presenter : IDisposable
    {
        private Dictionary<string, IModel> _models;
        private ModelFactory _factory;

        public Presenter()
        {
            _models = new Dictionary<string, IModel>();
            _factory = new ModelFactory();
        }

        private IModel GetModel(string name)
        {
            IModel model;
            if (_models.TryGetValue(name, out model))
                return model;
            model = _factory.CreateController(name);
            _models.Add(name, model);
            return model;
        }

        public void Dispose()
        {
            _factory.Dispose();
        }

        public void Switch(string name, bool isEnabled)
        {
            var model = GetModel(name);
            SetEnabled(model, isEnabled);
        }

        public void EnableOne(string name, bool isEnabled)
        {
            var model = GetModel(name);
            foreach (var mdl in _models.Values.Where(c => c != model))
                SetEnabled(mdl, !isEnabled);
            SetEnabled(model, isEnabled);
        }

        private void SetEnabled(IModel model, bool isEnabled)
        {
            if (model == null || model.Enabled == isEnabled)
                return;
            model.Enabled = isEnabled;
            OnEnabledChanged(model);
        }

        public event EventHandler<EnabledChangedEventArgs> EnabledChanged;

        protected virtual void OnEnabledChanged(IModel model)
        {
            var handler = EnabledChanged;
            if (handler != null)
                handler(this, new EnabledChangedEventArgs(model));
        }
    }
}

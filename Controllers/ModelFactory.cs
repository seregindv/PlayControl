using System;
using System.Collections.Generic;
using System.Text;

namespace PlayControl.Controllers
{
    public class ModelFactory : IDisposable
    {
        private InterceptKeys _keys = new InterceptKeys();

        public IModel CreateController(string name)
        {
            switch (name)
            {
                case "Play":
                    return new PlayModel(_keys);
                case "Move":
                    return new MouseMoveModel();
                case "Answer":
                    return new SkypeModel(_keys);
                case "Alarm":
                    return null;
            }
            return null;
        }

        public void Dispose()
        {
            _keys.Dispose();
        }
    }
}

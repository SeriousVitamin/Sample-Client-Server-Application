using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Model;
using Server.View;

namespace Server.Presenter
{
    public class Presenter
    {
        private IModel _model;
        private IView _view;
        
        public Presenter(IModel model, IView view)
        {
            _model = model;
            _view = view;

            _view.StartServer += (address, port) => _model.StartServer(address, port);
            _view.CloseServer += () => { throw new NotImplementedException(); };
        }

        public void LogError(Exception ex)
        {
            throw ex;
        }
    }
}

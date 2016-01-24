using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.View;


namespace Client.Presenter
{
    class Presenter
    {
        private IModel _model;
        private IView _view;

        public Presenter(IModel model, IView view)
        {
            _model = model;
            _view = view;
        }
    }
}

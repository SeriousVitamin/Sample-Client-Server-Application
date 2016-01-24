// TODO: Unworked & useless test - Presenter_NullArguments_ThrowingException

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Server;
using NUnit.Framework;
using Server.Model;
using Server.Presenter;
using Server.View;

namespace ServerTests
{
    [TestFixture]
    class PresenterTests
    {
        [Test]
        public void Presenter_NullArguments_ThrowingException()
        {
            var model = Substitute.For<IModel>();
            var view = Substitute.For<IView>();

            var pres = Substitute.For<Presenter>(model, view);
            pres.Received().LogError(new ArgumentNullException());

            //Presenter presenter = new Presenter(model, null);
            //presenter.When(x => x.Received())
            //         .Do(x => { throw new ArgumentNullException();});
            //presenter.Received().LogError(new ArgumentNullException());
        }
    }
}

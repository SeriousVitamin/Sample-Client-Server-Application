using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ServerTests
{
    class ModelTests
    {
        [Test]
        public void getrandom()
        {
            var r = new Random();
            var tr = r.Next(2) == 0;

            var s = tr == true
                        ? "ДА"
                        : "НЕТ";

            Debug.WriteLine(s);
        }}
}

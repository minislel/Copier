using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie3
{
    public class MultidimensionalDevice : Copier
    {
        private Fax fax = new Fax();
        public int FaxCount => fax.Counter;
        public void Send(IDocument document, int recepientNo) => fax.Send(document, recepientNo);
    }
}

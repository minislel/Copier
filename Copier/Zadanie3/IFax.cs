using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie2
{
    public interface IFax : IDevice
    {
        int FaxNumber { get;}
        void Send(IDocument document, int recepientFaxNo);


    }
}

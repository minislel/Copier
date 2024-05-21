using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;
using Zadanie2;

namespace Zadanie3
{
    internal class Fax : IFax
    {
        public int FaxNumber { get; private set; }


        public int Counter { get; private set; }
        public IDevice.State state { get; private set; }

        public IDevice.State GetState()
        {
            return state;
        }

        public void PowerOff()
        {
            state = IDevice.State.off;
        }

        public void PowerOn()
        {
            state = IDevice.State.on;
        }


            public void Send(IDocument document, int recepientFaxNo)
            {

            if (state == IDevice.State.on)
            {
                if (recepientFaxNo == FaxNumber)
                {
                    throw new Exception("You can't fax yourself!");
                }
                Console.WriteLine("Sending " + document.GetFileName() + " to " + recepientFaxNo + "...");
                Thread.Sleep(800);
                Console.WriteLine("Fax sent!");
                Counter++;
            }
            }
        
    }
}

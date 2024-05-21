using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie3
{
    public class Printer : IPrinter
    {

        public int Counter { get; set; }
    
        private IDevice.State state { get; set; }
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

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off)
            {
                return;
            }
            Counter++;
            Console.WriteLine(DateTime.Now + " Print: " + document.GetFileName());
        }
    }
}

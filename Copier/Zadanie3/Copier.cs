using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie3
{
    public class Copier : BaseDevice
    {
        new public int Counter { get; private set; }
        private Scanner scanner = new Scanner();
        private Printer printer = new Printer();
        public int PrintCounter => printer.Counter;
        public int ScanCounter => scanner.Counter;
        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                printer.PowerOn();
                printer.Print(in document);
                printer.PowerOff();
            }
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = null;
            if(state == IDevice.State.on)
            {
                scanner.PowerOn();
                scanner.Scan(out document, formatType);
                scanner.PowerOff();
            }

        }
        public void ScanAndPrint() 
        {
            if (state == IDevice.State.on)
            {
                scanner.PowerOn();
                printer.PowerOn();
                Scan(out IDocument document);
                Print(in document);
                scanner.PowerOff();
                printer.PowerOff();
            }
        }
        new public void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                Counter++;
                state = IDevice.State.on;
                Console.WriteLine("Device is on ...");
            }

        }
        new public void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;
                Console.WriteLine("Device is off ...");
            }
        }
    }
}

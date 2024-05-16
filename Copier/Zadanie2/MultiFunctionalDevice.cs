using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie2
{
    public class MultifunctionalDevice : BaseDevice, IFax, IScanner, IPrinter
    {
        new public int Counter { get; private set; }
        public int FaxNumber { get; private set; }
        public int PrintCounter { get; private set; }
        public int ScanCounter { get; private set; }
        public int FaxCounter { get; private set; }

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off)
            {
                return;
            }
            PrintCounter++;
            Console.WriteLine(DateTime.Now + " Print: " + document.GetFileName());
        }

        public void Scan(out IDocument? document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if (state == IDevice.State.off)
            {
                document = null;
                return;
            }
            if (formatType == IDocument.FormatType.TXT)
            {
                document = new TextDocument("TextScan" + ScanCounter + ".txt");
            }
            else if (formatType == IDocument.FormatType.PDF)
            {
                document = new PDFDocument("PDFScan" + ScanCounter + ".pdf");
            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                document = new ImageDocument("ImageScan" + ScanCounter + ".jpg");
            }
            else document = null;
            Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            ScanCounter++;
        }

        public void Send(IDocument document, int recepientFaxNo)
        {
            if (recepientFaxNo == FaxNumber)
            {
                throw new Exception("You can't fax yourself!");
            }
            Console.WriteLine("Sending " + document.GetFileName() + " to " + recepientFaxNo + "...");
            Thread.Sleep(800);
            Console.WriteLine("Fax sent!");
        }
        public void ScanAndPrint()
        {
            IDocument? document;
            Scan(out document, IDocument.FormatType.JPG);
            Print(in document);
            document = null;
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
                Console.WriteLine("Device is on ...");
            }
        }
    }

}

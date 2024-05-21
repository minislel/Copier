using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie3
{
    public class Scanner : IScanner
    {
        public int Counter { get; private set; }
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

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            if (state == IDevice.State.off)
            {
                document = null;
                return;
            }
            if (formatType == IDocument.FormatType.TXT)
            {
                document = new TextDocument("TextScan" + Counter + ".txt");
            }
            else if (formatType == IDocument.FormatType.PDF)
            {
                document = new PDFDocument("PDFScan" + Counter + ".pdf");
            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                document = new ImageDocument("ImageScan" + Counter + ".jpg");
            }
            else document = null;
            Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            Counter++;
        }
    }
}

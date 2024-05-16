namespace Zadanie1
{
    public class Copier : BaseDevice, IScanner, IPrinter
    {
        
        new public int Counter { get; private set; }
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
    

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off)
            {
                return;
            }
            PrintCounter++;
            Console.WriteLine(DateTime.Now+" Print: "+document.GetFileName());
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            if(state==IDevice.State.off)
            {
                document = null;
                return; }
            if (formatType == IDocument.FormatType.TXT)
            {
                document = new TextDocument("TextScan" + ScanCounter + ".txt");
            }
            else if (formatType == IDocument.FormatType.PDF)
            { 
                document= new PDFDocument("PDFScan"+ScanCounter+".pdf");
            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                document = new ImageDocument("ImageScan" + ScanCounter + ".jpg");
            }
            else document = null;
            Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            ScanCounter++;
        }
        public void ScanAndPrint()
        {
            IDocument document;
            Scan(out document);
            Print(in document);
            document = null;
        }
        new public void PowerOn()
        {
            if (state != IDevice.State.on)
            {
                Counter++;
            }
            state = IDevice.State.on;
            Console.WriteLine("Device is on ...");
            
        }

    }
}

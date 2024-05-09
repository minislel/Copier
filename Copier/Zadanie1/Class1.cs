namespace Zadanie1
{
    public class Copier : BaseDevice, IScanner, IPrinter
    {
        
        public int Counter { get; set; }
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
    

        public void Print(in IDocument document)
        {
            PrintCounter++;
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            if (formatType == IDocument.FormatType.TXT)
            {
                document = new TextDocument("new");
            }
            if (formatType == IDocument.FormatType.PDF)
            { 
                document= new PDFDocument("new");
            }
            if (formatType == IDocument.FormatType.JPG)
            {
                document = new ImageDocument("new");
            }
            else document = null;
            Counter++;
            ScanCounter++;
        }
        public void ScanAndPrint()
        {
            Scan(out IDocument document);
            Print(in document);
            document = null;
            
        }
    }
}

﻿using Zadanie1;

namespace Zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var xerox = new MultifunctionalDevice();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);

            xerox.ScanAndPrint();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);
            xerox.Send(doc2, 22133121);
        }
    }
}

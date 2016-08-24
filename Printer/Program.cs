using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer
{
    //public class PrintEventArgs:EventArgs
    //{
    //    public int CurrentPage;
    //}
    public class PrintEvent
    {
        public event EventHandler Printing;
        //public event EventHandler PrintStarted;
        //public event EventHandler PrintEnded;
        //public event EventHandler PrintingCurrentPage;
        //PrintEventArgs e=new PrintEventArgs();

        public void OnPrinting()
        {
            if (Printing != null)
             Printing(this, EventArgs.Empty);
        }

        //public void OnPrinting()
        //{
        //    if (PrintingCurrentPage != null)
        //        PrintingCurrentPage(this, e);
        //}

        //public void OnPrintStarted()
        //{
        //    if (PrintStarted != null)
        //        PrintStarted(this, EventArgs.Empty);
        //}

        //public void OnPrintEnded()
        //{
        //    if (PrintEnded != null)
        //        PrintEnded(this, EventArgs.Empty);
        //}

    }

    public class Printer
    {
        public int Capacity { get; set; }
        public int Pagecount { get; set; }
        
        public Printer(int capacity, int Pagecount)
        {
            this.Capacity = capacity;
            this.Pagecount = Pagecount;
        }
        
        public void PrintStart(Object source,  EventArgs e)
        {
            Console.WriteLine("Printing Started");
        }
        public void PrintEnded( Object source, EventArgs e)
        {
            Console.WriteLine("Printing Ended");
        }




        public void PrintingCurrentPage(object source, EventArgs e)
        {

            int CurrentPage = 0;
            for (int i = 0; i < Pagecount; i++)
            {
                if (Capacity == 0)
                {
                    Console.WriteLine("Please press 'a' for adding papare");
                    if (Console.ReadKey().KeyChar == 'a')
                    {
                        Capacity += 1;
                    }
                    else break;
                }
                CurrentPage += 1;
                Console.WriteLine("\n Printing {0} page from {1}", CurrentPage, Pagecount);
                Capacity--;

            }
        } 









        //public void PrintingCurrentPage(object source, EventArgs e)
        //{

        //    ((PrintEventArgs)e).CurrentPage = 0;
        //    for (int i = 0; i < Pagecount; i++)
        //    {
        //        if (Capacity == 0)
        //        {
        //            Console.WriteLine("Please press 'a' for adding papare");
        //            if (Console.ReadKey().KeyChar == 'a')
        //            {
        //                Capacity += 1;
        //            }
        //            else break;
        //        }
        //        ((PrintEventArgs)e).CurrentPage += 1;
        //        Console.WriteLine("\n Printing {0} page from {1}", ((PrintEventArgs)e).CurrentPage, Pagecount);
        //        Capacity--;

        //    }
        //} 
	}
        
      
    class Program
    {
        static void Main(string[] args)
        {
            Printer p = new Printer(2, 5);
            PrintEvent printing=new PrintEvent();
            printing.Printing+=new EventHandler(p.PrintStart);
            printing.Printing+=new EventHandler(p.PrintingCurrentPage);
            printing.Printing+=new EventHandler(p.PrintEnded);
            printing.OnPrinting();
            //PrintEvent printstart = new PrintEvent();
            //printstart.PrintStarted += new EventHandler(p.PrintStart);
            //printstart.OnPrintStarted();
            //PrintEvent printcurrentpage = new PrintEvent();
            //printcurrentpage.PrintingCurrentPage+=new EventHandler(p.PrintingCurrentPage);
            //printcurrentpage.OnPrinting();
            //PrintEvent printended = new PrintEvent();
            //printended.PrintEnded += new EventHandler(p.PrintEnded);
            //printended.OnPrintEnded();

            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    
    public delegate void Eventdelegate();
    public class MyEvent
    {   public static int c=0;
        public event EventHandler Test;
        public event Eventdelegate Add;
        Args arg = new Args();
       public void OnAdding()
        {
            if (Test!=null)
            {
               arg.count=c+1;
                Test(this, arg);
            }
        }
        public void OnAdd()
        {
            if (Add != null)
            {
                Add();
            }
        }
    }

    public class Args:EventArgs
    {
        public int count;
    }
    public class EventHandeler
    {
        public void handeler()
        {
            Console.WriteLine("Added seccessfuly");
        }
        public void handelercount(object source, EventArgs arg)
        {
            Console.WriteLine("Event object name {0}, event arg {1}", source.GetType().FullName, ((Args)arg).count );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyEvent ev = new MyEvent();
            ev.Add += new Eventdelegate((new EventHandeler()).handeler);
            ev.OnAdd();
            MyEvent ev1 = new MyEvent();
            ev.Test += new EventHandler((new EventHandeler()).handelercount);
            ev.OnAdding();
            Console.ReadLine();
        }
    }
}

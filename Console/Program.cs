using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new PrinterManager(new ModernPrinter());

            manager.PrintBase("Worked!");


            System.Console.ReadLine();
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    class ManagerAttribute : Attribute
    {
        public string Message { get; set; }
        public ManagerAttribute(string debugMessage)
        {
            this.Message = debugMessage;
        }
    }

    static class Debugger
    {
        public static void Debug(Type manager)
        {
            List<string> messages = manager
                .GetCustomAttributes(typeof(ManagerAttribute), true)
                .Cast<ManagerAttribute>().Select(a => a.Message)
                .ToList();
            foreach (var message in messages)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }
        }
    }

    [Manager("PrinterManager called!")]
    class PrinterManager
    {
        private IPrinter _printer;

        
        public PrinterManager(IPrinter printer)
        {
            _printer = printer;
            Console.Debugger.Debug(typeof(PrinterManager));
        }

        public void PrintBase(string data)
        {
            this._printer.Print(data);
        }
    }

    interface IPrinter
    {
        void Print(string data);
    }

    class ModernPrinter : IPrinter
    {
        public void Print(string data)
        {
            //...
            System.Console.WriteLine(data);
        }
    }

    [Obsolete("This class is obsolete because of low performance. Use ModernPrinter instead of this.", true)]
    class Printer : IPrinter
    {
        public void Print(string data)
        {
            //...
            System.Console.WriteLine(data);
        }
    }

}

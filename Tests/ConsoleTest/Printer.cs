using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    class Printer
    {
        public virtual void Print(string Message) => Console.WriteLine(Message);

        public override string ToString() => "Принтер";
    }

    class PrefixPrinter : Printer
    {
        public string Prefix { get; set; }

        public PrefixPrinter(string Prefix)
        {
            this.Prefix = Prefix;
        }

        public override void Print(string Message) => Console.WriteLine($"{Prefix}{Message}");

        //public override string ToString() => "Принтер с префиксом";

        public override string ToString()
        {
            return base.ToString() + " с префиксом";
        }
    }
}

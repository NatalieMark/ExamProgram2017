using System;
namespace Eksamensopgave2017
{
    public abstract class ConsoleDesign
    {
        public ConsoleDesign()
        {
            //Console.SetWindowSize(100, 100);
        }

        public abstract void Header();

        public abstract void Body();

        public abstract void Print();
    }
}
namespace Eksamensopgave2017
{
    /// <summary>
    /// Console design is the superclass of 6 other classes
    /// and is used as the skelet for the UI.
    /// </summary>
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
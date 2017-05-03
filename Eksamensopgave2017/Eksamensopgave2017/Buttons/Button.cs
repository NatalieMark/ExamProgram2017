using System;
namespace Eksamensopgave2017
{
    public class Button
    {
        public Button(string name)
        { 
            this.Name = name; 
        }

        public Button(string name, string content)
        {
            this.Name = name;
            this.Content = content;
        }

        public string Name { get; }
        public string Content { get; set; }

        public void Select()
        {
            Console.Write(Name);
            Console.Write(Content);
        }
    }
}

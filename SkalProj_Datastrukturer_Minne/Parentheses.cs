using System;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{


    public class Parentheses
    {
        public string Name { get; set; }
        public char Opening {  get; set; }
        public char Closing { get; set; }

        public Parentheses(string name, char opening, char closing)
        {
            Name = name;
            Opening = opening;
            Closing = closing;
        }

        public override string ToString()
        {
            return $"Name='{Name}', Opening='{Opening}', Closing='{Closing}'";
        }
    }
}


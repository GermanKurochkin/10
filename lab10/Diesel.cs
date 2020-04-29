using System;
using System.Collections.Generic;
using System.Text;

namespace lab10
{
    public class Diesel : InternalCEngine
    {
        int numOfStroke;
        public int NumOfStroke
        {
            get { return numOfStroke; }
            set
            {
                if (value == 4) numOfStroke = 4;
                else numOfStroke = 2;
            }
        }
        public override void Show()
        {         
            Console.WriteLine($"Дизельный {numOfStroke}-тактный двигатель {name}; сила тяги - {power} лошадиных сил");
        }
        public new void ShowNoVirt()
        {
            Console.WriteLine($"Дизельный {numOfStroke}-тактный двигатель {name}; сила тяги - {power} лошадиных сил");
        }
        public Diesel() : base() { NumOfStroke = 2; }
        public Diesel(string n, int f, int stroke) : base(n, f) { NumOfStroke = stroke;  }
        public override bool Equals(object e)
        {
            return Name == ((Diesel)e).Name && Power == ((Diesel)e).Power&& NumOfStroke== ((Diesel)e).NumOfStroke;
        }
    }
}

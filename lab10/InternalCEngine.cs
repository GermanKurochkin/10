using System;
using System.Collections.Generic;
using System.Text;

namespace lab10
{
    public class InternalCEngine : Engine
    {
        public override void Show()
        {
            Console.WriteLine($"Двигатель внутреннего сгорания {name}; сила тяги - {power} лошадиных сил");           
        }
        public new void ShowNoVirt()
        {
            Console.WriteLine($"Двигатель внутреннего сгорания {name}; сила тяги - {power} лошадиных сил");
        }
        public InternalCEngine() : base() { }
        public InternalCEngine(string n, int f) : base(n,f) { }
        public override bool Equals(object e)
        {
            return Name == ((InternalCEngine)e).Name && Power == ((InternalCEngine)e).Power;
        }
    }
}

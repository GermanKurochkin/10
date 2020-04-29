using System;
using System.Collections.Generic;
using System.Text;

namespace lab10
{
    public class TurbojetEngine : InternalCEngine
    {
        bool afterburner;
        public bool Afterburner
        {
            get{ return afterburner; }
            set { afterburner = value; }
        }
        public override void Show()
        {
            string extra = "";
            if (afterburner) extra = "; с форсажной камерой";
            Console.WriteLine($"Турбореактивный двигатель {name}; сила тяги - {power} лошадиных сил" + extra);
        }
        public new void ShowNoVirt()
        {
            string extra = "";
            if (afterburner) extra = "; с форсажной камерой";
            Console.WriteLine($"Турбореактивный двигатель {name}; сила тяги - {power} лошадиных сил" + extra);
        }
        public TurbojetEngine() : base() { afterburner = false; }
        public TurbojetEngine(string n, int f, bool a) : base(n, f) { afterburner = a; }

        public override bool Equals(object e)
        {
            return Name == ((TurbojetEngine)e).Name && Power == ((TurbojetEngine)e).Power && Afterburner == ((TurbojetEngine)e).Afterburner;
        }
    }
}

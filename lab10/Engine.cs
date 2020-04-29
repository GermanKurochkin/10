using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab10
{
    public interface IExecutable
    {
        void Show();
        int ToWatt();
      
    }
    public class SortByPower:IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Engine eng1 = (Engine)obj1;
            Engine eng2 = (Engine)obj2;
            if (eng1.Power < eng2.Power) return -1;
            else if (eng1.Power == eng2.Power) return 0;
            else return 1;
        }
    }
    public class Engine :IExecutable,IComparable,ICloneable
    {
        protected int power;
        protected string name;
        public int[] mas = new int[] { 1, 1, 1, 1, 1 };
        public int Power
        {
            get { return power; }
            set
            {
                if (value < 0) power = 0;
                else power = value;
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Engine()
        {
            power = 0;
            name = "-";
        }
        public Engine(string n,int f)
        {
            Name = n;
            Power = f;
        }
        public override bool Equals(object e)
        {
            return Name==((Engine)e).Name && Power== ((Engine)e).Power;
        }
        public virtual void Show()
        {
            Console.WriteLine($"Двигатель {name}; сила тяги - {power} лошадиных сил");
        }
        public void ShowNoVirt()
        {
            Console.WriteLine($"Двигатель {name}; сила тяги - {power} лошадиных сил");
        }
        public int ToWatt()
        {
            return (int)Math.Round(power * 735.5);
        }
        public int CompareTo(object obj)
        {
            Engine eng = (Engine)obj;
            return string.Compare(name, eng.name);
        }
        public Engine ShallowCopy()
        {
            return (Engine)MemberwiseClone();
        }
        public object Clone()
        {
            return new Engine("Клон " + name, power);
        }
    }
}

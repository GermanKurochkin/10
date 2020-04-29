using System;


namespace lab10
{

    class Program
    {
        static void Main(string[] args)
        {
            

            Engine eng1 = new Engine("DD-1", 1100);
            InternalCEngine iEng1 = new InternalCEngine("NN-1500", 1500);
            Diesel dies1 = new Diesel("FG-9.4", 9100, 4);
            TurbojetEngine turb1 = new TurbojetEngine("KT-9.A", 9200, true);

            Engine eng2 = new Engine("DD-3", 3300);
            Engine eng3 = new Engine("DD-8", 8200);
            InternalCEngine iEng2 = new InternalCEngine("NT-7500", 7500);
            Diesel dies2 = new Diesel("FG-2.2", 2100, 2);
            Diesel dies3 = new Diesel("FG-6.2", 6400, 2);
            Diesel dies4 = new Diesel("FP-5.2", 5700, 2);
            Diesel dies5 = new Diesel("FP-7.4", 7200, 4);
            TurbojetEngine turb2 = new TurbojetEngine("KT-6", 6100, false);
            TurbojetEngine turb3 = new TurbojetEngine("TT-7.A", 7000, true);
            TurbojetEngine turb4 = new TurbojetEngine("KT-8.A", 8000, true);
            TurbojetEngine turb5 = new TurbojetEngine("TT-4", 4000, false);
            TurbojetEngine turb6 = new TurbojetEngine("TT-9.A", 9300, true);
            TurbojetEngine turb7 = new TurbojetEngine("TA-3000", 3000, true);
            TurbojetEngine turb8 = new TurbojetEngine("TA-6300", 6300, true);
            TurbojetEngine turb9 = new TurbojetEngine("TA-9400", 9400, true);

            object[] mas = new object[] { eng1, iEng1, dies1, turb1 };
            object[] mas1 = new object[] { eng1, iEng1, dies1, turb1 };
            Console.WriteLine("Correct");
            foreach (Engine eng in mas) eng.Show();
            Console.WriteLine("Wrong");
            foreach (Engine eng in mas) eng.ShowNoVirt();

            Console.WriteLine();
            mas = new object[]
            { eng1, eng2, eng3, iEng1, iEng2, dies1, dies2, dies3, dies4, dies5,
                turb1, turb2, turb3, turb4, turb5, turb6, turb7, turb8, turb9
            };
            int count,summ;
           
            Console.WriteLine("Количество двигателей внутреннего сгорания");
            count = 0;
            foreach (Engine eng in mas) if (eng is InternalCEngine) count++;
            Console.WriteLine(count);
            Console.WriteLine("Количество дизельных 2-тактовых двигателей двигателей");
            count = 0;
            foreach (Engine eng in mas)
            {
               
                    Diesel dies = eng as Diesel;
                    if(dies != null && dies.NumOfStroke==2)  count++;
                
            }
            Console.WriteLine(count);
            Console.WriteLine("Средняя сила тяги турбореактивных двигателей с форсажной камерой");
            count = 0;
            summ = 0;
            foreach (Engine eng in mas)
            {

                TurbojetEngine turb = eng as TurbojetEngine;
                if (turb != null && turb.Afterburner)
                {
                    count++;
                    summ += turb.Power;
                }

            }
            Console.WriteLine((double)summ/count);

            Console.WriteLine();
            IExecutable[] mas2 = new IExecutable[] { eng1, iEng1, dies1, turb1 };
            foreach (Engine eng in mas2)
            {
                eng.Show();
                Console.WriteLine($"В ваттах:{eng.ToWatt()}");
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("/////////////////////////////////////////////////////////");
            Console.ResetColor();

            foreach (Engine eng in mas) eng.Show();
            mas1 = mas;
            Console.WriteLine("Сортировка по имени");
            Array.Sort(mas);
            foreach (Engine eng in mas) eng.Show();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("/////////////////////////////////////////////////////////");
            Console.ResetColor();

            foreach (Engine eng in mas) eng.Show();
            Console.WriteLine("SortByPower");
            Array.Sort(mas, new SortByPower());            
            foreach (Engine eng in mas) eng.Show();

            Console.WriteLine();
            eng1.Show();
            Console.WriteLine("Неглубокое копирование");
            Engine eng1Copy = eng1.ShallowCopy();
            eng1Copy.Show();
            eng1Copy.mas[2] = 100;
            Console.WriteLine(eng1.mas[2]);
         
            Console.WriteLine("Глубокое копирование");
            eng1Copy = (Engine)eng1.Clone();
            eng1Copy.Show();
            eng1Copy.mas[2] = 10;
            Console.WriteLine(eng1.mas[2]);
          
        }
    }
}

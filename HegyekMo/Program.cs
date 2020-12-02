using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HegyekMo
{
    class Program
    {
        static List<Hegy> hegyek = new List<Hegy>();
        static Dictionary<string, int> hegystatisztika = new Dictionary<string, int>();

        static void hegyekbeolvas()
        {
            StreamReader file = new StreamReader("hegyekMo.txt");
            file.ReadLine();
            while (!file.EndOfStream)
            {
                string[] adat = file.ReadLine().Split(';');
                hegyek.Add(new Hegy(adat[0], adat[1], int.Parse(adat[2])));
            }
            file.Close();
        }

        static void harmadik()
        {
            Console.WriteLine($"3. feladat: Hegycsúcsok száma: {hegyek.Count}");
        }

        static void negyedik()
        {
            double sumMag = 0;
            for (int i = 0; i < hegyek.Count; i++)
            {
                sumMag += hegyek[i].Magassag;
            }

            double atlag = sumMag / hegyek.Count;

            Console.WriteLine($"4. feladat: Hegycsúcsok átlagos magassága: {atlag} m");
        }

        static void otodik()
        {
            int maxMag = 0;

            for (int i = 0; i < hegyek.Count; i++)
            {
                if (hegyek[i].Magassag>maxMag)
                {
                    maxMag = hegyek[i].Magassag;
                }
            }
            Console.WriteLine("5. feladat: A legmagasabb hegycsúcs adatai: ");
            for (int j = 0; j < hegyek.Count; j++)
            {
                if (hegyek[j].Magassag==maxMag)
                {
                    Console.WriteLine($"\tNév: {hegyek[j].Csucs}");
                    Console.WriteLine($"\tHegység: {hegyek[j].Hegyseg}");
                    Console.WriteLine($"\tMagasság: {hegyek[j].Magassag} m");
                }
            }
        }

        static void hatodik()
        {
            int bekert = 0;
            Console.Write("6. feladat: Kérek egy magasságot: ");
            bekert = int.Parse(Console.ReadLine());

            bool van = false;

            int j = 0;
            while (van == false && j<hegyek.Count)
            {
                if (hegyek[j].Hegyseg=="Börzsöny" && bekert>hegyek[j].Magassag)
                {
                    van = true;
                }
                else
                {
                    j++;
                }
                
            }

            if (van==true)
            {
                Console.WriteLine($"Van {bekert}m-nél magasabb hegycsúcs a Börzsönyben!");
            }
            else
            {
                Console.WriteLine($"Nincs {bekert}m-nél magasabb hegycsúcs a Börzsönyben!");
            }

            //ELLENŐRZÉS
            //for (int i = 0; i < hegyek.Count; i++)
            //{
            //    if (hegyek[i].Hegyseg=="Börzsöny")
            //    {
            //        Console.WriteLine($"{hegyek[i].Csucs}, {hegyek[i].Hegyseg}, {hegyek[i].Magassag}");
            //    }
            //}

        }

        static void hetedik()
        {
            int labbanDb = 0;
            for (int i = 0; i < hegyek.Count; i++)
            {
                if (hegyek[i].labban>3000)
                {
                    labbanDb++;
                }
            }

            Console.WriteLine($"7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {labbanDb}");
        }

        static void nyolcadik()
        {
            for (int i = 0; i < hegyek.Count; i++)
            {
               
            }
            
        }

        static void kilencedik()
        {
            Console.WriteLine("9. feladat: bukk-videk.txt");
            StreamWriter fileba = new StreamWriter("bukk-videk.txt");
            fileba.WriteLine("Hegycsúcs neve;Magasság láb");
            for (int i = 0; i < hegyek.Count; i++)
            {
                if (hegyek[i].Hegyseg== "Bükk-vidék")
                {
                    fileba.WriteLine($"{hegyek[i].Csucs};{hegyek[i].labban:N1}");
                }
            }
            fileba.Close();
        }

        static void Main(string[] args)
        {
            hegyekbeolvas();
            harmadik();
            negyedik();
            otodik();
            hatodik();
            hetedik();
            nyolcadik();
            kilencedik();

            Console.ReadKey();
        }
    }
}

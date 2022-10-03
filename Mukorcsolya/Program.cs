using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helsinki2017
{
    internal class Program
    {
        static List<Korcsolya> rovidProgList = new List<Korcsolya>();
        static List<Korcsolya> dontoList = new List<Korcsolya>();
        
        //4.feladat
        static double osszPontSzam(string nev)
        {
            double osszPont = 0;
            foreach (Korcsolya i in rovidProgList)
            {
                if (i.Nev == nev)
                {
                    osszPont += i.TechPont + i.KompPont - i.Levonas;
                }
            }

            foreach (Korcsolya i in dontoList)
            {
                if (i.Nev == nev)
                {
                    osszPont += i.TechPont + i.KompPont - i.Levonas;
                }
            }
            return osszPont;
        }

        static void Main(string[] args)
        {
            //1.feladat
            StreamReader Olvas = new StreamReader("rovidprogram.csv", Encoding.Default);
            string Fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                rovidProgList.Add(new Korcsolya(Olvas.ReadLine()));
            }
            Olvas.Close();
            StreamReader Olvasas = new StreamReader("donto.csv", Encoding.Default);
            Fejlec = Olvasas.ReadLine();
            while (!Olvasas.EndOfStream)
            {
                dontoList.Add(new Korcsolya(Olvasas.ReadLine()));
            }
            Olvasas.Close();

            //2.feladat
            Console.WriteLine("2.feladat");
            Console.WriteLine($"\tA rövidprogramban {rovidProgList.Count} induló volt.");

            //3.feladat
            Console.WriteLine("3.feladat");
            bool BejutottE = false;
            for (int i = 0; i < dontoList.Count; i++)
            {
                if(dontoList[i].Orszag == "HUN")
                {
                    BejutottE=true;
                }
            }
            if(BejutottE == true)
            {
                Console.WriteLine("\tA magyar versenyző bejutott a kürbe.");
            }
            else
            {
                Console.WriteLine("\tA magyar versenyző nem jutott be a kürbe.");
            }

            //5.feladat
            Console.WriteLine("5.feladat");
            Console.Write("\tKérem a versenyző nevet: ");
            string bekertNev = Console.ReadLine();
            bool voltEIlyen = false;
            for (int i = 0; i < rovidProgList.Count; i++)
            {
                if(bekertNev == rovidProgList[i].Nev)
                {
                    voltEIlyen=true;
                }
            }
            if (voltEIlyen == false)
            {
                Console.WriteLine("Nem volt ilyen iduló.");
            }

            //6.feladat
            Console.WriteLine("6.feladat");
            double osszPont = osszPontSzam(bekertNev);
            Console.WriteLine($"\tA versenyző összpontszáma: {osszPont}");

            //7.feladat
            Console.WriteLine("7.feladat");
            List<string> OrszagLista = new List<string>();
            for (int i = 0; i < dontoList.Count; i++)
            {
                bool szerepelE = false;
                for (int j = 0; j < OrszagLista.Count; j++)
                {
                    if (dontoList[i].Orszag == OrszagLista[j])
                    {
                        szerepelE = true;
                    }
                }
                if (szerepelE == false)
                {
                    OrszagLista.Add(dontoList[i].Orszag);
                }
            }
            int[] OrszagListaSeged = new int[OrszagLista.Count];
            for (int i = 0; i < dontoList.Count; i++)
            {
                for (int j = 0; j < OrszagLista.Count; j++)
                {
                    if(dontoList[i].Orszag == OrszagLista[j])
                    {
                        OrszagListaSeged[j]++;
                    }
                }
            }
            for (int i = 0; i < OrszagListaSeged.Length; i++)
            {
                if (OrszagListaSeged[i]>1)
                {
                    Console.WriteLine($"\t{OrszagLista[i]}: {OrszagListaSeged[i]} versenyző");
                }
            }

            //8.feladat
            StreamWriter Iro = new StreamWriter("vegeredmeny.csv");

            

            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
    }
}

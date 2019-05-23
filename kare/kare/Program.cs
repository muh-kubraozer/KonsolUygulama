using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kare
{
    class Program
    {
        static void Main(string[] args)
        {
            int secim = 0;
            int boyut = 0;
            do
            {
                MenüYazdir();
                secim = AlGetir("Seçiminizi Giriniz:");
                boyut = AlGetir("Boyut Giriniz:");

            } while (!SecimUygula(secim,boyut));
           
            Console.ReadLine();
        }
        static void MenüYazdir()
        {
            Console.WriteLine("-------şekil menüsü------");
            Console.WriteLine("1-kare");
            Console.WriteLine("2-sola dayalı üçgen");
            Console.WriteLine("3-sağa dayalı üçgen");
            Console.WriteLine("4-ikizkenar üçgen");
            Console.WriteLine("5-baklava dilimi");
            Console.WriteLine("-------------------------");

        }
        static int AlGetir(string istenen)
        {
            bool HataliMİ = false;
            int girilen = 0;
            do
            {
                Console.Write(istenen);
                HataliMİ = !int.TryParse(Console.ReadLine(),out girilen);
                if(HataliMİ)
                {
                    hatamesajiver("Lütfen tam sayı giriniz.");
                }

            } while (HataliMİ);
            return girilen;
        }

       static void hatamesajiver(string mesaj)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Hata" + mesaj);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        static bool SecimUygula(int secim, int boyut)
        {
            
            bool sonuc = true;
            switch (secim)
            {
                case 1:
                    KareCiz(boyut);
                    break;
                case 2:
                   SolaDayaliUcgen(boyut);
                    break;
                case 3:
                    SagaDayaliUcgen(boyut);
                    break;
                case 4:
                    İkizkenarUcgen(boyut);
                    break;
                case 5:
                    BaklavaDilimi(boyut);
                    break;

                default:
                    
                   hatamesajiver("Lütfen tekrar secim yapınız:");
                     
                    sonuc = false;
                    break;
            }
            return sonuc;
        }
        static void KareCiz(int boyut)
        {
            for(int satir=0;satir<boyut;satir++)
            {
                for(int sutun=0;sutun<boyut;sutun++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        static void SolaDayaliUcgen(int boyut)
        {
            for (int satir = 0; satir < boyut; satir++)
            {
                for (int sutun = 0; sutun <= satir; sutun++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        static void SagaDayaliUcgen(int boyut)
        {
            for(int satir=0; satir<boyut;satir++)
            {
                for(int sutun=0;sutun<boyut;sutun++)
                {
                    Char sembol = ' ';
                    if(sutun>=boyut-satir-1)
                    {
                        sembol = '*';
                    }
                    Console.Write(sembol);
                }

                Console.WriteLine();
            }
           
        }
        static void İkizkenarUcgen(int boyut)
        {
            for (int satir = 0; satir < boyut; satir++)
            {
                for (int sutun = 0; sutun <boyut+satir; sutun++)
                {
                    Char sembol = ' ';
                    if(sutun>=boyut-satir-1)
                    {
                        sembol = '*';
                    }
                    Console.Write(sembol);
                }
                Console.WriteLine();
            }
            
            
        }
        static void BaklavaDilimi(int boyut)
        {
            for(int satir=0;satir<(2*boyut-1);satir++)
            {
                int sutunSiniri=(2*boyut-1)-Math.Abs((boyut-1)-satir);
                for(int sutun=0;sutun<sutunSiniri;sutun++)
                {
                    char sembol = ' ';
                    if(sutun>=(Math.Abs((boyut-1)-satir)))
                        {
                        sembol = '*';
                    }
                    Console.Write(sembol);
                }

                Console.WriteLine();
            }
        }
    }
}

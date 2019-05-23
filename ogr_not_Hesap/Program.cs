using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ogr_not_Hesap
{
    class Program
    {
        static void Main(string[] args)
        {
            Ogrenci ogr1 = new Ogrenci();
            Console.WriteLine("Öğrencinin adı:");
            ogr1.Ogr_Adi = Console.ReadLine();
            Console.WriteLine("öğrencinin Soyadı");
            ogr1.Ogr_Soyadi = Console.ReadLine();  
            ogr1.ders = new Ders();
            Console.WriteLine("Ders Adi:");
            ogr1.ders.Ders_Adi = Console.ReadLine();
            Console.WriteLine("Vize Notunu Giriniz:");
            ogr1.ders.vize_N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Final Notunu Giriniz:");
            ogr1.ders.final_N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ödev Notunu Giriniz:");
            ogr1.ders.Odev_N = Convert.ToInt32(Console.ReadLine());
            Not_Hesaplama not_Goster = new Not_Hesaplama();
            Console.WriteLine(not_Goster.Goster(ogr1));
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banka_Uygulaması
{
    class Program
    {
        static void Main(string[] args)
        {

            Banka banka = new Banka();
            TekrarEt(banka);

        }
    
        public static int Menü()
        {
            Console.WriteLine("Menü Seçimi Yapınız");
            Console.WriteLine("1-Yeni Hesap Açma");
            Console.WriteLine("2-Hesap Listele");
            Console.WriteLine("3-Para Yatır");
            Console.WriteLine("4-Havale Yap");
            int secim = Convert.ToInt32(Console.ReadLine());
            return secim;
        }
        
        public static void TekrarEt(Banka banka)
        {
            Hesap hesap = new Hesap();
            hesap.kullanıcı = new Kullanıcı();
            int secim = Menü();
            Console.Clear();
            switch (secim)
            {
                case 1:

                    Console.Write("Adı giriniz:");
                    hesap.kullanıcı.ad = Console.ReadLine();
                    Console.Write("Soyadı giriniz:");
                    hesap.kullanıcı.soyad = Console.ReadLine();
                    Console.Write("Tc numarası giriniz:");
                    hesap.kullanıcı.tcNo = Console.ReadLine();
                    Console.Write("Hesap numarası girin:");
                    hesap.hesapNo = Console.ReadLine();
                    Console.Write("Bakiye giriniz:");
                    hesap.bakiye = Convert.ToDecimal(Console.ReadLine());
                    banka.YeniHesap(hesap);
                    TekrarEt(banka);
                    break;

                //hesaplistele
                case 2:
                    Console.WriteLine(banka.HesapListele());
                    TekrarEt(banka);
                    break;
                default:
                    break;

                //para yatır
                case 3:
                    decimal tutar = 0;
                    Console.Write("Para yatacak hesabın Tc numarasını giriniz:");
                    hesap.kullanıcı.tcNo = Console.ReadLine();
                    Console.Write("Para yatacak hesabın Hesap numarası girin:");
                    hesap.hesapNo = Console.ReadLine();
                    for (int i = 0; i < banka.hesaplar.Length; i++)
                    {
                        if (banka.hesaplar[i].kullanıcı.tcNo == hesap.kullanıcı.tcNo && banka.hesaplar[i].hesapNo == hesap.hesapNo)
                        {
                            Console.WriteLine("Yatırılacak tutarı giriniz:");
                            tutar = Convert.ToDecimal(Console.ReadLine());
                            banka.ParaYAtır(banka.hesaplar[i], tutar);
                            Console.Write(banka.HesapListele());
                            TekrarEt(banka);
                            Console.ReadKey();
                        }
                    }
                    break;
                //havale yap
                case 4:
                    decimal tutar2 = 0;
                    Console.Write("Göndericinin Tc numarasını giriniz:");
                    hesap.kullanıcı.tcNo = Console.ReadLine();

                    for (int i = 0; i < banka.hesaplar.Length; i++)
                    {
                        if (banka.hesaplar[i].kullanıcı.tcNo == hesap.kullanıcı.tcNo)
                        {
                            Console.Write("Yatırılıcak tutarı giriniz:");
                            tutar2 = Convert.ToDecimal(Console.ReadLine());
                            if (banka.hesaplar[i].bakiye > tutar2)
                            {
                                int gönderici = i;
                                Console.Write("Alıcının tc numarasını giriniz:");
                                hesap.kullanıcı.tcNo = Console.ReadLine();
                                Console.Write("Alıcının hesap numarasını giriniz:");
                                hesap.hesapNo = Console.ReadLine();
                                for (int j = 0; j < banka.hesaplar.Length; j++)
                                {
                                    if (banka.hesaplar[j].kullanıcı.tcNo == hesap.kullanıcı.tcNo && banka.hesaplar[j].hesapNo == hesap.hesapNo)
                                    {
                                        int alıcı = j;
                                        banka.HavaleYap(gönderici, alıcı, tutar2);
                                        Console.WriteLine(banka.HesapListele());
                                        TekrarEt(banka);
                                    }
                                }

                            }

                        }
                    }

                    break;

               
            }
            
            
        }


    }


}


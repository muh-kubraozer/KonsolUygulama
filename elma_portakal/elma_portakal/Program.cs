using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elma_portakal
{
    class Program
    {
        static void Main(string[] args)
        {
            int elmaKonum = 0, portakalKonum = 0, solDuvarKonum = 0, sagDuvarKonum = 0;
            int meyveSecimi = 0;
            int dusenMeyveKonumu = 0;

            do
            {

                elmaKonum = ElmaAgaciKonumuAl();
                solDuvarKonum = EvinSolDuvarKonumuAl();
                sagDuvarKonum = EvinSagDuvarKonumuAl();
                portakalKonum = PortakalAgaciKonumuAl();




                if (elmaKonum + 2 > solDuvarKonum)
                {
                    HataMesajiVer("Sol duvar konumu en az 2 birim elma konumundan büyük olmalı");
                }
                else if (solDuvarKonum + 2 > sagDuvarKonum)
                {
                    HataMesajiVer("Sag duvar konumu en az 2 birim sol duvar konumundan büyük olmalı");
                }

                else if (sagDuvarKonum + 2 > portakalKonum)
                {
                    HataMesajiVer("sag duvar konumu en az iki  birim potakal agacı konumundan büyük olmalı");
                }
                else
                {
                    break;
                }

            } while (true);

            meyveSecimi = YeniMeyveSecimi();
            dusenMeyveKonumu = DusenMeyveKonumuAl();
            CarparMi(elmaKonum, portakalKonum, sagDuvarKonum, solDuvarKonum, meyveSecimi, dusenMeyveKonumu);
            int bitis = AnaMenü();
            do
            {
                if(meyveSecimi==1)
                {
                    do
                    {

                        elmaKonum = ElmaAgaciKonumuAl();
                        portakalKonum = PortakalAgaciKonumuAl();
                        solDuvarKonum = EvinSolDuvarKonumuAl();
                        sagDuvarKonum = EvinSagDuvarKonumuAl();




                        if (elmaKonum + 2 > solDuvarKonum)
                        {
                            HataMesajiVer("Sol duvar konumu en az 2 birim elma konumundan büyük olmalı");
                        }
                        else if (solDuvarKonum + 2 > sagDuvarKonum)
                        {
                            HataMesajiVer("Sag duvar konumu en az 2 birim sol duvar konumundan büyük olmalı");
                        }

                        else if (sagDuvarKonum + 2 > portakalKonum)
                        {
                            HataMesajiVer("sag duvar konumu en az iki  birim potakal agacı konumundan büyük olmalı");
                        }
                        else
                        {
                            break;
                        }

                    } while (true);

                    meyveSecimi = YeniMeyveSecimi();
                    dusenMeyveKonumu = DusenMeyveKonumuAl();
                    CarparMi(elmaKonum, portakalKonum, sagDuvarKonum, solDuvarKonum, meyveSecimi, dusenMeyveKonumu);
                    bitis = AnaMenü();
                }
                else if(meyveSecimi==2)
                {
                    meyveSecimi = YeniMeyveSecimi();
                    dusenMeyveKonumu = DusenMeyveKonumuAl();
                    CarparMi(elmaKonum, portakalKonum, sagDuvarKonum, solDuvarKonum, meyveSecimi, dusenMeyveKonumu);
                    bitis = AnaMenü();
                }
                else
                {
                    return;
                }

            } while (true);

        }
        static int ElmaAgaciKonumuAl()
        {
            int konum = 0;
            Console.WriteLine("elma agacı konumunu giriniz:");
            int .TryParse(Console.ReadLine(),out konum);
            return konum;

        }
        static int EvinSolDuvarKonumuAl()
        {
            int konum = 0;
            Console.WriteLine("Evin sol duvar konumunu giriniz:");
            int.TryParse(Console.ReadLine(), out konum);
            return konum;

        }
        static int EvinSagDuvarKonumuAl()
        {
            int konum = 0;
            Console.WriteLine("Evin sağ duvar  konumunu giriniz:");
            int.TryParse(Console.ReadLine(), out konum);
            return konum;

        }
        static int PortakalAgaciKonumuAl()
        {
            int konum = 0;
            Console.WriteLine("Portakal agacı konumunu giriniz:");
            int.TryParse(Console.ReadLine(), out konum);
            return konum;

        }
        static int DusenMeyveKonumuAl()
        {
            int konum = 0;
            Console.WriteLine("düşen meyve konumunu giriniz:");
            int.TryParse(Console.ReadLine(), out konum);
            return konum;

        }
        static int YeniMeyveSecimi()
        {
            int secilen = 0;
            Console.WriteLine("--Yeni Meyve Menüsü--");
            Console.WriteLine("1-Elma");
            Console.WriteLine("2-Portakal");

            int.TryParse(Console.ReadLine(), out secilen);
            return secilen;


        }
        static void CarparMi(int meyveSecimi, int dusenMeyveKonum, int sagDuvarKonum, int solDuvarKonum, int elmaAgackonum, int portakalAgacKonum)
        {
            switch (meyveSecimi)
            {
                case 1:
                    if (elmaAgackonum + dusenMeyveKonum >= solDuvarKonum)
                    {
                        Console.WriteLine("çarptı");
                    }
                    else
                    {
                        Console.WriteLine("çarpmadı");
                    }
                    break;
                case 2:

                    if (portakalAgacKonum + dusenMeyveKonum <= sagDuvarKonum)
                    {
                        Console.WriteLine("çarptı");
                    }
                    else
                    {
                        Console.WriteLine("çarpmadı");
                    }
                    break;

            }


        }
        static int AnaMenü()
        {
            int secilen = 0;
            Console.WriteLine("--Ana Menüsü--");
            Console.WriteLine("1-Başa Dön");
            Console.WriteLine("2-Yeni Meyve Seç");
            Console.WriteLine("3-Çıkış");
            int.TryParse(Console.ReadLine(), out secilen);

            return secilen;
        }
        static void HataMesajiVer(string mesaj)
        {
            Console.WriteLine("hata" + mesaj);

        }




    }
}

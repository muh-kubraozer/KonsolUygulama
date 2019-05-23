using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ogr_not_Hesap
{
    class Not_Hesaplama
    {


        public string Goster(Ogrenci ogr)
        {
            string goster = Hesapla(ogr.ders.vize_N, ogr.ders.final_N, ogr.ders.Odev_N);
            return string.Format(" {0} : {1}", ogr.Ogr_Adi + " " + ogr.Ogr_Soyadi, goster);
        }
         string Hesapla(int vize, int final,int odev)
        {
            string harf = "";
            int sonuc = 0;
             sonuc = (vize * 30 / 100) + (final * 50 / 100) + (odev * 20 / 100);
            if (sonuc >= 0 && sonuc < 20)
            {
                harf= "FF";
            }
            else if (sonuc > 21 && sonuc < 30)
            {
                harf= "FD";
            }
            else if (sonuc > 31 && sonuc < 40)
            {
               harf="DD";

            }
            else if (sonuc > 41 && sonuc < 50)
            {
               harf= "CD";
            }
            else if (sonuc > 51 && sonuc < 60)
            {
                harf= "CC";
            }
            else if (sonuc > 61 && sonuc < 70)
            {
                harf= "CB";
            }
            else if (sonuc > 71 && sonuc < 80)
            {
                harf="BB";
            }
            else if (sonuc > 81 && sonuc < 90)
            {
                harf= "BA";
            }
            else if (sonuc > 91 && sonuc <= 100)
            {
               harf="AA";
            }
            return harf;


        }
     
    }
}
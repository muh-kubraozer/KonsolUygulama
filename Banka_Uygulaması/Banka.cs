using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banka_Uygulaması
{
    class Banka
    {
       public Hesap[] hesaplar;
       public void YeniHesap(Hesap hesap)
        {
            if(hesaplar==null)
            {
                hesaplar = new Hesap[1];
                hesaplar[0] = hesap;

            }
            else
            {
                Hesap[] gecici = hesaplar;
                hesaplar = new Hesap[gecici.Length + 1];
                for(int i=0; i<gecici.Length; i++)
                {
                    hesaplar[i] = gecici[i];
                }
                hesaplar[hesaplar.Length - 1] = hesap;
            }
       

        }
   
        public string HesapListele()
        {
            string liste = " ";
            for(int i = 0; i < hesaplar.Length; i++)
            {
                liste = liste + string.Format("Ad: {0} Soyad: {1} Bakiye: {2}\n",hesaplar[i].kullanıcı.ad,hesaplar[i].kullanıcı.soyad,hesaplar[i].bakiye);
            }
            return liste;
        }
        public void ParaYAtır(Hesap hesap,decimal tutar)
        {
            hesap.bakiye += tutar;
        }
        public void HavaleYap(int gönderici, int alıcı ,decimal tutar)
        {
            hesaplar[gönderici].bakiye -= tutar;
            hesaplar[alıcı].bakiye += tutar;
        }
    }
}

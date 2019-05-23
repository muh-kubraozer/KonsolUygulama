using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka_Uygulaması
{
    class Kullanıcı
    {
        public string ad;
        public string soyad;

        public string _tcNo;
        public string tcNo
        {
            get { return _tcNo; }
            set
            {
                int toplam = 0; int toplam2 = 0; int toplam3 = 0;
                if ((value.Length == 11))
                {
                    if (Convert.ToInt32(value[0].ToString()) != 0) //tc kimlik numaranın ilk hanesi 0 değilse
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            toplam = toplam + Convert.ToInt32(value[i].ToString());
                            if (i % 2 == 0)
                            {
                                if (i != 10)
                                {
                                    toplam2 = toplam2 + Convert.ToInt32(value[i].ToString()); // 7 ile çarpılacak sayıları topluyoruz
                                }

                            }
                            else
                            {
                                if (i != 9)
                                {
                                    toplam3 = toplam3 + Convert.ToInt32(value[i].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                       
                        throw new ArgumentOutOfRangeException("Tc Kimlik Numaranızın ilk hanesi 0 olamaz.");
                    }
                }
                else
                {
                   
                    throw new ArgumentOutOfRangeException("Tc Kimlik Numarınız 11 haneli olmak zorunda.Eksik ya da fazla değer girdiniz.");
                }
               if (((toplam2 * 7) - toplam3) % 10 != Convert.ToInt32(value[9].ToString()) && toplam % 10 != Convert.ToInt32(value[10].ToString()))
                {
                    
                    throw new Exception("Tc numaraı yanlış");
                }
               
               
            }
        }
    }
        }

    


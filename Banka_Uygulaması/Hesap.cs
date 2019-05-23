using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka_Uygulaması
{

    class Hesap
    {
        public string _hesapNo;
        public Kullanıcı kullanıcı;
        public decimal _bakiye;
        public decimal bakiye
        {
            get { return _bakiye; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Bakiyeniz sıfırdan küçük.");
                }
                _bakiye = value;
            }
        }
        public string hesapNo
        {
            get { return _hesapNo; }
            set
            {

                char[] array = value.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {

                    if (!Char.IsDigit(array[i]))
                    {
                        throw new ArgumentOutOfRangeException("hatalı");
                    }
                    else
                    {
                        if (!(array.Length == 6))
                        {
                            throw new ArgumentOutOfRangeException("hatalı");
                        }
                    }

                }

            }
        }

    }
}



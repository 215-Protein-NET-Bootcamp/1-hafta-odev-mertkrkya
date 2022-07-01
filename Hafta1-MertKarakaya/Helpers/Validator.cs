using Hafta1_MertKarakaya.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta1_MertKarakaya.Helpers
{
    public class Validator
    {
        public static string RequestValidator(MainRequest request)
        {
            int vadeMiktari;
            double anaPara;
            if(!string.IsNullOrWhiteSpace(request.anaPara))
                request.anaPara = clearDotandCommainString(request.anaPara);
            if (string.IsNullOrWhiteSpace(request.vadeMiktari) && string.IsNullOrWhiteSpace(request.anaPara))
            {
                return "Vade Miktari ve Ana Para değeri boş bırakılamaz.";
            }
            if(!int.TryParse(request.vadeMiktari,out vadeMiktari))
            {
                return "Geçerli vade miktari girilmelidir.";
            }
            if (!double.TryParse(request.anaPara, out anaPara))
            {
                return "Geçerli ana para girilmelidir.";
            }
            if (GlobalConfigurations.MaxVadeTutari != -1 && GlobalConfigurations.MinVadeTutari != -1)
            {
                if (vadeMiktari > GlobalConfigurations.MaxVadeTutari || vadeMiktari < GlobalConfigurations.MinVadeTutari)
                {
                    return "Vade Tutarına " + GlobalConfigurations.MinVadeTutari + " ten küçük, " + GlobalConfigurations.MaxVadeTutari + " den büyük değer girilemez.";
                }
            }
            if (anaPara < 0)
            {
                return "Kredi Tutarına negatif değer girilemez.";
            }
            return null;
        }
        public static string clearDotandCommainString(string data)
        {
            data = data.Replace(",", "");
            data = data.Replace(".", "");
            return data;
        }
    }
}

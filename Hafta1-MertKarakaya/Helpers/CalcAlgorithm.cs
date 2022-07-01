using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hafta1_MertKarakaya.Entities;
using Hafta1_MertKarakaya.Models;

namespace Hafta1_MertKarakaya.Helpers
{
    public class CalcAlgorithm
    {
        public static Response FaizHesapla(int vadeTutari, double istenilenMiktar)
        {
            var tutar = new Tutar();
            if(GlobalConfigurations.FaizOrani == -1)
            {
                return new Response(errorMessage: "Sistemde bir hata meydana gelmiştir.");
            }
            var faizOrani = GlobalConfigurations.FaizOrani / 100;
            tutar.odenecekFaizTutari = faizOrani * vadeTutari * istenilenMiktar;
            tutar.geriOdenecektoplamTutar = tutar.odenecekFaizTutari + istenilenMiktar;
            return new Response(data : tutar);
        }
        public static OdemePlani OdemePlaniOlustur(int vadeTutari, double istenilenMiktar)
        {
            return new OdemePlani();
        }
    }
}

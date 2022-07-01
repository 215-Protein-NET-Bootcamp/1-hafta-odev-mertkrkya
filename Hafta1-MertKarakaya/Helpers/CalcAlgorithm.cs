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
        public static Response OdemePlaniOlustur(int vadeTutari, double istenilenMiktar)
        {
            var tutarResponse = FaizHesapla(vadeTutari, istenilenMiktar);
            var tutar = (Tutar)tutarResponse.data;
            if (GlobalConfigurations.FaizOrani == -1)
            {
                return new Response(errorMessage: "Sistemde bir hata meydana gelmiştir.");
            }
            var faizOrani = GlobalConfigurations.FaizOrani / 100;
            var odemePlani = new OdemePlani();
            odemePlani.geriOdenecektoplamTutar = tutar.geriOdenecektoplamTutar;
            odemePlani.odenecekFaizTutari = tutar.odenecekFaizTutari;
            odemePlani.FaizOrani = GlobalConfigurations.FaizOrani;
            odemePlani.OdemeTablosu = new List<OdemeTablosuData>();
            var aylikTutar = AylikTaksitHesapla(faizOrani, istenilenMiktar, vadeTutari);
            var kacAy = (int)odemePlani.geriOdenecektoplamTutar / aylikTutar;
            int ayCount = 1;
            while(ayCount <= vadeTutari)
            {
                var odemeTablosuData = new OdemeTablosuData();
                var aylikFaiz = istenilenMiktar * faizOrani;
                odemeTablosuData.Taksit = ayCount;
                odemeTablosuData.FaizTutari = aylikFaiz;
                odemeTablosuData.AnaParaTutari = aylikTutar - aylikFaiz;
                odemeTablosuData.TaksitTutari = aylikTutar;
                istenilenMiktar = istenilenMiktar - aylikTutar;
                odemeTablosuData.KalanAnaParaTutari = istenilenMiktar;
                odemePlani.OdemeTablosu.Add(odemeTablosuData);
                kacAy--;
                ayCount++;
            }
            return new Response(data: odemePlani);
        }
        public static double AylikTaksitHesapla(double faizOrani, double anaPara, int vadeTutari)
        {
            var q = faizOrani + 1;
            return (anaPara * Math.Pow(q, vadeTutari) * faizOrani) / (Math.Pow(q, vadeTutari) - 1);
        }
    }
}

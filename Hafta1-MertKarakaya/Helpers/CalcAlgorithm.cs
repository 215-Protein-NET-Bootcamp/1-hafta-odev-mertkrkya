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
            var baslangicMiktari = istenilenMiktar;
            int count = 0;
            double odenecekFaizTutari = 0;
            var aylikTutar = AylikTaksitHesapla(faizOrani, istenilenMiktar, vadeTutari);
            while (count<vadeTutari)
            {
                var aylikFaiz = istenilenMiktar * faizOrani;
                var anaparatutari = aylikTutar - aylikFaiz;
                odenecekFaizTutari += aylikFaiz;
                istenilenMiktar -= anaparatutari;
                count++;
            }
            tutar.odenecekFaizTutari = odenecekFaizTutari;
            tutar.geriOdenecektoplamTutar = tutar.odenecekFaizTutari + baslangicMiktari;
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
            var aylikTutar = odemePlani.geriOdenecektoplamTutar / vadeTutari;
            aylikTutar = Math.Round(aylikTutar, 2);
            double kalanTutar = 0;
            if(odemePlani.geriOdenecektoplamTutar - (aylikTutar * vadeTutari) > 0)
                kalanTutar = odemePlani.geriOdenecektoplamTutar - (aylikTutar * vadeTutari);
            var geriOdenecekTutar = odemePlani.geriOdenecektoplamTutar;
            int ayCount = 1;
            while(ayCount <= vadeTutari)
            {
                var odemeTablosuData = new OdemeTablosuData();
                var aylikFaiz = geriOdenecekTutar * faizOrani;
                if(vadeTutari -1 == ayCount)
                    aylikTutar += kalanTutar;
                odemeTablosuData.Taksit = ayCount;
                odemeTablosuData.FaizTutari = Math.Round(aylikFaiz,2);
                odemeTablosuData.AnaParaTutari = Math.Round(aylikTutar - aylikFaiz,2);
                odemeTablosuData.TaksitTutari = aylikTutar;
                istenilenMiktar = istenilenMiktar - aylikTutar;
                geriOdenecekTutar -= aylikTutar;
                if (geriOdenecekTutar < 0 && geriOdenecekTutar > -1)
                    geriOdenecekTutar = 0; //Virgülden meydana gelen hataların 0'lanması için.
                odemeTablosuData.KalanTutar = Math.Round(geriOdenecekTutar,2);
                odemePlani.OdemeTablosu.Add(odemeTablosuData);
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

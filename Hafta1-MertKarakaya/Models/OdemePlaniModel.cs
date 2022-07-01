using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta1_MertKarakaya.Models
{
    public class OdemePlani : Tutar
    {
        public double FaizOrani { get; set; }
        public List<OdemeTablosuData> OdemeTablosu { get; set; }
    }
    public class OdemeTablosuData
    {
        public int Taksit { get; set; }
        public double TaksitTutari { get; set; }
        public double AnaParaTutari { get; set; }
        public double FaizTutari { get; set; }
        public double KalanTutar { get; set; }
    }
}

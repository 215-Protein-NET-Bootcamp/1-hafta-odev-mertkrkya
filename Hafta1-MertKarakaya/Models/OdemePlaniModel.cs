using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta1_MertKarakaya.Models
{
    public class OdemePlani : Tutar
    {
        public double KKDFOrani { get; set; }
        public double BSMVOrani { get; set; }
        public double FaizOrani { get; set; }
        public List<OdemeTutari> OdemeTutarlari { get; set; }
    }
    public class OdemeTutari
    {
        public int Taksit { get; set; }
        public long TaksitTutari { get; set; }
        public long AnaParaTutari { get; set; }
        public long FaizTutari { get; set; }
        public long KKDFTutari { get; set; }
        public long BSMVTutari { get; set; }
        public long KalanAnaParaTutari { get; set; }
    }
}

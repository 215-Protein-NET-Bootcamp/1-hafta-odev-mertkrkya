using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta1_MertKarakaya.Helpers
{
    public class ConfigurationSettings
    {
        public string FaizOrani { get; set; }
        public string KKDFOrani { get; set; }
        public string BSMVOrani { get; set; }
    }
    public static class GlobalConfigurations
    {
        public static double FaizOrani { get; set; }
        public static double KKDFOrani { get; set; }
        public static double BSMVOrani { get; set; }

        public static void InitializeGlobalConfiguration(ConfigurationSettings configurationSettings)
        {
            double faizOrani, kkdfOrani, bsmvOrani;
            if(double.TryParse(configurationSettings.FaizOrani,out faizOrani))
            {
                FaizOrani = faizOrani;
            }
            if (double.TryParse(configurationSettings.KKDFOrani, out kkdfOrani))
            {
                KKDFOrani = kkdfOrani;
            }
            if (double.TryParse(configurationSettings.BSMVOrani, out bsmvOrani))
            {
                BSMVOrani = bsmvOrani;
            }
        }
    }
}

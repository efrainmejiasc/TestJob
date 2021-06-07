using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestJobApi.Aplication
{
    public class EngineData
    {
        private static EngineData valor;
        public static EngineData Instance()
        {
            if ((valor == null))
            {
                valor = new EngineData();
            }
            return valor;
        }

        public static string Audience { get; set; }

        public static string Key { get; set; }

        public static string Issuer { get; set; }

    }
}

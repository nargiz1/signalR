using AznToCurrencyApi.Cbar.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AznToCurrencyApi.Cbar
{
    public class CbarServer
    {
        public static ValCurs GetCurrencyData()
        {
            string responseFromCbarClient = CbarClient.GetCurrencyRawData();
            StringReader sr = new StringReader(responseFromCbarClient);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ValCurs));
            ValCurs data = (ValCurs)xmlSerializer.Deserialize(sr);
            return data;
        }
    }
}

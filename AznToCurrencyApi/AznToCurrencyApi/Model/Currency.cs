using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AznToCurrencyApi.Model
{
    public class Currency
    {
        public int Id { get; set; }
        public string Nominal { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }

        public Currency()
        { }

        public Currency(string Nominal, string Name, string Value, string Code)
        {
            this.Nominal = Nominal;
            this.Name = Name;
            this.Value = Value;
            this.Code = Code;
        }
    }
}

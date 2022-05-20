using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AznToCurrencyApi.Model
{
    public class CbarLog
    {
        public int Id { get; set; }
        public DateTime LastGet { get; set; }
        public CbarLog()
        {
            this.LastGet = DateTime.Now;
        }
    }
}

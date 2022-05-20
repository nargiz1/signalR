using AznToCurrencyApi.DAL;
using AznToCurrencyApi.Model;
using AznToCurrencyApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AznToCurrencyApi.Controllers
{
    [Route("currency")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly CurrencyService currencyService;
        public CurrencyController(AppDbContext _db)
        {
            db = _db;
            currencyService = new CurrencyService(_db);
        }

        [HttpGet]
        public ActionResult<List<Currency>> Get()
        {
            return currencyService.GetAllCurrencies();
        }

        [HttpGet("toAzn")]
        public ActionResult<decimal> toAzn(string code, decimal amount)
        {
            try
            {
                return currencyService.ConvertToAzn(amount, code);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("fromAzn")]
        public ActionResult<decimal> fromAzn(string code, decimal amount)
        {
            try
            {
                return currencyService.ConvertFromAzn(amount, code);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

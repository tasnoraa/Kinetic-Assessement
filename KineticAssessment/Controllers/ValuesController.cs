using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KineticAssessment.Interface;
using KineticAssessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace KineticAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly ICoinJar _coinJar;
        public ValuesController(ICoinJar coinJar)
        {
            _coinJar = coinJar;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "$"+_coinJar.GetTotalAmount();
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] Coin coin)
        {
            _coinJar.AddCoin(coin);
        }

        // DELETE api/values/5
        [HttpDelete()]
        public void Delete()
        {
            _coinJar.Reset();
        }
    }
}

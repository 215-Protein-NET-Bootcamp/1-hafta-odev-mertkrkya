using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hafta1_MertKarakaya.Entities;
using Hafta1_MertKarakaya.Helpers;

namespace Hafta1_MertKarakaya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        [HttpPost]
        [Route("Faiz")]
        public IActionResult FaizPost([FromBody] MainRequest request)
        {
            var errMsg = Validator.RequestValidator(request);
            if (!string.IsNullOrWhiteSpace(errMsg))
            {
                return BadRequest(new Response(errorMessage: errMsg));
            }
            var vadeMiktari = int.Parse(request.vadeMiktari);
            var anaPara = double.Parse(request.anaPara);
            var calcValue = CalcAlgorithm.FaizHesapla(vadeMiktari, anaPara);
            if (!calcValue.success)
                return BadRequest(calcValue);
            else
                return Ok(calcValue);
        }
        [HttpPost]
        [Route("OdemePlani")]
        public IActionResult OdemePlaniPost([FromBody] MainRequest request)
        {
            var errMsg = Validator.RequestValidator(request);
            if (!string.IsNullOrWhiteSpace(errMsg))
            {
                return BadRequest(new Response(errorMessage: errMsg));
            }
            var vadeMiktari = int.Parse(request.vadeMiktari);
            var anaPara = double.Parse(request.anaPara);
            var calcValue = CalcAlgorithm.OdemePlaniOlustur(vadeMiktari, anaPara);
            if (!calcValue.success)
                return BadRequest(calcValue);
            else
                return Ok(new Response(calcValue));
        }
    }
}

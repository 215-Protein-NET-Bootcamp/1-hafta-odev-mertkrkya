using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta1_MertKarakaya.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OdemePlaniController : ControllerBase
    {

        private readonly ILogger<OdemePlaniController> _logger;

        public OdemePlaniController(ILogger<OdemePlaniController> logger)
        {
            _logger = logger;
        }

    }
}

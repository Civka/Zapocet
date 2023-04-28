using Microsoft.AspNetCore.Mvc;
using Zapocet.Data.Dto;
using Zapocet.Filters;
using Zapocet.Services.Interfaces;
using Zapocet.Data.Model;
using Zapocet.Services;

namespace Zapocet.Controllers
{

    [ApiController]
    [Route("Eshop")]
    public class EshopController : Controller
    {

        IEshopService _eshopservice;
        public EshopController(IEshopService eshopservice, ILogger<EshopController> log)
        {
            _eshopservice = eshopservice;
        }

        [IdentityFilter]
        [HttpPost]
        [Route("Add")]
        public IActionResult Post(List<EshopDto> eshopDtos)
        {
            return Ok(_eshopservice.AddEshopData(eshopDtos));
        }

        [IdentityFilter]
        [HttpGet]
        [Route("Get")]
        public IActionResult GetEshopData()
        {
            return Ok(_eshopservice.GetEshopData());
        }
    }
}

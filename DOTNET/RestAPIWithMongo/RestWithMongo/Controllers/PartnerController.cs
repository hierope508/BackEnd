using RestWithMongo.BLL;
using RestWithMongo.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RestWithMongo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartnerController : Controller
    {
        private readonly BLLPartner _bllPartner;

        public PartnerController(BLLPartner bllPartner)
        {
            _bllPartner = bllPartner;
        }

        // GET: PartnerController/Get
        [HttpGet(Name = "GetPartner")]
        public ActionResult<Partner> Get([FromQuery] string id)
        {
            try
            {
                var partner = _bllPartner.GetPartner(id);

                if (partner == null)
                {
                    return NotFound();
                }

                return partner;
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        // POST: PartnerController/Create
        [HttpPost]
        public ActionResult<Partner> Create(Partner partner)
        {
            try
            {
                _bllPartner.Insert(partner);
                return partner;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

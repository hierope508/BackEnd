using RestWithMongo.BLL;
using RestWithMongo.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RestWithMongo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartnerLocationController : Controller
    {
        private readonly BLLPartner _bllPartner;

        public PartnerLocationController(BLLPartner bllPartner)
        {
            _bllPartner = bllPartner;
        }

        [HttpGet]
        public ActionResult<List<Partner>> GetClosestPartners(double longitude, double latitude)
        {
            try
            {
                return _bllPartner.GetClosestPartners(longitude, latitude);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}

using RestWithMongo.DAL;
using RestWithMongo.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace RestWithMongo.BLL
{
    public class BLLPartner
    {
        private readonly DALPartner _dalPartner;

        public BLLPartner(DALPartner dALPartner)
        {
            _dalPartner = dALPartner;
        }

        /// <summary>
        /// Insert a Partner object in the database
        /// </summary>
        /// <param name="partner">The partner to be created</param>
        /// <returns>A Partner</returns>
        public Partner Insert(Partner partner)
        {
            try
            {
                return _dalPartner.Insert(partner);
            }
            catch (Exception ex)
            {
                throw new System.Web.Http.HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.InnerException.Message),
                    ReasonPhrase = "Critical Exception"
                });
            }
        }


        /// <summary>
        /// Get a Partner from the database
        /// </summary>
        /// <param name="id">The Id of the partner</param>
        /// <returns>A Partner</returns>
        public Partner GetPartner(string id)
        {
            try
            {
                return _dalPartner.GetPartner(id);
            }
            catch (Exception ex)
            {
                throw new System.Web.Http.HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.InnerException.Message),
                    ReasonPhrase = "Critical Exception"
                });
            }
        }

        /// <summary>
        /// Gets the closest partners based on the longitude and latitude provided
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns>A list of partners</returns>
        public List<Partner> GetClosestPartners(double longitude, double latitude)
        {
            try
            {
                return _dalPartner.GetClosestPartners(longitude, latitude);
            }
            catch (Exception ex)
            {
                throw new System.Web.Http.HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.InnerException.Message),
                    ReasonPhrase = "Critical Exception"
                });
            }
        }
    }
}

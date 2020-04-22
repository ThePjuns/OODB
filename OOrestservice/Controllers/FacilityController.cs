using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Manage;
using Model;

namespace OOrestservice.Controllers
{
    public class FacilityController : ApiController
    {
        // GET: api/Facility
        public IEnumerable<Facility> Get()
        {
            return new ManageFacilities().GetAll();
            //return new string[] { "value1", "value2" };

        }

        // GET: api/Facility/5
        public Facility Get(int id)
        {
            return new ManageFacilities().GetFromId(id);
            //return "value";
        }

        // POST: api/Facility
        public void Post([FromBody]Facility value)
        {
            new ManageFacilities().Create(value);
        }

        // PUT: api/Facility/5
        public void Put(int id, [FromBody]Facility value)
        {
            new ManageFacilities().Update(value, id);
        }

        // DELETE: api/Facility/5
        public void Delete(int id)
        {
            new ManageFacilities().Delete(id);
        }
    }
}

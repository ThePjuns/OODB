﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Manage;
using Model;

namespace OOrestservice.Controllers
{
    public class HotelController : ApiController
    {
        // GET: api/Hotel
        public IEnumerable<Hotel> Get()
        {
            return new ManageHotel().GetAll();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Hotel/5
        public Hotel Get(int id)
        {
            return new ManageHotel().GetFromId(id);
            //return "value";
        }

        // POST: api/Hotel
        public void Post([FromBody]Hotel value)
        {
            new ManageHotel().Create(value);
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]Hotel value)
        {
            new ManageHotel().Update(value, id);
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
            new ManageHotel().Delete(id);
        }
    }
}

using DXWebApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DXWebApplication3.Controllers
{
    public class WebApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<MyModel> GetList(string query = "")
        {
            var ds = CustomerList.GenerateList();
            ds = String.IsNullOrEmpty(query) ? ds : ds.Where(p => p.FirstName.Contains(query)).ToList();
            return ds;
        }
    }
}

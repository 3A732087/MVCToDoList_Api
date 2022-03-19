using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCToDoList_Api.Controllers
{
    public class ToDoListApiController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return "TEST";
        }
    }
}

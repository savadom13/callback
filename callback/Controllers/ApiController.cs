using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using callback;
using callback.Db;
using Newtonsoft.Json;

namespace callback.Controllers
{
    [Produces("application/json")]
    public class ApiController : Controller
    {

        

        [HttpPost]
        public void Callback([FromBody]object value)
        {

            using (CallbackContext context = new CallbackContext())
            {
                Models.callback data = new Models.callback
                {
                    Data = value.ToString(),
                    Ip = HttpContext.Connection.RemoteIpAddress.ToString(),
                    Time = DateTime.Now
                };

                context.Add(data);
                context.SaveChanges();
            }




        }

        [HttpGet]
        public IActionResult Callback()
        {
            List<Models.callback> list = new List<Models.callback>();

            using (CallbackContext context = new CallbackContext())
            {
                //list.AddRange(context.Callbacks.ToList());

                var t = context.Callbacks.ToList();
                ViewBag.Data = t;
            }


            // = list;
            //ViewBag.Data1 = Json(list[0].Data);
            return View();
            //return Json(ViewBag.Data);
        }

    }
}
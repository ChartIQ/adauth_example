using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace test1.Controllers
{
    public class Manifest
    {
        public string Username { get; set; }
        public Dictionary<string, string> Window { get; set; }
        public Dictionary<string, string> Component { get; set; }
        public Dictionary<string, string> Foreign { get; set; }
        public Dictionary<string, string> Components { get; set; }
        public Dictionary<string, string> WindowManager { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            string opl = "Not Authenticated";
            if (User.Identity.IsAuthenticated)
            {
                opl = User.Identity.Name;
            }
            // Return a json file based on the user
            string newopl = @".\" + opl.Substring(opl.IndexOf('\\') + 1) + ".json";

            // string text = System.IO.File.ReadAllText(@".\normaluser.json");
            string text = "No file found.";
            if (System.IO.File.Exists(newopl))
            {
                text = System.IO.File.ReadAllText(newopl);
            }
            else
            {
                text = System.IO.File.ReadAllText(@".\normaluser.json");
            }

            //string json = JsonConvert.SerializeObject(manifest);
            return text;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

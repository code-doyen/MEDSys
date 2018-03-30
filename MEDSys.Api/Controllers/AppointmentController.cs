using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MEDSys.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AppointmentController : Controller
    {
        private static string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Blazing"
        };

        [HttpGet]
        public IEnumerable<Appointment> Appointments()
        {
            int i = 0;
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Appointment
            {
                Id = ++i,
                ClientName = Summaries[rng.Next(Summaries.Length)],
                ClientLastName = Summaries[rng.Next(Summaries.Length)],
                ClientBirthday = Summaries[rng.Next(Summaries.Length)],
                StaffName = Summaries[rng.Next(Summaries.Length)],
                StaffLastName = Summaries[rng.Next(Summaries.Length)],
                StaffSpecialty = Summaries[rng.Next(Summaries.Length)],
                ServiceLine = Summaries[rng.Next(Summaries.Length)],
                ServiceLineStartDate = Summaries[rng.Next(Summaries.Length)],
                ServiceLineEndDate = Summaries[rng.Next(Summaries.Length)]
            });

        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "amazin", "value2" };
        }
        [HttpPost]
        public IActionResult AddAppointment([FromBody]Appointment appointment)
        {
            
            return Ok(appointment);
        }

        public class Appointment
        {
            public int Id { get; set; }
            public string ClientName{ get; set; }
            public string ClientLastName{ get; set; }
            public string ClientBirthday{ get; set; }
            public string StaffName{ get; set; }
            public string StaffLastName{ get; set; }
            public string StaffSpecialty{ get; set; }
            public string ServiceLine{ get; set; }
            public string ServiceLineStartDate{ get; set; }
            public string ServiceLineEndDate{ get; set; }
        }


        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

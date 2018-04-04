using System;
using System.Threading.Tasks;
using MEDSys.Api.Data;
using MEDSys.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEDSys.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AppointmentController : Controller
    {
        private readonly AppointmentContext _context = new AppointmentContext();
        
        [HttpGet]
        public async Task<IActionResult> Appointments()
        {

            var resultSet = await _context.AppointmentQueries.ToListAsync<Appointment>();

            if (resultSet == null)
            {
                return NotFound();
            }
            return Ok(resultSet);

        }
      
        [HttpPost]
        public IActionResult AddAppointment([FromBody] Appointment payload)
        {
            using (var db = new AppointmentContext())
            {

                DateTime betweenStartDate = new DateTime(payload.ServiceLineStartDate.Year, payload.ServiceLineStartDate.Month, payload.ServiceLineStartDate.Day, 0, 0, 0);
                DateTime betweenEndDate = new DateTime(payload.ServiceLineStartDate.Year, payload.ServiceLineStartDate.Month, payload.ServiceLineStartDate.Day, 23, 59, 59);
                int numberOfDays = (int)(payload.ServiceLineEndDate - payload.ServiceLineStartDate).TotalDays;
               
                Console.WriteLine(numberOfDays);
                //service occurred same day.
                if (numberOfDays <= 1)
                {
                    if ((payload.ServiceLineEndDate.Day > payload.ServiceLineStartDate.Day ||
                                  payload.ServiceLineEndDate.Month > payload.ServiceLineStartDate.Month ||
                                  payload.ServiceLineEndDate.Year > payload.ServiceLineStartDate.Year))
                    {

                        db.AppointmentQueries.Add(new Appointment
                        {

                            ServiceLineStartDate = payload.ServiceLineStartDate, //DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)              
                            ServiceLineEndDate = new DateTime(payload.ServiceLineStartDate.Year, payload.ServiceLineStartDate.Month, payload.ServiceLineStartDate.Day, 23, 59, 59),
                            ServiceLine = payload.ServiceLine,
                            ClientName = payload.ClientName,
                            ClientLastName = payload.ClientLastName,
                            ClientBirthday = payload.ClientBirthday,
                            StaffName = payload.StaffName,
                            StaffLastName = payload.StaffLastName,
                            StaffSpecialty = payload.StaffSpecialty

                        });
                        db.AppointmentQueries.Add(new Appointment
                        {
                            //DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
                            ServiceLineStartDate = new DateTime(payload.ServiceLineEndDate.Year, payload.ServiceLineEndDate.Month, payload.ServiceLineEndDate.Day, 0, 0, 0),
                            ServiceLineEndDate = payload.ServiceLineEndDate,
                            ServiceLine = payload.ServiceLine,
                            ClientName = payload.ClientName,
                            ClientLastName = payload.ClientLastName,
                            ClientBirthday = payload.ClientBirthday,
                            StaffName = payload.StaffName,
                            StaffLastName = payload.StaffLastName,
                            StaffSpecialty = payload.StaffSpecialty

                        });
                    }
                    else
                    {

                        db.AppointmentQueries.Add(new Appointment
                        {

                            ServiceLineStartDate = payload.ServiceLineStartDate,
                            ServiceLineEndDate = payload.ServiceLineEndDate,
                            ServiceLine = payload.ServiceLine,
                            ClientName = payload.ClientName,
                            ClientLastName = payload.ClientLastName,
                            ClientBirthday = payload.ClientBirthday,
                            StaffName = payload.StaffName,
                            StaffLastName = payload.StaffLastName,
                            StaffSpecialty = payload.StaffSpecialty

                        });
                    }
                }
                else
                {
                    for (int daysLapsed = 0; daysLapsed <= numberOfDays; daysLapsed++)
                    {
                        if (daysLapsed == 0)
                        {
                            db.AppointmentQueries.Add(new Appointment
                            {
                                    
                                ServiceLineStartDate = payload.ServiceLineStartDate, //DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)              
                                ServiceLineEndDate = new DateTime(payload.ServiceLineStartDate.Year, payload.ServiceLineStartDate.Month, payload.ServiceLineStartDate.Day, 23, 59, 59),
                                ServiceLine = payload.ServiceLine,
                                ClientName = payload.ClientName,
                                ClientLastName = payload.ClientLastName,
                                ClientBirthday = payload.ClientBirthday,
                                StaffName = payload.StaffName,
                                StaffLastName = payload.StaffLastName,
                                StaffSpecialty = payload.StaffSpecialty

                            });
                        }
                        else if (daysLapsed < numberOfDays) 
                        {
                            db.AppointmentQueries.Add(new Appointment
                            {

                                ServiceLineStartDate = betweenStartDate,
                                ServiceLineEndDate = betweenEndDate,
                                ServiceLine = payload.ServiceLine,
                                ClientName = payload.ClientName,
                                ClientLastName = payload.ClientLastName,
                                ClientBirthday = payload.ClientBirthday,
                                StaffName = payload.StaffName,
                                StaffLastName = payload.StaffLastName,
                                StaffSpecialty = payload.StaffSpecialty

                            });
                        }
                        else
                        {
                            db.AppointmentQueries.Add(new Appointment
                            {
                                //DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
                                ServiceLineStartDate = new DateTime(payload.ServiceLineEndDate.Year, payload.ServiceLineEndDate.Month, payload.ServiceLineEndDate.Day, 0, 0, 0),
                                ServiceLineEndDate = payload.ServiceLineEndDate,
                                ServiceLine = payload.ServiceLine,
                                ClientName = payload.ClientName,
                                ClientLastName = payload.ClientLastName,
                                ClientBirthday = payload.ClientBirthday,
                                StaffName = payload.StaffName,
                                StaffLastName = payload.StaffLastName,
                                StaffSpecialty = payload.StaffSpecialty

                            });
                        }
                        betweenStartDate = betweenStartDate.AddDays(1);
                        betweenEndDate = betweenEndDate.AddDays(1);
                    }
                }
                //db.Database.ExecuteSqlCommand("UPDATE Service SET ClientID={0} WHERE ServiceID={0}", cnt);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
                Console.WriteLine();
                
            }
            return Ok("Client Appointment scheduled");
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

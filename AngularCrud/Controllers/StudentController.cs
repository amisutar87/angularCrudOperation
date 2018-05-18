using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularCrud.Model;
using AngularCrud.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AngularCrud.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        public readonly StudentContext context;
        private readonly IConfiguration configuration = null;

        public StudentController(IConfiguration configuration,StudentContext _context)
        {
            this.context = _context;
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var list = context.Students.Select(s => s).ToList();
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(new { status = 400, messagetext =ex.Message });
            }
         
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody]StudentViewModel studentobj)
        {
            Student obj = new Student();

            try
            {
                if (obj != null)
                {
                    obj.Name = studentobj.name;
                    obj.Mobile = studentobj.mobile;
                    obj.Address = studentobj.address;
                    context.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = 400, messagetext = ex.Message });
            }
        
            return Json(obj);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int id)
        {
            var data = context.Students.Where(obj => obj.StudentID == id).Select(obj => obj).FirstOrDefault();
            StudentViewModel studentobj = new StudentViewModel();
            try
            {
                if (data != null)
                {
                    data.Name = studentobj.name;
                    data.Mobile = studentobj.mobile;
                    data.Address = studentobj.address;

                    context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = 400, messagetext = ex.Message });
            }
           
            return Json(data);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var record = context.Students.Where(obj => obj.StudentID == id).Select(obj => obj).FirstOrDefault();

            try
            {
                context.Students.Remove(record);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new { status = 400, messagestatus = ex.Message });
            }
            return null;
        }
    }
}
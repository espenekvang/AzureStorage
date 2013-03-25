using System.Collections.Generic;
using System.Web.Mvc;
using PersonTableStorage.WebRole.Models;

namespace PersonTableStorage.WebRole.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Person/

        public ActionResult Index()
        {
            var persons = new List<Person>
                              {
                                  new Person
                                      {
                                          FirstName = "Albert",
                                          LastName = "Einstein",
                                          Email = "albert@einstein.com"
                                      },
                                  new Person
                                      {
                                          FirstName = "Isaac",
                                          LastName = "Newton",
                                          Email = "isaac@newton.com"
                                      }
                              };
            var company = new Company { Persons = persons };
            return View(company);
        }
    }
}

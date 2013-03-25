using System.Web.Mvc;
using PersonSQLDatabase.WebRole.Models;

namespace PersonSQLDatabase.WebRole.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult Index()
        {
            var company = new Company();
            company.PopulateWithPersons();

            return View(company);
        }

    }
}

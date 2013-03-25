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
            var company = new Company("MyCompany");
            company.PopulateWithPersons();

            return View(company);
        }
    }
}

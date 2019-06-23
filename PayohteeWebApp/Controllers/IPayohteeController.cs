using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PayohteeWebApp.Controllers
{
    interface IPayohteeController
    {
        [HttpPost]
        Task<ActionResult> Register(string jsonobject);

        [HttpGet]
        Task<ViewResult> Index(string name);

        [HttpGet]
        Task<IActionResult> DetailsName(string name);

        [HttpGet]
        Task<ActionResult> Details(int? id);

        [HttpGet]
        Task<ActionResult> Lookup(string charinput);

        [HttpPost]
        Task<ActionResult> Update(int id, string jsonobject);

        [HttpPost]
        Task<ActionResult> Delete(int id);

        bool EmployeeExists(int id);
    }
}

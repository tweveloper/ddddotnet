using AllregoSoft.WebManagementSystem.WebApplication.Filters;
using AllregoSoft.WebManagementSystem.WebApplication.Helpers;
using AllregoSoft.WebManagementSystem.WebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    public class SIteManageController : Controller
    {
        public SIteManageController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

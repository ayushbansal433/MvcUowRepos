using MvcUowRepos.Services.IMvcUowReposServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcUowRepos.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            return this.Json(await _userService.GetAllUsers());
        }
    }
}
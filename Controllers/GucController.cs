using GUC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUC.Controllers
{
    [Route("GUC/")]
    public class GucController : Controller
    {
        readonly IGucRepo _gucRepo;
        public GucController(IGucRepo gucRepo)
        {
            _gucRepo = gucRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("")]
        public IActionResult test()
        {
            return Ok();
        }

        [HttpGet("ListDto")]
        public IActionResult GetList()
        {
            var list = _gucRepo.GetList();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);

        }
    }
}

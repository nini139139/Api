using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        //public BaseApiController(DataContxt context)
        //{
        //    _context = context;
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

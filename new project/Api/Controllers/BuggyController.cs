using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Data;
using Api.Domain.Entity.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContxt _contxt;

        public BuggyController(DataContxt contxt)
        {
            _contxt = contxt;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> Index()
        {
            return "";
        }

        [HttpGet("not-found")]
        public ActionResult<User> GetNotFound()
        {
            var thing = _contxt.Users.Find(-1);
            if (thing == null) return NotFound();

            return Ok(thing);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _contxt.Users.Find(-1);

            var thingToReturn = thing.ToString();
            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("this wasnot a good request");
        }
    }
}

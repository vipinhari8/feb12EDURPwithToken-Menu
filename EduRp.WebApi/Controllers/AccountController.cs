using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using EduRp.WebApi.Models;
using EduRp.WebApi.Providers;
using EduRp.WebApi.Results;
using EduRp.WebApi.Repository;
using EduRp.Service.IService;
using EduRp.Service.Service;
using System.Web.Http.Cors;

namespace EduRp.WebApi.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        private IUserService userService = new UserService();

        [HttpGet]
        public IHttpActionResult GetUser()
        {
            var userList = userService.GetUserList();
            return Ok(userList);
        }

        [HttpGet]
        [Route("api/account/getuser/{id}")]
        public IHttpActionResult GetUFirstUser(int id)
        {
            // Get user from dummy list
            var user = userService.GetUserById(id);
            return Ok(user);
        }
    }
}

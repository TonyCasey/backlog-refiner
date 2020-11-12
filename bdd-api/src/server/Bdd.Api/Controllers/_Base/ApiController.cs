using System;
using System.Linq;
using Bdd.Core;
using Microsoft.AspNetCore.Mvc;

namespace Bdd.Api.Controllers
{
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
        protected IActionResult Error(Error error) =>
            new BadRequestObjectResult(error);

        public Guid UserGuid => _userGuid;
        public Guid CompanyGuid => _companyGuid;
        public string CompanyDomain => _companyDomain;

        private Guid _userGuid;
        private Guid _companyGuid;
        private string _companyDomain;


        protected void InitUserCredentials()
        {
            if(User == null) return;
            
            _userGuid = new Guid(User.Claims.FirstOrDefault(i =>
                i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            _companyGuid = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyGuid").Value);
            _companyDomain = User.Claims.FirstOrDefault(x => x.Type == "CompanyDomain").Value;
        }
    }
}

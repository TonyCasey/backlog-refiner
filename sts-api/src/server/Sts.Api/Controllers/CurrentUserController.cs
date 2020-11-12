using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sts.Core.Services;

namespace Sts.Api.Controllers
{
    public class CurrentUserController : Controller
    {
        private readonly IUsersService _usersService;

        public CurrentUserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

    }
}
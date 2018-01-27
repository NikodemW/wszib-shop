using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public Guid CurrentUserId
            => User.Identity.IsAuthenticated ?
            Guid.Parse(User.Identity.Name) : Guid.Empty;
    }
}

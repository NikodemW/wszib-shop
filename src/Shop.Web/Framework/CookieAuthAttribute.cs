using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shop.Web.Framework
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CookieAuthAttribute : AuthorizeAttribute

    {
        public CookieAuthAttribute(string policy = "")

        {
            AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme;
            Policy = policy;
        }
    }
}

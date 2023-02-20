using Eagle.Config.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eagle.Config.Middleware
{
    internal class AuthMiddleware : BaseMiddleware
    {
        public AuthMiddleware(RequestDelegate next) : base(next)
        {
        }

        public override async Task Invoke(HttpContext context)
        {
            var userName = context.GetHeader("EGLUserName");
            var password = context.GetHeader("EGLPassword");
            var device = context.GetHeader("EGLDevice");
            var appType = context.GetHeader("EGLAppType");
        }
    }
}

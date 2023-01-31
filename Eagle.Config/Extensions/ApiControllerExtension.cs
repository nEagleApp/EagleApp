using Eagle.Config.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Eagle.Config.Extensions
{
    public static class ApiControllerExtension
    {
        public static IActionResult AsSuccessResult(
            this ControllerBase controller,
            string message)
            => AsActionResult<object>(controller, HttpStatusCode.OK, message, null);

        public static IActionResult AsSuccessResult<T>(
            this ControllerBase controller,
            string message,
            T? data)
            => AsActionResult(controller, HttpStatusCode.OK, message, data);

        public static IActionResult AsSuccessResult<T>(
            this ControllerBase controller,
            T? data)
            => AsActionResult(controller, HttpStatusCode.OK, string.Empty, data);

        private static IActionResult AsActionResult<T>(
            ControllerBase controller,
            HttpStatusCode statusCode,
            string message,
            T? data)
        {
            var statusCodeAsInt = (int)statusCode;
            var responseModel = new ApiResponse<T>
            {
                Data = data,
                Message = message,
                StatusCode = statusCodeAsInt
            };

            return controller.StatusCode(statusCodeAsInt, responseModel);
        }
    }

}

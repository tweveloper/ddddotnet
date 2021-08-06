using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error-local-development")]
        [HttpGet]
        public IActionResult ErrorLocalDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (context.Error is ServiceException)
            {
                return BadRequest(context.Error.Message);
            }
            else if (context.Error is SqlException)
            {
                var sqlException = context.Error as SqlException;
                if (HttpMethods.IsDelete(HttpContext.Request.Method) && sqlException.Number == 547) return BadRequest("이미 다른 화면에서 사용중이므로 삭제할 수 없습니다.");

                return BadRequest(context.Error.Message);
            }
            else if (context.Error.InnerException is SqlException)
            {
                var sqlException = context.Error.InnerException as SqlException;
                if (HttpMethods.IsDelete(HttpContext.Request.Method) && sqlException.Number == 547) return BadRequest("이미 다른 화면에서 사용중이므로 삭제할 수 없습니다.");

                return BadRequest(context.Error.InnerException.Message);
            }
            return Problem(
                type: context.Error.GetType().ToString(),
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

        [Route("/error")]
        [HttpGet]
        public IActionResult Error(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (context.Error is ServiceException)
            {
                return BadRequest(context.Error.Message);
            }
            else if (context.Error is SqlException)
            {
                var sqlException = context.Error as SqlException;
                if (HttpMethods.IsDelete(HttpContext.Request.Method) && sqlException.Number == 547) return BadRequest("이미 다른 화면에서 사용중이므로 삭제할 수 없습니다.");

                return BadRequest(context.Error.Message);
            }
            else if (context.Error.InnerException is SqlException)
            {
                var sqlException = context.Error.InnerException as SqlException;
                if (HttpMethods.IsDelete(HttpContext.Request.Method) && sqlException.Number == 547) return BadRequest("이미 다른 화면에서 사용중이므로 삭제할 수 없습니다.");

                return BadRequest(context.Error.InnerException.Message);
            }

            return Problem(
                type: context.Error.GetType().ToString(),
                title: context.Error.Message);
        }

        [Route("/error-default")]
        public IActionResult ErrorDefault() => Problem();
    }
}

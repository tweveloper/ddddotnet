using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
        private IIdentityService _identityService;
        protected IIdentityService IdentityService => _identityService ??= HttpContext.RequestServices.GetService<IIdentityService>();

    }
}

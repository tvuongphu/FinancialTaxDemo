using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTax.Api.V1.Controllers;

[ApiController]
//[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
public class NwController : ControllerBase;
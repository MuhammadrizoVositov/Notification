using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sms.Infrastructure.Persistanse.Repsitory.Interface;

namespace Sms.Infrastructure.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NotificationHistoriesController : ControllerBase
{
    [HttpGet("sms")]
    public async ValueTask<IActionResult> Get([FromServices] IEmailHistoryRepository repo) =>
     Ok(await repo.Get().ToListAsync());

    [HttpGet("email")]
    public async ValueTask<IActionResult> Get([FromServices] ISmsHistoryRepository repo) =>
        Ok(await repo.Get().ToListAsync());
}

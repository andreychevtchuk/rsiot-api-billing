using BugTrackerApiBilling.Dto.Requests;
using BugTrackerApiBilling.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerApiBilling.Controllers;

[ApiController]
[Route("billing")]
public class BillingController : ControllerBase
{
    private readonly IBillingService billingService;

    public BillingController(IBillingService billingService)
    {
        this.billingService = billingService;
    }

    [HttpPost]
    public async Task<ActionResult> TryExecute(OperationSourceRequest request)
    {
        var result = await billingService.TryExecute(request);
        return Ok(result);
    }
}
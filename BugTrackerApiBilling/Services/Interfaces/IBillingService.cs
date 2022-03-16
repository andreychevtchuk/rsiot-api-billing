using BugTrackerApiBilling.Dto.Requests;
using BugTrackerApiBilling.Dto.Responses;

namespace BugTrackerApiBilling.Services.Interfaces;

public interface IBillingService
{
    Task<ExecutionResultResponse> TryExecute(OperationSourceRequest request);
}
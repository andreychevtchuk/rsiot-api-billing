namespace BugTrackerApiBilling.Dto.Responses;

public class ExecutionResultResponse
{
    public bool IsAllowed { get; set; }
    public string? Reason { get; set; }
    public string? OperationType { get; set; }
}
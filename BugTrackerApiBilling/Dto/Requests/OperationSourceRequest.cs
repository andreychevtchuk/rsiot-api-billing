namespace BugTrackerApiBilling.Dto.Requests;

public class OperationSourceRequest
{
    public Guid OperationId { get; set; }
    public string? OperationType { get; set; }
}
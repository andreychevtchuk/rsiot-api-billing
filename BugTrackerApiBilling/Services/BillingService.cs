using BugTrackerApiBilling.Dto.Requests;
using BugTrackerApiBilling.Dto.Responses;
using BugTrackerApiBilling.Services.Interfaces;
using BugTrackerApiBilling.Settings;
using Google.Cloud.PubSub.V1;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BugTrackerApiBilling.Services;

public class BillingService : IBillingService
{
    private readonly GCloudIntegrationSettings settings;
    private int operationCount;

    public string[] reasons = {
        "reason 1",
        "reason 2",
        "reason 3"
    };

    public BillingService(IOptions<GCloudIntegrationSettings> settings)
    {
        this.settings = settings.Value;
    }

    public async Task<ExecutionResultResponse> TryExecute(OperationSourceRequest request)
    {
        operationCount++;
        var isOperationAllowed = operationCount % 3 != 0;

        var random = new Random();
        var reason = isOperationAllowed ? string.Empty : reasons[random.Next(0, reasons.Length)];

        var result = new ExecutionResultResponse
        {
            IsAllowed = isOperationAllowed,
            OperationType = request.OperationType,
            Reason = reason
        };

        var topic = TopicName.FromProjectTopic(settings.ProjectId, settings.TopicId);
        var publisher = await PublisherClient.CreateAsync(topic);

        var message = JsonConvert.SerializeObject(result);
        await publisher.PublishAsync(message);

        return result;
    }
}
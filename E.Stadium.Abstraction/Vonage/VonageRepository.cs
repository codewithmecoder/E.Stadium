using Vonage;
using Vonage.Request;
using Vonage.Verify;
using Microsoft.Extensions.DependencyInjection;

namespace E.Stadium.Abstraction.Vonage;

public class VonageRepository : IVonage
{
    private readonly IServiceProvider _serviceProvider;

    private readonly VonageOptions _options;

    private readonly VonageClient _client;

    public VonageRepository(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _options = _serviceProvider.GetService<VonageOptions>()!;
        Credentials credentials = Credentials.FromApiKeyAndSecret(_options.ApiKey, _options.ApiSecret);
        _client = new VonageClient(credentials);
    }

    public async Task<VonageResult> RequestAsync(string phone, string message = "Your verify")
    {
        VerifyResponse response;
        try
        {
            VerifyRequest request = new()
            {
                Brand = message,
                Number = phone,
                WorkflowId = VerifyRequest.Workflow.SMS,
                CodeLength = _options.CodeLength,
                PinExpiry = 300,
                SenderId = _options.SenderId
            };
            response = await _client.VerifyClient.VerifyRequestAsync(request);
        }
        catch (VonageVerifyResponseException ex)
        {
            VonageVerifyResponseException e = ex;
            response = (VerifyResponse)e.Response;
        }

        return new VonageResult
        {
            RequestId = response.RequestId,
            StatusCode = response.Status,
            ErrorMsg = response.ErrorText
        };
    }

    public async Task<VonageResult> VerifyAsync(string requestId, string code)
    {
        _ = new VerifyCheckResponse();
        VerifyCheckResponse response;
        try
        {
            VerifyCheckRequest request = new VerifyCheckRequest
            {
                Code = code,
                RequestId = requestId
            };
            response = await _client.VerifyClient.VerifyCheckAsync(request);
        }
        catch (VonageVerifyResponseException ex)
        {
            VonageVerifyResponseException e = ex;
            response = (VerifyCheckResponse)e.Response;
        }

        return new VonageResult
        {
            RequestId = response.RequestId,
            StatusCode = response.Status,
            ErrorMsg = response.ErrorText
        };
    }
}

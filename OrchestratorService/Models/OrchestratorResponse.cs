namespace OrchestratorService.Models;

public class OrchestratorResponse
{
    public string Message { get; }
    public object? Data { get; }

    public OrchestratorResponse(string message, object? data)
    {
        Message = message;
        Data = data;
    }
}

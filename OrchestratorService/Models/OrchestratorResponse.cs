namespace OrchestratorService.Models;

public class OrchestratorResponse
{
    private string Message;
    private object? Data;

    public OrchestratorResponse(string message, object? data)
    {
        Message = message;
        Data = data;
    }
}

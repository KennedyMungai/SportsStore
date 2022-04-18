namespace Platform;

public class Capital
{
    private RequestDelegate? next;

    public Capital()
    {
        
    }

    public Capital(RequestDelegate nextDelegate)
    {
        next = nextDelegate;
    }

    public async Task Invoke(HttpContext context)
    {
        string[]
    }
}
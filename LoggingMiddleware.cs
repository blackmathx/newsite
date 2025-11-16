public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory?.CreateLogger<LoggingMiddleware>() ??
            throw new ArgumentNullException(nameof(loggerFactory));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var realUserIP = GetRealUserIP(context);
        var url = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request);
        
		var message = $"User IP: {realUserIP} | Request URL: {url}";
        // _logger.LogWarning(message);
        
        await this._next(context);
    }

    private static string GetRealUserIP(HttpContext context)
    {
        // Priority order for finding real user IP
        var headers = new[]
        {
            "CF-Connecting-IP",    // Cloudflare
            "X-Forwarded-For",     // Standard proxy header
            "X-Real-IP",           // Nginx proxy
            "X-Client-IP",         // Some proxies
            "True-Client-IP",      // Akamai, CloudFlare
            "X-Forwarded",         // Less common
            "Forwarded-For",       // Obsolete but sometimes used
            "Forwarded"            // RFC 7239 standard
        };

        foreach (var header in headers)
        {
            var value = context.Request.Headers[header].FirstOrDefault();
            if (!string.IsNullOrEmpty(value))
            {
                // X-Forwarded-For can contain multiple IPs: "user_ip, proxy1_ip, proxy2_ip"
                var ip = value.Split(',')[0].Trim();
                if (IsValidPublicIP(ip))
                    return ip;
            }
        }

        // Fallback to connection IP
        var connectionIP = context.Connection.RemoteIpAddress?.ToString();
        return connectionIP ?? "unknown";
    }

    private static bool IsValidPublicIP(string ip)
    {
        if (!System.Net.IPAddress.TryParse(ip, out var address))
            return false;

        // Filter out private IP ranges
        var bytes = address.GetAddressBytes();
        
        // IPv4 private ranges
        if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        {
            // 127.0.0.0/8 (localhost)
            if (bytes[0] == 127) return false;
            
            // 10.0.0.0/8 (private)
            if (bytes[0] == 10) return false;
            
            // 172.16.0.0/12 (private)
            if (bytes[0] == 172 && bytes[1] >= 16 && bytes[1] <= 31) return false;
            
            // 192.168.0.0/16 (private)
            if (bytes[0] == 192 && bytes[1] == 168) return false;
            
            // 169.254.0.0/16 (link-local)
            if (bytes[0] == 169 && bytes[1] == 254) return false;
        }

        return true;
    }
}

public static class LoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LoggingMiddleware>();
    }
}
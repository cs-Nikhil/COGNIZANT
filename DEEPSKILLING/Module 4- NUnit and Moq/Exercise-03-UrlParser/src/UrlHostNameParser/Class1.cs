namespace UrlHostNameParser;

public class UrlHostNameParser
{
    public string? ParseHostName(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return null;
        }

        if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uri))
        {
            return null;
        }

        return uri.Scheme is Uri.UriSchemeHttp or Uri.UriSchemeHttps ? uri.Host : null;
    }
}

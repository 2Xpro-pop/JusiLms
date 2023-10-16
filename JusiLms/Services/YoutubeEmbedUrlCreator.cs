using System.Text.RegularExpressions;

namespace JusiLms.Services;

public class YoutubeEmbedUrlCreator : IYoutubeEmbedUrlCreator
{
    public ValueTask<string> GetUrl(string url)
    {
        var pattern = @"^(https?://)?(www\.)?youtu\.be/([a-zA-Z0-9_-]+)(\?si=.+)?$";
        var replacement = "https://www.youtube.com/embed/$3$4";

        if (Regex.IsMatch(url, pattern))
        {
            // Применяем замену
            var newUrl = Regex.Replace(url, pattern, replacement);
            return new ValueTask<string>(newUrl);
        }

        return new(url);
    }
}
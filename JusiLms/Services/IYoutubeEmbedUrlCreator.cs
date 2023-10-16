namespace JusiLms.Services;

public interface IYoutubeEmbedUrlCreator
{
    public ValueTask<string> GetUrl(string url);
}

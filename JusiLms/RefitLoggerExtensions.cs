using System.Text;
using System.Text.Json;

namespace JusiLms;

public static class RefitLoggerExtensions
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
    };
    private const string INDENT_STRING = "\t";
    public static async Task LogException(this ILogger logger, Refit.ValidationApiException exception, string log)
    {
        string content;
        try
        {
            content = await exception.RequestMessage.Content!.ReadAsStringAsync();
            content = FormatJson(content);
        }
        catch
        {
            content = string.Empty;
        }

        if (!string.IsNullOrWhiteSpace(content))
        {
#pragma warning disable CA2254
            logger.LogError(exception,
                            log+ "\nRequest message:\n{RequestMessage}\nRequest Message Content:{RequestMessage.Content}\nResponse:\n{Content.Errors}",
                            exception.RequestMessage,
                            content,
                            JsonSerializer.Serialize(exception.Content?.Errors, _jsonOptions));
#pragma warning restore CA2254
            return;
        }

#pragma warning disable CA2254
        logger.LogError(exception,
                            log+ "\nRequest message:\n{RequestMessage}\nResponse:\n{Content.Errors}",
                            exception.RequestMessage,
                            JsonSerializer.Serialize(exception.Content?.Errors, _jsonOptions));
#pragma warning restore CA2254

    }

    private static string FormatJson(string str)
    {
        var indent = 0;
        var quoted = false;
        var sb = new StringBuilder();
        for (var i = 0; i < str.Length; i++)
        {
            var ch = str[i];
            switch (ch)
            {
                case '{':
                case '[':
                    sb.Append(ch);
                    if (!quoted)
                    {
                        sb.AppendLine();
                        Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                    }
                    break;
                case '}':
                case ']':
                    if (!quoted)
                    {
                        sb.AppendLine();
                        Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                    }
                    sb.Append(ch);
                    break;
                case '"':
                    sb.Append(ch);
                    bool escaped = false;
                    var index = i;
                    while (index > 0 && str[--index] == '\\')
                        escaped = !escaped;
                    if (!escaped)
                        quoted = !quoted;
                    break;
                case ',':
                    sb.Append(ch);
                    if (!quoted)
                    {
                        sb.AppendLine();
                        Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
                    }
                    break;
                case ':':
                    sb.Append(ch);
                    if (!quoted)
                        sb.Append(" ");
                    break;
                default:
                    sb.Append(ch);
                    break;
            }
        }
        return sb.ToString();
    }

    private static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
    {
        foreach (var i in ie)
        {
            action(i);
        }
    }
}

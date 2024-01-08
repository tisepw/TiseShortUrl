namespace TiseShortUrl.Extensions;

public static class StringExtensions
{
    public static string CorrectStringLength(this string source, int maxLength = 20)
    {
        if (source?.Length < maxLength)
        {
            return source;
        }
        else
        {
            return source![..(maxLength / 2)] + "..." + source![(source!.Length - maxLength / 4)..];
        }
    }
}

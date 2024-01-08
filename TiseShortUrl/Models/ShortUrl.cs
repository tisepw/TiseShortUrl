using System.ComponentModel.DataAnnotations;
using TiseShortUrl.Extensions;

namespace TiseShortUrl.Models;

public class ShortUrl()
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [Display(Name = "Original URL")]
    public string OriginalUrl { get; set; } = string.Empty;

    [Display(Name = "Short URL")]
    public string Url { get; set; } = string.Empty;
};

    public string ShortName
    {
        get
        {
            return Name.CorrectStringLength(25);
        }
    }

    public string ShortOriginalUrl
    {
        get
        {
            return OriginalUrl.CorrectStringLength(40);
        }
    }

// OwnerId
// CreatedAt
// ModifiedAt
// AuthRequired?
// WhoCanAccess?

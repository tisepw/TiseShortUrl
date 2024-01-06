using System.ComponentModel.DataAnnotations;

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

// OwnerId
// CreatedAt
// ModifiedAt
// AuthRequired?
// WhoCanAccess?

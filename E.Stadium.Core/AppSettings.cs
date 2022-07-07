namespace E.Stadium.Core;

public class AppSettings
{

    public static readonly int DefaultThumbnailHeight = 200;
    //public static readonly string CurrentMediaUploadProvider = MediaUploadProvider.Cloudinary;

    //mobile supported version
    public static readonly string[] AndroidUnSupportedVersion = { };
    public static readonly string[] IOSUnSupportedVersion = { };

    //header middleware
    public static readonly Dictionary<string, string> ClientHeaders = new Dictionary<string, string>() {
        {"83n3zJAW", "Android"},
        {"DTux6jkb", "iOS"},
        {"Y685rYs2", "Web"},
        {"YnBJ7QgZ", "Other"}
    };
    public string FfmpegPath { get; set; } = string.Empty;
    public int SearchRadiusKm { get; set; } = 50;
    public int ProductExpiredDay { get; set; } = 90;

    public static string UploadImageUri => "/v1/Image/upload/";
    public static string UploadVideoUri => "/v1/video/upload/";
    public static string UploadFileUri => "/v1/file/upload/";

    public static DateTime ClientUtcTime { get; set; }
    public static DateTime ClientLocalTime { get; set; }

    public static int ClitneTimeOffset { get => (ClientLocalTime - ClientUtcTime).Hours; }

    public static string CurrentCulture { get; set; } = string.Empty;

}
public static class AppSettingsAccessor
{
    public static AppSettings Settings { get; set; } = new AppSettings();
}
public class AppSettingsStatic
{

    public static readonly int DefaultThumbnailHeight = 200;
    //public static readonly string CurrentMediaUploadProvider = MediaUploadProvider.Cloudinary;

    //mobile supported version
    public static readonly string[] AndroidUnSupportedVersion = Array.Empty<string>();
    public static readonly string[] IOSUnSupportedVersion = Array.Empty<string>();

    //header middleware
    public static readonly Dictionary<string, string> ClientHeaders = new() {
        {"83n3zJAW", "Android"},
        {"DTux6jkb", "iOS"},
        {"Y685rYs2", "Web"},
        {"YnBJ7QgZ", "Other"}
    };

    public static readonly int MinimunUserAge = 4;
}

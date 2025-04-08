using System.ComponentModel;

namespace TopLearn.DataLayer.Enums;
public class CourseEnums
{
    public enum CourseStatus
    {
        [Description("در حال برگزاری")]
        IsUnderway = 0,

        [Description("به پایان رسیده")]
        HasEnded = 1,

        [Description("متوقف شده")]
        HasStopped = 2
    }

    public enum CourseLevel
    {
        [Description("مقدماتی")]
        Low = 0,

        [Description("متوسط")]
        Mid = 1,

        [Description("پیشرفته")]
        High = 2
    }
}

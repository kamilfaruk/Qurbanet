using System.ComponentModel;

namespace Qurbanet.Models.Enums
{
    public enum UserType
    {
        [Description("KULLANICI")]
        User = 1,
        [Description("ORGANIZER")]
        Organizer = 2,
        [Description("YÖNETİCİ")]
        Admin = 3
    }
}

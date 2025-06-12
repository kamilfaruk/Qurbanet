using System.ComponentModel;
using System.Reflection;

namespace Qurbanet.Helpers
{
    public class EnumHelper
    {
        public static string GetDescription<T>(T enumValue) where T : Enum
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttribute?.Description ?? enumValue.ToString();
        }

        public static T GetEnumFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                var attribute = field.GetCustomAttribute<DescriptionAttribute>();
                if (attribute != null && attribute.Description == description)
                {
                    return (T)Enum.Parse(typeof(T), field.Name);
                }
            }
            throw new ArgumentException($"No matching enum value found for description: {description}");
        }
    }
}

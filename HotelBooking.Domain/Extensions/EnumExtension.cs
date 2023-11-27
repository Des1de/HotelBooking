namespace HotelBooking.Domain.Extentions;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
public static class EnumExtension
{
    public static string GetDisplayName(this System.Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            ?.GetName() ?? "Неопределенный";
    }
}
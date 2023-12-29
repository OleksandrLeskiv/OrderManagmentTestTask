using Newtonsoft.Json;

namespace SalesOrderDataManager.BLL.Extensions;

public static class SystemExtensions
{
    public static T? Clone<T>(this T source)
    {
        var serialized = JsonConvert.SerializeObject(source);
        return JsonConvert.DeserializeObject<T>(serialized);
    }
}
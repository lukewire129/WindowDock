using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowDock.Core.Utils;

public static class Base64String
{
    public static List<T> Get<T>(string data)
    {
        if (String.IsNullOrEmpty (data))
            return null;

        byte[] bytes = Convert.FromBase64String (data);
        string json = Encoding.UTF8.GetString (bytes);

        var objs = JsonConvert.DeserializeObject<List<T>> (json);

        return objs;
    }

    public static string Get<T>(List<T> objs)
    {
        var json = JsonConvert.SerializeObject (objs);
        byte[] bytes = Encoding.UTF8.GetBytes (json);
        string base64 = Convert.ToBase64String (bytes);

        return base64;
    }
}

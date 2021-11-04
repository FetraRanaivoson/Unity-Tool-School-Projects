using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonManager
{
    public static string ToJson<T>(T toStringify)
    {
        return JsonUtility.ToJson(toStringify);
    }

    public static T FromJson<T>(string toDeserialize)
    {
        return JsonUtility.FromJson<T>(toDeserialize);
    }
    
    public static string ListToString<T>(List<T> list)
    {
        WrapperList<T> datas = new WrapperList<T>(list);
        return JsonUtility.ToJson(datas);
    }

    public class WrapperList<T>
    {
        public List<T> datas;

        public WrapperList(List<T> datas)
        {
            this.datas = datas;
        }
    }
}

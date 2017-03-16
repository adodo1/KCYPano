using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace PanoClient
{
    public class Json
    {
        /// <summary>
        /// 序列化对象到JSON字符串
        /// </summary>
        /// <typeparam name="T">Object like: User</typeparam>
        /// <param name="o">Object list like: List<User></param>
        /// <returns>Return a json data</returns>
        public static string JsonSerialize<T>(T o)
        {
            JavaScriptSerializer jsonSerialize = new JavaScriptSerializer();
            return jsonSerialize.Serialize(o);
        }
        /// <summary>
        /// 反序列化JSON字符串到对象
        /// </summary>
        /// <typeparam name="T">Object like: User</typeparam>
        /// <param name="json">Json string</param>
        /// <returns>Return an object</returns>
        public static T JsonDeserialize<T>(string json)
        {
            JavaScriptSerializer jsonSerialize = new JavaScriptSerializer();
            return jsonSerialize.Deserialize<T>(json);
        }
    }
}

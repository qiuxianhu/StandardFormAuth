using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace FormsAuth.Common
{
    public class SerializeHelper
    {
        /// <summary>
        /// 序列化对象
        /// 先转化为二进制，然后对二进制进行Base64编码
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            string result = string.Empty;
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (MemoryStream ms=new MemoryStream())
                {
                    binaryFormatter.Serialize(ms,obj);
                    byte[] bs = ms.ToArray();
                    result = Convert.ToBase64String(bs);
                    Array.Clear(bs,0,bs.Length);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string str)
        {
            T t = default(T);
            if (str==string.Empty)
            {
                return t;
            }
            byte[] data = Convert.FromBase64String(str);
            t = DeserializeByBytes<T>(data);
            return t;
        }
        /// <summary>
        ///反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="isClearData"></param>
        /// <returns></returns>
        public static T DeserializeByBytes<T>(byte[] data,bool isClearData=true)
        {
            T t = default(T);
            if (data==null)
            {
                return t;
            }
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream(data))
                {
                    t = (T)formatter.Deserialize(ms);
                }
                formatter = null;
                if (isClearData)
                {
                    Array.Clear(data,0,data.Length);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
    }
}
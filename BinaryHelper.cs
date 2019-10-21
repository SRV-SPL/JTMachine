using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Common
{
    public class BinaryHelper
    {
        public static object DeepClone(object objsrc)
        {
            object obj = null;
            //将对象序列化成内存中的二进制流  
            BinaryFormatter inputFormatter = new BinaryFormatter();
            MemoryStream inputStream;
            using (inputStream = new MemoryStream())
                inputFormatter.Serialize(inputStream, objsrc);
            //将二进制流反序列化为对象  
            using (MemoryStream outputStream = new MemoryStream(inputStream.ToArray()))
            {
                BinaryFormatter outputFormatter = new BinaryFormatter();
                obj = outputFormatter.Deserialize(outputStream);//序列化可以忽略类型
            }
            return obj;
        }

        public static bool SerializeObj(object objsrc,string filename)
        {
            //将对象序列化成内存中的二进制流  
            BinaryFormatter inputFormatter = new BinaryFormatter();
            using (FileStream inputStream = new FileStream(filename,FileMode.OpenOrCreate))
                inputFormatter.Serialize(inputStream, objsrc);
            return true;
        }

        public static object DeserializeObj(string filename)
        {
            object obj = null;
            if (!File.Exists(filename)) return null;
            //将二进制流反序列化为对象  
            using (FileStream outputStream = new FileStream(filename,FileMode.Open))
            {
                BinaryFormatter outputFormatter = new BinaryFormatter();
                obj = outputFormatter.Deserialize(outputStream);
            }
            return obj;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Drawing;
using System.Xml.Serialization;
using System.ComponentModel;
using Newtonsoft.Json;


namespace lab13
{
    internal class CustomSerializer
    {
        public static void SerializeToBinary<T>(T obj, string path) where T : class
        {
            var binaryFormatter = new BinaryFormatter();
            using (FileStream bf = new FileStream(path, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(bf, obj);
            }
        }


        public static void DeserializeFromBinary<T>(string path, ref T container) where T : class
        {
            var binaryFormatter = new BinaryFormatter();
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                container = (T)binaryFormatter.Deserialize(fs);
            }
        }

        public static void SerializeToXml<T>(T obj, string path) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, obj);
            }
        }


        public static void DeserializefromXml<T>(string path, ref T container) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                container = (T)xmlSerializer.Deserialize(fs);
            }
        }


        public static void SerializeToJson<T>(T obj, string path) where T : class
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All // Включаем метаданные о типах
                }
            );

            File.WriteAllText(path, json);
        }


        public static void DeserializeFromJson<T>(string path, ref T container) where T : class
        {

            string json = File.ReadAllText(path);
            container = JsonConvert.DeserializeObject<T>(json,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                }
            );
        }


    }
}

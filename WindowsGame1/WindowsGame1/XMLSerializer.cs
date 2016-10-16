using System;
using System.Xml.Serialization;
using System.IO;

namespace HuntTheWumpus
{
    public class XMLSerializer<T>
    {
        public Type Type { get; set; }

        public XMLSerializer()
        {
            Type = typeof(T);
        }

        public T Load(string path)
        {
            T instance;
            using (TextReader reader = new StreamReader(path))
            {
                System.Diagnostics.Debug.Write("\n\n\n" + Type + "\n\n\n");
                XmlSerializer xml = new XmlSerializer(Type);
                instance = (T)xml.Deserialize(reader);
            }
            return instance;
        }

        public void Save(string path, object obj)
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                xml.Serialize(writer, obj);
            }
        }
    }
}
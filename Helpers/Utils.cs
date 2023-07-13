using System.Xml;
using System.Xml.Serialization;

namespace webservicecsharpasmx.Helpers
{
    public class Utils
    {
        private static Utils _instance;
        private static readonly object _lockObject = new object();

        private Utils() { }

        public static Utils Instance
        {
            get
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                        _instance = new Utils();
                }
                return _instance;
            }
        }

        public XmlDocument ConvertObjectToXmlDocument<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlDocument xmlDoc = new XmlDocument();
            using (XmlWriter writer = xmlDoc.CreateNavigator().AppendChild())
            {
                serializer.Serialize(writer, obj);
            }

            return xmlDoc;
        }
    }
}

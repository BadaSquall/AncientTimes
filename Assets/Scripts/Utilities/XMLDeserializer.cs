using System;
using System.IO;
using System.Xml.Serialization;

namespace AncientTimes.Assets.Scripts.Utilities
{
    public static class XMLDeserializer
    {
        #region Methods

        public static object Deserialize(Type type, string filePath)
        {
            var deserializer = new XmlSerializer(type);

            using (var stream = new StreamReader(filePath, false)) { return deserializer.Deserialize(stream); }
        }

        #endregion Methods
    }
}

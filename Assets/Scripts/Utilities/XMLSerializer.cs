using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AncientTimes.Assets.Scripts.Utilities
{
    public static class XMLSerializer
    {
        #region Methods

        public static void Serialize(object objectToSerialize, string filePath)
        {
            var type = objectToSerialize.GetType();
            var serializer = new XmlSerializer(type);

            using (var stream = new StreamWriter(filePath, false, Encoding.GetEncoding("us-ascii"))) { serializer.Serialize(stream, objectToSerialize); }
        }

        #endregion Methods
    }
}

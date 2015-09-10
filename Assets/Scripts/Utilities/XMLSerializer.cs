using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace AncientTimes.Assets.Scripts.Utilities
{
	public static class XMLSerializer
	{
		#region Methods
		
		public static void Serialize(object objectToSerialize, string directoryName, string fileName)
		{
			var type = objectToSerialize.GetType();
			var serializer = new XmlSerializer(type);
			directoryName = @"Assets/Resources/" + directoryName;

			if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);
			
			using (var stream = new StreamWriter(File.Create(directoryName + fileName), Encoding.GetEncoding("UTF-8"))) { serializer.Serialize(stream, objectToSerialize); }
		}

		public static string GetSerializedString(object objectToSerialize)
		{
			var type = objectToSerialize.GetType();
			var serializer = new XmlSerializer(type);
			var settings = new XmlWriterSettings();
			settings.Encoding = Encoding.GetEncoding("UTF-8");

			using(var stream = new StringWriter())
			{
				using(XmlWriter xmlWriter = XmlWriter.Create(stream, settings))
				{
					serializer.Serialize(xmlWriter, objectToSerialize);
				}

				return stream.ToString();
			}
		}
		
		#endregion Methods
	}
}
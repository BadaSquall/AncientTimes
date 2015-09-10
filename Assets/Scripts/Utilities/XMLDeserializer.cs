using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.Utilities
{
	public static class XMLDeserializer
	{
		#region Methods
		
		public static object Deserialize(Type type, string filePath)
		{
			var deserializer = new XmlSerializer(type);
			var xmlAsset = Resources.Load(filePath) as TextAsset;
			var reader = new StringReader(xmlAsset.text);

			return deserializer.Deserialize(reader);
		}

		public static object Deserialize(Type type, TextAsset file)
		{
			var deserializer = new XmlSerializer(type);
			var reader = new StringReader(file.text);
			
			return deserializer.Deserialize(reader);
		}
		
		#endregion Methods
	}
}
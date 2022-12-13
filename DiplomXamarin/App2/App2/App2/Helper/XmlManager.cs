using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace App2.Helper
{
    public static class XmlManager
    {
        public static string UserPath => $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/user.xml";
        public static T ReadFromXmlFile<T>(string filePath) where T : new()
        {

            if (File.Exists(filePath))
            {
                TextReader reader = null;
                try
                {
                    var serializer = new XmlSerializer(typeof(T));
                    reader = new StreamReader(filePath);
                    var x = File.ReadAllText(filePath);
                    return (T)serializer.Deserialize(reader);
                }
                catch (Exception ex)
                {
                    return default(T);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
            return new T();
        }

        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath))) Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

    }
}

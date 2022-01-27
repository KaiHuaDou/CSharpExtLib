using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace CSharpExtLibrary
{
    public class Configer<T>
    {
        public Configer(string path)
        {
            configPath = path;
            configStream = GenStream();
            configSerializer = new XmlSerializer(typeof(ObservableCollection<T>));
        }
        private string configPath;
        private FileStream configStream;
        private XmlSerializer configSerializer;
        private FileStream GenStream()
        {
            FileStream stream = new FileStream(configPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            return stream;
        }
        public ObservableCollection<T> GetConfig()
        {
            ObservableCollection<T> config = new ObservableCollection<T>();
            try
            {
                config = configSerializer.Deserialize(configStream) as ObservableCollection<T>;
            }
            catch (Exception)
            {
                InitConfig();
            }
            return config;
        }

        public void SaveConfig(ObservableCollection<T> data)
        {
            configSerializer.Serialize(configStream, data);
        }

        public void AddConfig(T data)
        {
            ObservableCollection<T> savedData = GetConfig();
            savedData.Add(data);
            SaveConfig(savedData);
        }

        public void RemoveConfig(T data)
        {
            ObservableCollection<T> savedData = GetConfig();
            savedData.Remove(data);
            SaveConfig(savedData);
        }

        public void InitConfig()
        {
            File.WriteAllText(configPath, "");
            SaveConfig(new ObservableCollection<T>());
        }

        public void ClearConfig()
        {
            configSerializer.Serialize(configStream, new ObservableCollection<T>());
        }
    }
}

using System;
using System.IO;
using System.Xml.Serialization;

namespace CSharpExtLib.Easy
{
    /// <summary>
    /// 1. 这不是像FileInfo那样的静态配置辅助类。
    /// 2. 您需要为每个配置创建一个新对象
    /// 3. 在使用构造函数初始化对象时，应该给出配置文件的路径。
    /// 4. 请不要传入结构体，并传入带有公共无参构造函数且被标记为[Serializable]的类。
    /// 5. 如果读取数据时出现任何错误，则所有数据都将被清除并返回空集合，所以你应该确保OnBackup变量的值为true，以保证存在一个备份。
    /// 6. 不要通过删除文件或清空文件内容来清除配置，应调用ClearConfig()来清空。
    /// 7. 为了可以应用于多线程，作者在使用文件流和序列化对象已经进行了加锁操作，但并不建议高并发使用，因为这样会导致大量的加锁操作最终使程序运行缓慢。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EasyConfigOne<T> where T : class, new()
    {
        public EasyConfigOne(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("找不到指定的配置文件", path);
            }
            configPath = path;
            configStream = GenStream( );
            configSerializer = new XmlSerializer(typeof(T));
        }
        private string configPath;
        private FileStream configStream;
        private XmlSerializer configSerializer;
        public bool OnBackup { get; set; }
        private FileStream GenStream( )
        {
            FileStream stream = new FileStream(configPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            return stream;
        }
        public T Get( )
        {
            T config = new T( );
            try
            {
                lock (configSerializer)
                    config = configSerializer.Deserialize(configStream) as T;
            }
            catch (Exception)
            {
                if (OnBackup == true)
                    File.Copy(configPath, configPath + ".bak");
                Clear( );
            }
            return config;
        }

        public void Save(T data)
        {
            lock (configSerializer)
                configSerializer.Serialize(configStream, data);
        }
        public void Clear( )
        {
            Save(new T( ));
        }
    }
}

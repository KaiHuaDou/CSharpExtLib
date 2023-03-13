using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CSharpExtLib.Easy
{
    /// <summary>
    /// 储存数据列表的简易类。
    /// 可以应用于多线程，不建议高并发使用。
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class EasyDataList<T>
    {
        private FileStream stream;
        private XmlSerializer serializer;
        private FileStream GenStream( )
        {
            FileStream stream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            return stream;
        }

        /// <summary>
        /// 通过数据文件路径初始化数据类
        /// </summary>
        /// <param name="path">数据文件路径</param>
        public EasyDataList(string path)
        {
            this.Path = path;
            stream = GenStream( );
            serializer = new XmlSerializer(typeof(HashSet<T>));
        }

        /// <summary>
        /// 数据文件的路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 在出错时是否备份, 默认为 true
        /// </summary>
        public bool BackupOnError { get; set; } = true;

        /// <summary>
        /// 获取数据集合内容
        /// </summary>
        /// <returns></returns>
        public HashSet<T> Get( )
        {
            HashSet<T> config = new HashSet<T>( );
            try
            {
                lock (serializer)
                    config = serializer.Deserialize(stream) as HashSet<T>;
            }
            catch (Exception)
            {
                if (BackupOnError == true)
                    File.Copy(Path, Path + ".bak");
                Init( );
            }
            return config;
        }

        /// <summary>
        /// 用新的数据集合覆写掉旧的数据集合
        /// </summary>
        /// <param name="data"><see cref="HashSet{T}"/> 型数据</param>
        public void Save(HashSet<T> data)
        {
            lock (serializer)
                serializer.Serialize(stream, data);
        }

        /// <summary>
        /// 将 <paramref name="data"/> 添加至数据中
        /// </summary>
        /// <param name="data">数据</param>
        public void Add(T data)
        {
            HashSet<T> savedData = Get( );
            savedData.Add(data);
            Save(savedData);
        }

        /// <summary>
        /// 删除与 <paramref name="data"/> 一致的第一项
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>表示删除的成功状态</returns>
        public bool Remove(T data)
        {
            HashSet<T> savedData = Get( );
            bool success = savedData.Remove(data);
            Save(savedData);
            return success;
        }

        /// <summary>
        /// 初始化数据文件, 相当于格式化
        /// </summary>
        public void Init( )
        {
            File.WriteAllText(Path, "");
            Save(new HashSet<T>( ));
        }

        /// <summary>
        /// 清空所有的数据
        /// </summary>
        public void Clear( )
        {
            lock (serializer)
                serializer.Serialize(stream, new HashSet<T>( ));
        }
    }
}

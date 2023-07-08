using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CSharpExtLib.Easy;

/// <summary>
/// 储存数据列表的简易类。
/// </summary>
/// <typeparam name="T">数据类型</typeparam>
public class EasyList<T> : IDisposable where T : new()
{
    /// <summary>
    /// 列表内容
    /// </summary>
    public List<T> Content { get; private set; }
    /// <summary>
    /// XML 文件
    /// </summary>
    public string XmlFile { get; set; }
    private FileStream XmlStream;

    /// <summary>
    /// 使用 XML 文件初始化示例
    /// </summary>
    /// <param name="xmlFile">XML 文件</param>
    public EasyList(string xmlFile)
    {
        XmlFile = new FileInfo(xmlFile).FullName;
        XmlStream = new(XmlFile, FileMode.OpenOrCreate);
        Read( );
    }

    /// <summary>
    /// 从 XML 文件读取列表数据
    /// </summary>
    public void Read( )
    {
        XmlReader reader = XmlReader.Create(XmlStream);
        try
        {
            Content = reader.ReadContentAs(typeof(List<T>), null) as List<T>;
        }
        catch
        {
            Content = new List<T>( );
        }
    }

    /// <summary>
    /// 将列表数据保存至 XML 文件
    /// </summary>
    public void Save( )
    {
        XmlStream.Seek(0, SeekOrigin.Begin);
        XmlSerializer serializer = new(typeof(List<T>));
        serializer.Serialize(XmlStream, Content);
    }

    /// <summary>
    /// 释放该实例使用的资源
    /// </summary>
    public void Dispose( )
    {
        XmlStream.Dispose( );
        GC.SuppressFinalize(this);
    }
}

namespace CSharpExtLib.Char
{
    /// <summary>
    /// 表示字体类型的枚举，根据 C++ 标准编写
    /// </summary>
    public enum FontType : int
    {
        /// <summary>
        /// 空字体
        /// </summary>
        Empty = 0,
        /// <summary>
        /// 错误字体
        /// </summary>
        Error = 1,    
        /// <summary>
        /// 显示字体
        /// </summary>
        Display = 2,  
        /// <summary>
        /// 脚本字体
        /// </summary>
        Script = 3,
        /// <summary>
        /// 装饰字体
        /// </summary>
        Decorate = 4, 
        /// <summary>
        /// 符号字体
        /// </summary>
        Symbol = 5    
    }
}

using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Windows.Input;

namespace CSharpExtLib;

/// <summary>
/// 系统管理相关工具
/// </summary>
public static class SystemManagement
{
    /// <summary>
    /// 判断是否为管理员账户
    /// </summary>
    public static bool IsAdministrator( )
    {
        return new WindowsPrincipal(WindowsIdentity.GetCurrent( ))
            .IsInRole(WindowsBuiltInRole.Administrator);
    }

    /// <summary>
    /// 模拟键盘发送按键
    /// </summary>
    /// <param name="key">模拟的按键</param>
    public static void SendKey(Key key)
    {
        SendKey(key, 0);
        SendKey(key, 1);
    }

    /// <summary>
    /// 模拟键盘发送按键（可指定按下或抬起）
    /// </summary>
    /// <param name="key">模拟的按键</param>
    /// <param name="mode">按下(0)还是抬起(1)</param>
    public static void SendKey(Key key, int mode)
    {
        if (Keyboard.PrimaryDevice != null && Keyboard.PrimaryDevice.ActiveSource != null)
        {
            KeyEventArgs e = new(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
            {
                RoutedEvent = mode != 0 ? Keyboard.KeyUpEvent : Keyboard.KeyDownEvent
            };
            InputManager.Current.ProcessInput(e);
        }
    }

    /// <summary>
    /// 创建未初始化的对象
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <returns>尚未执行过构造函数的对象</returns>
    public static T CreateUninitializedObject<T>( )
    {
        T type = (T) FormatterServices.GetUninitializedObject(typeof(T));
        ConstructorInfo constructorInfo = typeof(T).GetConstructor(Array.Empty<Type>( ));
        constructorInfo.Invoke(type, null);
        return type;
    }
}

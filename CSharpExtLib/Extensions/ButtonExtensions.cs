using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace CSharpExtLib.Extensions;

/// <summary>
/// <see cref="Button"/> 的扩展类
/// </summary>
public static class ButtonExtensions
{
    /// <summary>
    /// 模拟 Button 的点击操作
    /// </summary>
    /// <param name="button">操作的 Button</param>
    public static void Click(this Button button)
    {
        ButtonAutomationPeer peer = new(button);
        IInvokeProvider provider = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
        provider.Invoke( );
    }
}

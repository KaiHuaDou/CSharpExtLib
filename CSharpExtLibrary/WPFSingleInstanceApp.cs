using System;
using System.Windows;
using Microsoft.VisualBasic.ApplicationServices;

namespace CSharpExtLibrary
{
    /// <summary>
    /// 继承此类，并让构造函数同时继承。
    /// 并添加如下代码：
    /// public {主程序的类名} app;
    /// 重载OnStartUp方法并在其中初始化app字段并执行Run()，最后返回false。
    ///  重载OnStartupNextInstance方法并添加你想要处理下一个实例启动时的代码。
    ///  为了启动程序你需要创建你重载类的实例并执行Run方法。
    ///  注：带括号的是需要你自定义的名称。不重载OnStartupNextInstance会引发InvaildOperationException。
    /// </summary>
    public class WPFSingleInstanceWrapper : WindowsFormsApplicationBase
    {
        public WPFSingleInstanceWrapper( )
        {
            this.IsSingleInstance = true;
            
        }
        protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs eventArgs)
        {
            return false;
        }
        protected override void OnStartupNextInstance(
            StartupNextInstanceEventArgs e)
        {
            throw new InvalidOperationException("没有重载OnStartupNextInstanc方法。");
        }
    }
}

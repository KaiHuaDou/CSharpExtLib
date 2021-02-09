using System.Windows;
using Microsoft.VisualBasic.ApplicationServices;

namespace CSharpExtLibrary
{
    public class WPFSingleInstanceWrapper : WindowsFormsApplicationBase
    {
       public WPFSingleInstanceWrapper(Application app)
        {
            this.IsSingleInstance = true;
        }
        private Application app;
        protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs eventArgs)
        //function that need override
        //override function needs:
        //base.OnStartup(e);
        {
            app = new Application( );
            app.Run( );
            return false;
        }
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        //Function that need override
        {

        }
    }
}

using Foundation;
using UIKit;

namespace Redux.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Window = new UIWindow();
            Window.BackgroundColor = UIColor.White;
            Window.RootViewController = new BankingPageViewController();
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
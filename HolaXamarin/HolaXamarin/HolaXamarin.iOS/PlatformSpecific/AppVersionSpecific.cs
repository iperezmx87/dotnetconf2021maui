using Foundation;
using HolaXamarin.iOS.PlatformSpecific;
using HolaXamarin.PlatformSpecific;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppVersionSpecific))]
namespace HolaXamarin.iOS.PlatformSpecific
{
    public class AppVersionSpecific : IAppVersionSpecific
    {
        public string GetAppVersion()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
        }
    }
}
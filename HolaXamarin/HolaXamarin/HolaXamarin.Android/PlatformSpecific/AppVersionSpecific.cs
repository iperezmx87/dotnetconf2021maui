using HolaXamarin.Droid.PlatformSpecific;
using HolaXamarin.PlatformSpecific;
using Xamarin.Forms;

using AndroidApp = Android.App.Application;

[assembly: Dependency(typeof(AppVersionSpecific))]
namespace HolaXamarin.Droid.PlatformSpecific
{
    public class AppVersionSpecific : IAppVersionSpecific
    {
        public string GetAppVersion()
        {
            return AndroidApp.Context.PackageManager.GetPackageInfo(
                 AndroidApp.Context.PackageName, 0).VersionName;
        }
    }
}
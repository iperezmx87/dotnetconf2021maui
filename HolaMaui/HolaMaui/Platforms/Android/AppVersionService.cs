
using AndroidApp = Android.App.Application;

namespace HolaMaui.PlatformsAbstract
{
    public partial class AppVersionService
    {
        public partial string GetAppVersion()
        {
            return AndroidApp.Context.PackageManager.GetPackageInfo(
                 AndroidApp.Context.PackageName, 0).VersionName;
        }
    }
}

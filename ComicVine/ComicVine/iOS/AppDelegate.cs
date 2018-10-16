﻿using Foundation;
using UIKit;

namespace ComicVine.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            LoadApplication(new ComicVine.Forms.App());

            return base.FinishedLaunching(app, options);
        }
    }
}

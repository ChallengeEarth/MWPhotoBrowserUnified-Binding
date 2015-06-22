using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace MWPhotoBrowserUnified
{
    [BaseType (typeof (NSObject))]
    [Model][Protocol]
    public interface MWPhotoBrowserDelegate {
        [Export ("numberOfPhotosInPhotoBrowser:")]
        [Abstract]
        nint NumberOfPhotosInPhotoBrowser (MWPhotoBrowser photoBrowser);

        [Export ("photoBrowser:photoAtIndex:")]
        [Abstract]
        MWPhoto PhotoBrowser (MWPhotoBrowser photoBrowser, nint photoAtIndex);

        [Export ("photoBrowser:captionViewForPhotoAtIndex:")]
        MWCaptionView OnCaption(MWPhotoBrowser photoBrowser,nint index);
    }

    [BaseType (typeof (NSObject))]
    public interface MWPhoto
    {
        [Export("caption")]
        string Caption { get; set; }

        [Export("cornerRadius")]
        float CornerRadius { get; set; }

        [Export("initWithImage:")]
        IntPtr Constructor(UIImage a);

        [Export("initWithFilePath:")]
        IntPtr Constructor(string a);

        [Export("initWithURL:")]
        IntPtr Constructor(NSUrl a);

        [Export("underlyingImage")]
        UIImage UnderlyingImage { get; }
    }

    [BaseType (typeof (UIView))]
    public interface MWCaptionView
    {
        [Export("initWithPhoto:")]
        IntPtr Constructor(MWPhoto a);

        [Export("setupCaption")]
        void SetupCaption();

        [Export("sizeThatFits:")]
        System.Drawing.SizeF SizeThatFits(System.Drawing.SizeF a);
    }

    [BaseType (typeof (UIViewController), Delegates=new string [] { "WeakDelegate" })]
    public interface MWPhotoBrowser
    {
        [Export("displayActionButton")]
        bool DisplayActionButton { get; set; }

        [Export("displayNavArrows")]
        bool DisplayNavArrows { get; set; }

        [Export("alwaysShowControls")]
        bool AlwaysShowControls { get; set; }

        [Export("currentIndex")]
        int CurrentIndex { get; set; }

        [Wrap("WeakDelegate")]
        MWPhotoBrowserDelegate Delegate { get; set; }

        [Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
        NSObject WeakDelegate { get; set; }

        [Export("initWithDelegate:")]
        IntPtr Constructor(MWPhotoBrowserDelegate del);

        [Export("reloadData")]
        void ReloadData();

        [Export("getCurrentPhoto")]
        MWPhoto GetCurrentPhoto();

        [Export("setInitialPageIndex:")]
        void SetInitialPageIndex(nint index);

        [ExportAttribute("setNavBarAppearance:")]
        void SetNavBarAppearance(bool animated);

        [Export("storePreviousNavBarAppearance")]
        void StorePreviousNavBarAppearance();

        [ExportAttribute("restorePreviousNavBarAppearance:")]
        void RestorePreviousNavBarAppearance(bool animated);

        [Export("jumpToPageAtIndex:")]
        void JumpToPageAtIndex(nint index);

        [Export("gotoNextPage")]
        void GotoNextPage();

        [Export("gotoPreviousPage")]
        void GotoPreviousPage();

        [Export("showProgressHUDCompleteMessage:")]
        void ShowProgressHUDCompleteMessage(string message);

        [Export("showProgressHUDWithMessage:")]
        void ShowProgressHUDWithMessage(string message);
    }
}


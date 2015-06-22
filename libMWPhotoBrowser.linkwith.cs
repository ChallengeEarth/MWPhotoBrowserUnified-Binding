using System;
using ObjCRuntime;

[assembly: LinkWith ("libMWPhotoBrowser.a", LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7, SmartLink = true, ForceLoad = true, Frameworks="AssetsLibrary ImageIO MessageUI Foundation")]

using System;
using ObjCRuntime;

[assembly: LinkWith("libCCPiPhoneSDK_IMLib.a", LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
    ForceLoad = true, IsCxx = true, SmartLink = true, Frameworks = "CoreTelephony MediaPlayer CFNetwork SystemConfiguration MobileCoreServices AudioToolbox CoreGraphics AVFoundation",
    LinkerFlags = "-stdlib=libstdc++ -licucore -lsqlite3 -lz -lxml2 -ObjC -fobjc-arc")]
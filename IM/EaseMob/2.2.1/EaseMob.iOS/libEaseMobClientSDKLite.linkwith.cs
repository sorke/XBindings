using System;
using ObjCRuntime;

[assembly: LinkWith ("libEaseMobClientSDKLite.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true,SmartLink = true,
	Frameworks = "CFNetwork  MobileCoreServices",
	LinkerFlags = "-stdlib=libstdc++6.0.9 -liconv -lresolv -lsqlite3 -lz -lxml2 -ObjC -fobjc-arc")]


//MobileCoreServices.framework
//
//
//◾ CFNetwork.framework
//
//
//◾ libEaseMobClientSDKLite.a
//
//
//◾ libsqlite3.dylib
//
//
//◾ libstdc++.6.0.9.dylib
//
//
//◾ libz.dylib
//
//
//◾ libiconv.dylib
//
//
//◾ libresolv.dylib
//
//
//◾ libxml2.dylib
//

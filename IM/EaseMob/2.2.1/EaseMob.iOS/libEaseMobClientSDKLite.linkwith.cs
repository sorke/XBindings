using System;
using ObjCRuntime;

[assembly: LinkWith ("libEaseMobClientSDKLite.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true)]

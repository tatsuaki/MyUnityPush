using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class Jnitest {

	[DllImport ("TestJni")] private static extern float FooPluginFunction();
	[DllImport ("TestJni")] private static extern int Hoge();
	[DllImport ("TestJni")] private static extern void getCacheDir();
	//[DllImport ("TestJni", EntrtPoint="loadFile")] private static extern IntPtr loadFile (string filename);
	[DllImport ("TestJni", EntryPoint="loadFile")] private static extern IntPtr CallNativeAndroid (IntPtr filename);

	public static float floatFunction() {
		return FooPluginFunction();
	}
	public static int HogeTest() {
		// MyLog.I("HogeTest");
		return Hoge();
	}

	public static void CacheDir() {
		// MyLog.I("HogeTest");
		getCacheDir();
	}

	public static string toloadFile(string filename) {
		IntPtr ptr1 = Marshal.StringToHGlobalAnsi(filename);
		IntPtr ptr2 = CallNativeAndroid(ptr1);
		string str2 = Marshal.PtrToStringAnsi(ptr2);

		Marshal.FreeHGlobal(ptr1);
		// string auu = loadFile(filename);
		Debug.Log("str2 = " + str2);
		return str2;
	}
}
using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class SgpJni {
	
	[DllImport ("SgpUnity")] private static extern float FooPluginFunction();
	[DllImport ("SgpUnity")] private static extern int Hoge();
	[DllImport ("SgpUnity")] private static extern void getCacheDir();
	[DllImport ("SgpUnity")] private static extern IntPtr getCommonFileName (IntPtr filename, int svno);
	[DllImport ("SgpUnity")] private static extern IntPtr getNotCommonFileName (IntPtr filename, int svno);
	[DllImport ("SgpUnity")] private static extern int nativeWriteCommonFile (IntPtr filename, IntPtr text, int svno);
	[DllImport ("SgpUnity")] private static extern IntPtr nativeReadCommonFile (IntPtr filename, int svno);
	[DllImport ("SgpUnity", EntryPoint="getMyName")] private static extern IntPtr CallNativeAndroid ();
	//[DllImport ("SgpUnity", EntryPoint="getMyName")] private static extern void CallNativeAndroid ();

//	public const int Release = 0;
//	public const int Staging = 1;
//	public const int Debug   = 2;

	public static float floatFunction() {
		return FooPluginFunction();
	}
	public static int HogeTest() {
		// MyLog.I("HogeTest");
		return Hoge();
	}

	public static string toGetMyName() {
		IntPtr ptr1 = Marshal.StringToHGlobalAnsi(null);
		IntPtr ptr2 = CallNativeAndroid();
		string result = Marshal.PtrToStringAnsi(ptr2);

		Marshal.FreeHGlobal(ptr2);
		Debug.Log("toGetMyName = " + result);
		return result;
	}

	public static string toGetCommonFileName(string filename, int svno) {
		IntPtr pFilename = Marshal.StringToHGlobalAnsi(filename);
		IntPtr pResult = getCommonFileName(pFilename, svno);
		string result = Marshal.PtrToStringAnsi(pResult);

		Marshal.FreeHGlobal(pFilename);
		Debug.Log("toGetCommonFilename = " + result);
		return result;
	}

	public static string toGetNotCommonFileName(string filename, int svno) {
		IntPtr pFilename = Marshal.StringToHGlobalAnsi(filename);
		IntPtr pResult = getNotCommonFileName(pFilename, svno);
		string result = Marshal.PtrToStringAnsi(pResult);

		Marshal.FreeHGlobal(pFilename);
		Debug.Log("toGetNonCommonFilename = " + result);
		return result;
	}

	// int nativeWriteFile(IntPtr filename, IntPtr text);
	public static int toNativeWriteCommonFile(string filename, string text, int svno) {
		IntPtr pFilename = Marshal.StringToHGlobalAnsi(filename);
		IntPtr pText = Marshal.StringToHGlobalAnsi(text);
		int result = nativeWriteCommonFile(pFilename, pText, svno);

		Marshal.FreeHGlobal(pFilename);
		Marshal.FreeHGlobal(pText);

		Debug.Log("toNativeWriteCommonFile = " + result);
		return result;
	}

	// char* nativeReadCommonFile(IntPtr filename);
	public static string toNativeReadCommonFile(string filename, int svno) {
		IntPtr pFilename = Marshal.StringToHGlobalAnsi(filename);
		IntPtr pResult = nativeReadCommonFile(pFilename, svno);
		string result = Marshal.PtrToStringAnsi(pResult);
		Marshal.FreeHGlobal(pFilename);

		// Debug.Log("toNativeReadCommonFile = " + result);
		return result;
	}
}

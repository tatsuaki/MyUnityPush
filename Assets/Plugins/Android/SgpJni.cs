using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class SgpJni {

	[DllImport ("SgpUnity")] private static extern IntPtr nativeReadFile  (IntPtr filename, int common, int svno);
	[DllImport ("SgpUnity")] private static extern int    nativeWriteFile (IntPtr filename, IntPtr text, int common, int svno);
	[DllImport ("SgpUnity")] private static extern IntPtr nativeGetUserAgent();
	[DllImport ("SgpUnity")] private static extern int    nativeCheckNT();
	[DllImport ("SgpUnity")] private static extern int    nativeDeleteFile (IntPtr filename, int common, int svno);
	[DllImport ("SgpUnity")] private static extern IntPtr nativeTest();

	[DllImport ("SgpUnity")] private static extern IntPtr nativeSolReadFile (IntPtr filename, int common, int svno);
	[DllImport ("SgpUnity")] private static extern IntPtr getFileNameToUnity (IntPtr filename, int common, int svno);

	// [DllImport ("SgpUnity", EntryPoint="getMyName")] private static extern IntPtr CallNativeAndroid();
	[DllImport ("SgpUnity")] private static extern IntPtr getMyName();

	// static string  new_name = ".testJniUnity";

	// char* nativeReadFile(char* filename, int common, int svno)
	public static string CallNativeReadFile(string filename, int common, int svno) {
		Debug.Log("CallNativeReadFile filename = " + filename + " common = " + common + " svno = " + 0);
		IntPtr pFilename = Marshal.StringToHGlobalAnsi(filename);
		IntPtr pResult = nativeReadFile(pFilename, common, svno);
		string result = Marshal.PtrToStringAnsi(pResult);

		Marshal.FreeHGlobal(pFilename);
		Debug.Log("CallNativeReadFile = " + result);
		return result;
	}

	// 	int nativeWriteFile(const char* filename, char* text, int common, int svno);
	public static int CallnativeWriteFile(string filename, string text, int common, int svno) {
		Debug.Log("CallnativeWriteFile filename = " + filename);

		IntPtr pFilename = IntPtr.Zero;
		IntPtr pText = IntPtr.Zero;
		int result = 0;
		try	{
			System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
			try { }
			finally	{
				pFilename = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(filename);
				pText = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(text);
			}
			result = nativeWriteFile(pFilename, pText, common, svno);
			// ここに処理を記載する
		} finally {
			if (pFilename != IntPtr.Zero) {
				System.Runtime.InteropServices.Marshal.FreeHGlobal(pFilename);
			}
			if(pText != IntPtr.Zero) {
				System.Runtime.InteropServices.Marshal.FreeHGlobal(pText);
			}
		}

//		IntPtr pFilename = Marshal.StringToHGlobalAnsi(filename);
//		IntPtr pText = Marshal.StringToHGlobalAnsi(text);
//		int result = nativeWriteFile(pFilename, pText, common, svno);
//
//		Marshal.FreeHGlobal(pFilename);
//		Marshal.FreeHGlobal(pText);

		Debug.Log("CallnativeWriteFile = " + result);
		return result;
	}

	// char* nativeGetUserAgent();
	public static string CallnativeGetUserAgent() {
		IntPtr pResult = nativeGetUserAgent();
		string result = Marshal.PtrToStringAnsi(pResult);
		Marshal.FreeHGlobal(pResult);
		Debug.Log("CallnativeGetUserAgent = " + result);
		return result;
	}

	// int nativeCheckNT();
	public static int CallnativeCheckNT() {
		int result = nativeCheckNT();
		Debug.Log("CallnativeCheckNT = " + result);
		return result;
	}

	// int nativeDeleteFile(const char* filename, int common, int svno);
	public static int CallNativeDeleteFile(string filename, int common, int svno) {
		Debug.Log("CallnativeWriteFile filename = " + filename);
		IntPtr pFilename = Marshal.StringToHGlobalAnsi(filename);
		int result = nativeDeleteFile(pFilename, common, svno);
		Marshal.FreeHGlobal(pFilename);

		Debug.Log("CallNativeDeleteFile = " + result);
		return result;
	}

	// char* nativeTest()
	public static string CallnativeTest() {
		IntPtr pResult = nativeTest();
		string result = Marshal.PtrToStringAnsi(pResult);
		Marshal.FreeHGlobal(pResult);
		Debug.Log("CallnativeTest = " + result);
		return result;
	}

	//	char* nativeSolReadFile(const char* filename, int common, int svno);
	public static string CallnativeSolReadFile(string filename, int common, int svno) {
		Debug.Log("CallnativeSolReadFile filename = " + filename + " common = " + common + " svno = " + 0);
		IntPtr pFilename = Marshal.StringToHGlobalAnsi(filename);
		IntPtr pResult = nativeSolReadFile(pFilename, common, svno);
		string result = Marshal.PtrToStringAnsi(pResult);

		Marshal.FreeHGlobal(pFilename);
		// Debug.Log("CallnativeSolReadFile = " + result);
		return result;
	}

	public static string CallGetMyName() {
		IntPtr pResult = getMyName();
		string result = Marshal.PtrToStringAnsi(pResult);

		Marshal.FreeHGlobal(pResult);
		Debug.Log("CallGetMyName = " + result);
		return result;
	}

	// 	char* getFileNameToUnity(const char* filename, int common, int svno)
	public static string CallgGetFileNameToUnity(string filename, int common, int svno) {
		Debug.Log("CallgGetFileNameToUnity filename = " + filename);
		IntPtr pFilename = Marshal.StringToHGlobalAnsi(filename);
		IntPtr pResult = getFileNameToUnity(pFilename, common, svno);
		string result = Marshal.PtrToStringAnsi(pResult);

		Marshal.FreeHGlobal(pFilename);
		Debug.Log("CallgGetFileNameToUnity = " + result);
		return result;
	}
}
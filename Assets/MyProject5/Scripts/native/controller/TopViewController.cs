using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopViewController : MonoBehaviour {

//	private MyIAPHelper m_IAPHelper;
//	private MyAdManager m_AdManager;

	private MySoundManager m_Sound;

	private AndroidPlugin m_AndroidPluguin;

//	public static string m_FileName = ".testJni2Unity";
//	public static string m_DeleteFileName = ".testJni2Unity";

	public static string m_FileName = null;
	public static string m_DeleteFileName = null;

	public const int Release     = 0;
	public const int Staging     = 1;
	public const int Develop     = 2;

	public const int Common      = 0;
	public const int NotCommon   = 1;

	public static string m_Sol_Name     = ".androidFE474DEC";
	public static string m_Sol_STG      = ".androidFE474DECS";
	public static string m_Sol_DEV      = ".androidFE474DECD";

	public void Awake()
	{
		MyLog.D("TopViewController Awake start");
		// Google or Apple
//		m_IAPHelper = MyIAPHelper.Instance;
//		m_AdManager = MyAdManager.Instance;

		#if UNITY_ANDROID
		if (null == m_AndroidPluguin) {
			m_AndroidPluguin = gameObject.AddComponent<AndroidPlugin>();
			MyLog.I("add AndroidPlugin");
		}
		m_AndroidPluguin.inits();
		#endif
		InitUI();
	}

	private void InitUI()
	{
		MyLog.I("InitUI");
		// FB.Init(this.OnInitComplete, this.OnHideUnity);

//		if (GetStartButton() != null) 
//		{
//			GetStartButton().onClick.AddListener(() => {
//				// webView
//				// MyHttpRequestManager http = gameObject.AddComponent<MyHttpRequestManager>();
//				gameObject.AddComponent<MyHttpRequestManager>();
//			});
//		}

//		if (GetBuyButton() != null) 
//		{
//			GetBuyButton().onClick.AddListener(() => {
//				m_IAPHelper.Purchase(null);
//				if (m_IAPHelper.m_PurchaseInProgress == true) {
//					return;
//				}
//			});
//		}

//		if (GetTapjoyButton() != null)
//		{
//			GetTapjoyButton().onClick.AddListener(() => {
//				// m_AdManager.TapjoyEvents();
//			});
//		}

//		if (GetFacebookButton() != null) 
//		{
//			GetFacebookButton().onClick.AddListener(() => {
//				// m_AdManager.FBAuth();
//			});
//		}

//		if (GetMovieButton() != null) 
//		{
//			GetMovieButton().onClick.AddListener(() => {
//				MyLog.I("click Movie");
//				if (null == m_Sound) {
//					m_Sound = GameObject.Find("SoundObject").GetComponent<MySoundManager>();
//				}
//				if (null != m_Sound) {
//					m_Sound.playSound1();
//					MyLog.I("playSound1");
//				} else {
//					MyLog.I("playSound1 null");
//				}
//				//				// 動画再生
//				// Handheld.PlayFullScreenMovie ("opmv", Color.black, FullScreenMovieControlMode.CancelOnInput);
//			});
//		}

//		if (GetSoundButton() != null) 
//		{
//			GetSoundButton().onClick.AddListener(() => {
//				MyLog.I("click Sound");
//				if (null == m_Sound) {
//					m_Sound = GameObject.Find("SoundObject").GetComponent<MySoundManager>();
//				}
//				if (null != m_Sound) {
//					m_Sound.playSound2();
//					MyLog.I("playSound2");
//				} else {
//					MyLog.I("playSound2 null");
//				}
//				// m_AdManager.toFacebookEvent();
//			});
//		}

		if (GetCommonWriteFileButton() != null) 
		{
			GetCommonWriteFileButton().onClick.AddListener(() => {
				int writeResult = SgpJni.CallnativeWriteFile(m_FileName, "CallNativeWriteCommonFile", Common, Staging);
				MyLog.I("GetNativeWriteButton CallnativeWriteFile writeResult = " + writeResult);
			});
		}
		if (GetNativeReadButton() != null) 
		{
			GetNativeReadButton().onClick.AddListener(() => {
				string commonResurl = SgpJni.CallNativeReadFile(m_FileName, Common, Staging);
				MyLog.I("GetNativeReadButton CallNativeReadFile commonResurl = " + commonResurl);

				string NotCommonResurl = SgpJni.CallNativeReadFile(m_FileName, NotCommon, Staging);
				MyLog.I("GetNativeReadButton CallNativeReadFile NotCommonResurl = " + NotCommonResurl);
				// m_AdManager.FBAuth();
			});
		}

		if (GetNativeWriteButton() != null)
		{
			GetNativeWriteButton().onClick.AddListener(() => {
				// int nativeWriteFile(const char* filename, char* text, int common, int svno);
				int commonResurl = SgpJni.CallnativeWriteFile(m_FileName, "common_CallnativeWriteFile", Common, Staging);
				MyLog.I("GetNativeWriteButton CallnativeWriteFile commonResurl = " + commonResurl);

				int NotCommonResurl = SgpJni.CallnativeWriteFile(m_FileName, "1234test567890", NotCommon, Staging);
				MyLog.I("GetNativeWriteButton CallnativeWriteFile NotCommonResurl = " + NotCommonResurl);
				// m_AdManager.FBAuth();
			});
		}

		if (GetSolReadButton() != null) 
		{
			GetSolReadButton().onClick.AddListener(() => {
				string readResult = SgpJni.CallnativeSolReadFile(m_Sol_Name, Common, Release);
				MyLog.I("nativeSolReadFile readResult = " + readResult);

				string readStg = SgpJni.CallnativeSolReadFile(m_Sol_STG, Common, Staging);
				MyLog.I("nativeSolReadFile readStg = " + readStg);

				string readDev = SgpJni.CallnativeSolReadFile(m_Sol_DEV, Common, Develop);
				MyLog.I("nativeSolReadFile readDev = " + readDev);

				string readResult2 = SgpJni.CallnativeSolReadFile(m_Sol_Name, NotCommon, Release);
				MyLog.I("nativeSolReadFile readResult2 = " + readResult2);

				string readStg2 = SgpJni.CallnativeSolReadFile(m_Sol_STG, NotCommon, Staging);
				MyLog.I("nativeSolReadFile readStg2 = " + readStg2);

				string readDev2 = SgpJni.CallnativeSolReadFile(m_Sol_DEV, NotCommon, Develop);
				MyLog.I("nativeSolReadFile readDev2 = " + readDev2);
			});
		}
		if (GetUAButton() != null) 
		{
			GetUAButton().onClick.AddListener(() => {
				string readResult = SgpJni.CallnativeGetUserAgent();
				MyLog.W("GetUAButton CallnativeGetUserAgent = " + readResult);
			});
		}

		if (GetFilePathButton() != null) 
		{
			GetFilePathButton().onClick.AddListener(() => {
				string common = SgpJni.CallgGetFileNameToUnity(m_FileName, Common, Staging);
				MyLog.W("CallgGetFileNameToUnity common = " + common);

				string notCommon = SgpJni.CallgGetFileNameToUnity(m_FileName, NotCommon, Staging);
				MyLog.W("CallgGetFileNameToUnity notCommon = " + notCommon);
			});
		}
		if (GetCheckButton() != null) 
		{
			GetCheckButton().onClick.AddListener(() => {
				int check = SgpJni.CallnativeCheckNT();
				MyLog.W("CallnativeCheckNT = " + check);

				string test = SgpJni.CallnativeTest();
				MyLog.W("CallnativeTest test = " + test);

			});
		}
		if (GetDeleteButton() != null) 
		{
			GetDeleteButton().onClick.AddListener(() => {
				int common = SgpJni.CallNativeDeleteFile(m_DeleteFileName, Common, Staging);
				MyLog.W("GetDeleteButton GetDeleteButton = " + common);

				int notCommon = SgpJni.CallNativeDeleteFile(m_DeleteFileName, NotCommon, Staging);
				MyLog.W("GetDeleteButton GetDeleteButton = " + notCommon);
			});
		}
		if (GetNativeButton() != null) 
		{
			GetNativeButton().onClick.AddListener(() => {
				MyLog.I("click GetNativeButton");
				if (null == m_AndroidPluguin) {
					m_AndroidPluguin = gameObject.AddComponent<AndroidPlugin>();
					MyLog.I("add AndroidPlugin");
				}
				// ShowDialog(string method, string title, string message, 
				// string positiveMS, string neutralMS, string negativeMS, string showMS) {
				m_AndroidPluguin.ShowDialog("ShowMessage", "NativeDialog", "Select", "Toast", "Neutoral", "no", "Android");
				// Native
			});
		}
//		if (GetChangeButton() != null) 
//		{
//			GetChangeButton().onClick.AddListener(() => {
//				MyLog.I("click GetChangeButton");
//				if (null == m_AndroidPluguin) {
//					m_AndroidPluguin = gameObject.AddComponent<AndroidPlugin>();
//					MyLog.I("add AndroidPlugin");
//				}
//				Button button = GetChangeButton();
//				Text text = button.GetComponentInChildren<Text>();
//
//				if (tempValue == 0) {
//					tempValue = 3;
//				}
//				int after = m_AndroidPluguin.ChangeNative("ChangeValue", tempValue);
//				text.text = "after = " + after;
//				tempValue = after;
//				MyLog.I("Top after = " + after);
//				// Native
//			});
//		}

		if (GetPushButton() != null) 
		{
			if (Application.platform == RuntimePlatform.Android) {
				GetPushButton().onClick.AddListener(() => {
					MyLog.I("click GetPushButton");
					if (null == m_AndroidPluguin) {
						m_AndroidPluguin = gameObject.AddComponent<AndroidPlugin>();
						MyLog.I("add AndroidPlugin");
					}
					string token = m_AndroidPluguin.GetToken("GetAndroidToken");
					MyLog.I("GetPushButton token = " + token);
				});
			}
		}
	}

	public void Start()
	{
		MyLog.I("TopViewController start");
		// m_AdManager.OnStart();
	}

	public static void FinishPurchaseEvent(object sender, EventArgs e){
		MyLog.I("FinishPurchaseEvent " + sender);
		// MyAdManager.EndPurchase((String)sender);
	}

	// Update is called once per frame
	public void Update()
	{
		// m_AdManager.OnUpdate();
	}

	private Button GetBuyButton()
	{
		MyLog.D("GetBuyButton");
		return GameObject.Find("BuyButton").GetComponent<Button>();
	}
	private Button GetTapjoyButton()
	{
		MyLog.D("GetTapjoyButton");
		return GameObject.Find("TapjoyButton").GetComponent<Button>();
	}
	private Button GetFacebookButton()
	{
		MyLog.D("GetFacebookButton");
		return GameObject.Find("FacebookButton").GetComponent<Button>();
	}
	private Button GetStartButton()
	{
		MyLog.D("GetStartButton");
		return GameObject.Find("StartButton").GetComponent<Button>();
	}
	private Button GetMovieButton()
	{
		MyLog.D("GetMovieButton");
		return GameObject.Find("MovieButton").GetComponent<Button>();
	}
	private Button GetSoundButton()
	{
		MyLog.D("GetSoundButton");
		return GameObject.Find("SoundButton").GetComponent<Button>();
	}
	private Button GetCommonWriteFileButton()
	{
		MyLog.D("GetCommonWriteFileButton");
		return GameObject.Find("CommonWriteFileButton").GetComponent<Button>();
	}
	private Button GetSolReadButton()
	{
		MyLog.D("GetSolReadButton");
		return GameObject.Find("SolReadButton").GetComponent<Button>();
	}
	private Button GetNativeButton()
	{
		MyLog.D("GetNativeButton");
		return GameObject.Find("NativeButton").GetComponent<Button>();
	}
	private Button GetChangeButton()
	{
		MyLog.D("GetChangeButton");
		return GameObject.Find("ChangeButton").GetComponent<Button>();
	}
	private Button GetPushButton()
	{
		MyLog.D("GetPushButton");
		return GameObject.Find("PushButton").GetComponent<Button>();
	}
	private Button GetUAButton()
	{
		MyLog.D("GetUAButton");
		return GameObject.Find("UAButton").GetComponent<Button>();
	}
	private Button GetFilePathButton()
	{
		MyLog.D("GetFilePathButton");
		return GameObject.Find("FilePathButton").GetComponent<Button>();
	}
	private Button GetCheckButton()
	{
		MyLog.D("GetCheckButton");
		return GameObject.Find("CheckButton").GetComponent<Button>();
	}

	private Button GetDeleteButton()
	{
		MyLog.D("GetDeleteButton");
		return GameObject.Find("DeleteButton").GetComponent<Button>();
	}

	private Button GetNativeReadButton()
	{
		MyLog.D("GetNativeReadButton");
		return GameObject.Find("NativeReadButton").GetComponent<Button>();
	}

	private Button GetNativeWriteButton()
	{
		MyLog.D("GetNativeWriteButton");
		return GameObject.Find("NativeWriteButton").GetComponent<Button>();
	}

	void OnGUI () {
		// Plane plane = GetLogPlane();
		MyLog.DrawLogWindow(new Rect(10, 10, 1600, 1000));
		// Make a background box
		GUI.Box(new Rect(1000,10,200,180), "Loader Menu");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(1020,40,160,40), "Level 1")) {
			SceneManager.LoadScene(1);
		}

		// Make the second button.
		if(GUI.Button(new Rect(1020,90,160,40), "Level 2")) {
			SceneManager.LoadScene(2);
		}
	}
}


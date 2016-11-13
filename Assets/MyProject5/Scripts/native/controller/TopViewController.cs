using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopViewController : MonoBehaviour {
	private const string TAG = "TopViewController";

//	private MyIAPHelper m_IAPHelper;
//	private MyAdManager m_AdManager;

	private MySoundManager m_Sound;

	#if UNITY_ANDROID
	private AndroidPlugin m_AndroidPluguin;
	#endif

	// private HttpCreateTask        m_HttpTask;
	private HttpGetTask           m_HttpGetTask;
	private HttpGetOnlyFbTask     m_HttpGetOnlyFbTask;
	private HttpGetWithFbTask     m_HttpGetWithFbTask;

	private HttpLinkTask          m_HttpLinkTaskk;
	private HttpCreateOnlyFbTask  m_HttpCreateOnlyFbTask;

	private HttpBaseTask          m_HttpTask;

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

//	public static string m_Sol_Name     = ".android66fa9d87";
//	public static string m_Sol_STG      = ".android66fa9d87s";
//	public static string m_Sol_DEV      = ".android66fa9d87d";

//	public static string m_Sol_Name     = "";
//	public static string m_Sol_STG      = "";
//	public static string m_Sol_DEV      = "";

	public void Awake()
	{
		MyLog.D(TAG, "TopViewController Awake start");
		// Google or Apple
//		m_IAPHelper = MyIAPHelper.Instance;
//		m_AdManager = MyAdManager.Instance;

		#if UNITY_ANDROID
		if (null == m_AndroidPluguin) {
			m_AndroidPluguin = gameObject.AddComponent<AndroidPlugin>();
			MyLog.I(TAG, "add AndroidPlugin");
		}
		m_AndroidPluguin.inits();
		#endif
		InitUI();
	}

	private void InitUI()
	{
		MyLog.I(TAG, "InitUI");
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
				#if UNITY_ANDROID
				int writeResult = SgpJni.CallnativeWriteFile(m_FileName, "CallNativeWriteCommonFile", Common, Staging);
				MyLog.I(TAG, "GetNativeWriteButton CallnativeWriteFile writeResult = " + writeResult);
				#endif
			});
		}
		if (GetNativeReadButton() != null) 
		{
			GetNativeReadButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				string commonResurl = SgpJni.CallNativeReadFile(m_FileName, Common, Staging);
				MyLog.I(TAG, "GetNativeReadButton CallNativeReadFile commonResurl = " + commonResurl);

				string NotCommonResurl = SgpJni.CallNativeReadFile(m_FileName, NotCommon, Staging);
				MyLog.I(TAG, "GetNativeReadButton CallNativeReadFile NotCommonResurl = " + NotCommonResurl);
				#endif
			});
		}

		if (GetNativeWriteButton() != null)
		{
			GetNativeWriteButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				// int nativeWriteFile(const char* filename, char* text, int common, int svno);
				int commonResurl = SgpJni.CallnativeWriteFile(m_FileName, "common_CallnativeWriteFile", Common, Staging);
				MyLog.I(TAG, "GetNativeWriteButton CallnativeWriteFile commonResurl = " + commonResurl);

				int NotCommonResurl = SgpJni.CallnativeWriteFile(m_FileName, "1234test567890", NotCommon, Staging);
				MyLog.I(TAG, "GetNativeWriteButton CallnativeWriteFile NotCommonResurl = " + NotCommonResurl);
				#endif
			});
		}

		if (GetSolReadButton() != null) 
		{
			GetSolReadButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				string releaseCommon = SgpJni.CallnativeSolReadFile(m_Sol_Name, Common, Release);
				MyLog.I(TAG, "nativeSolReadFile releaseCommon = " + releaseCommon);
				// TODO 加工

				string releaseNotCommon = SgpJni.CallnativeSolReadFile(m_Sol_Name, NotCommon, Release);
				MyLog.I(TAG, "nativeSolReadFile releaseNotCommon = " + releaseNotCommon);

				string stagingCommon = SgpJni.CallnativeSolReadFile(m_Sol_STG, Common, Staging);
				MyLog.I(TAG, "nativeSolReadFile stagingCommon= " + stagingCommon);

				string stagingNotCommon = SgpJni.CallnativeSolReadFile(m_Sol_STG, NotCommon, Staging);
				MyLog.I(TAG, "nativeSolReadFile stagingNotCommon = " + stagingNotCommon);

				string developCommon = SgpJni.CallnativeSolReadFile(m_Sol_DEV, Common, Develop);
				MyLog.I(TAG, "nativeSolReadFile developCommon = " + developCommon);

				string developNotCommon = SgpJni.CallnativeSolReadFile(m_Sol_DEV, NotCommon, Develop);
				MyLog.I(TAG, "nativeSolReadFile developNotCommon = " + developNotCommon);
				#endif
			});
		}
		if (GetUAButton() != null) 
		{
			GetUAButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				string readResult = SgpJni.CallnativeGetUserAgent();
				MyLog.W(TAG, "GetUAButton CallnativeGetUserAgent = " + readResult);
				#endif
			});
		}

		if (GetFilePathButton() != null) 
		{
			GetFilePathButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				string common = SgpJni.CallgGetFileNameToUnity(m_FileName, Common, Staging);
				MyLog.W(TAG,"CallgGetFileNameToUnity common = " + common);

				string notCommon = SgpJni.CallgGetFileNameToUnity(m_FileName, NotCommon, Staging);
				MyLog.W(TAG,"CallgGetFileNameToUnity notCommon = " + notCommon);
				#endif
			});
		}
		if (GetCheckButton() != null) 
		{
			GetCheckButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				int check = SgpJni.CallnativeCheckNT();
				MyLog.W(TAG,"CallnativeCheckNT = " + check);

				string test = SgpJni.CallnativeTest();
				MyLog.W(TAG,"CallnativeTest test = " + test);
				#endif
			});
		}
		if (GetDeleteButton() != null) 
		{
			GetDeleteButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				int common = SgpJni.CallNativeDeleteFile(m_DeleteFileName, Common, Staging);
				MyLog.W(TAG, "GetDeleteButton GetDeleteButton = " + common);

				int notCommon = SgpJni.CallNativeDeleteFile(m_DeleteFileName, NotCommon, Staging);
				MyLog.W(TAG, "GetDeleteButton GetDeleteButton = " + notCommon);
				#endif
			});
		}
		if (GetNativeButton() != null) 
		{
			GetNativeButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				MyLog.I(TAG, "click GetNativeButton");
				if (null == m_AndroidPluguin) {
					m_AndroidPluguin = gameObject.AddComponent<AndroidPlugin>();
					MyLog.I(TAG, "add AndroidPlugin");
				}
				// ShowDialog(string method, string title, string message, 
				// string positiveMS, string neutralMS, string negativeMS, string showMS) {
				m_AndroidPluguin.ShowDialog("ShowMessage", "NativeDialog", "Select", "Toast", "Neutoral", "no", "Android");
				#endif
			});
		}

		if (GetPushButton() != null) 
		{
				GetPushButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				MyLog.I(TAG, "click GetPushButton");
				if (null == m_AndroidPluguin) {
					m_AndroidPluguin = gameObject.AddComponent<AndroidPlugin>();
					MyLog.I(TAG, "add AndroidPlugin");
				}
				string token = m_AndroidPluguin.GetToken("GetAndroidToken");
				MyLog.I(TAG, "GetPushButton token = " + token);
				});
				#endif
		}
		if (GetCreateButton() != null) 
		{
			GetCreateButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				authTask();
				#endif
			});
		}
	}

	// 認証関連
	public void authTask() {
		MyLog.I(TAG, "authTask start");

		// nativeからauth term取得

		// TO jni

		// FinishApi {"entry":{"appId":"95","authCode":"GJEJx0hhNa","gamecenterId":"",
		// "googleId":"","facebook_id":"105177593297634","invitationCode":"EtTe64bt4N","
		// termId":"6ui8qsNNzE","invitationId":"","userType":"0","status":"0"}}


		MyUser user = new MyUser();
		string authCode = "";
		string termId = "";
		string facebookId = "";
		user.Initialize(authCode, termId, facebookId);
		// user.Initialize("", "", "105177593297634"); // ok
		MyLog.W(TAG, "HttpManager MyUser Initialize");

		user.checkValue();
		string build = user.GetAppVersionName_Android();
		MyLog.W(TAG, "HttpManager MyUser build = " + build);

		// TODO 実行API判定
		if (authCode == string.Empty) {
			MyLog.I(TAG, "authCode null");
			if (facebookId == string.Empty) {
				MyLog.I(TAG, "facebookId null to HttpCreateTask");
				m_HttpTask = (HttpCreateTask)gameObject.AddComponent<HttpCreateTask>();
				m_HttpTask.ExecApiTask(user);
			} else {
				MyLog.I(TAG, "facebookId 存在 to HttpGetOnlyFbTask");
				m_HttpTask = (HttpGetOnlyFbTask)gameObject.AddComponent<HttpGetOnlyFbTask>();
				m_HttpTask.ExecApiTask(user);
			}
		} else {
			MyLog.I(TAG, "authCode 存在 to HttpGetTask");
			if (facebookId == string.Empty) {
				MyLog.I(TAG, "facebookId null");
				m_HttpTask = (HttpGetTask)gameObject.AddComponent<HttpGetTask>();
				m_HttpTask.ExecApiTask(user);
			} else {
				MyLog.I(TAG, "facebookId 存在 to HttpGetWithFbTask");
				m_HttpTask = (HttpGetWithFbTask)gameObject.AddComponent<HttpGetWithFbTask>();
				m_HttpTask.ExecApiTask(user);
			}
		}
		// auth無 fb有
		// m_HttpTask = (HttpCreateOnlyFbTask)gameObject.AddComponent<HttpCreateOnlyFbTask>();
		// m_HttpTask.ExecApiTask(user);

		// auth無 fb有
		// m_HttpTask = (HttpLinkTask)gameObject.AddComponent<HttpLinkTask>();
		// m_HttpTask.ExecApiTask(user);
		// 端末保存

		// 広告SDK

		// MyPage遷移
	}

	public static void HttpTaskFinishedDelegate(string statusCode, object sender, EventArgs e){
		MyLog.I(TAG, "HttpTaskFinishedDelegate " + (string)sender);
	}

	public void Start()
	{
		MyLog.I(TAG, "start");
		// m_AdManager.OnStart();
	}

	public static void FinishPurchaseEvent(object sender, EventArgs e){
		MyLog.I(TAG, "FinishPurchaseEvent " + sender);
		// MyAdManager.EndPurchase((String)sender);
	}

	// Update is called once per frame
	public void Update()
	{
		// m_AdManager.OnUpdate();
	}

	private Button GetBuyButton()
	{
		return GameObject.Find("BuyButton").GetComponent<Button>();
	}
	private Button GetTapjoyButton()
	{
		return GameObject.Find("TapjoyButton").GetComponent<Button>();
	}
	private Button GetFacebookButton()
	{
		return GameObject.Find("FacebookButton").GetComponent<Button>();
	}
	private Button GetStartButton()
	{
		return GameObject.Find("StartButton").GetComponent<Button>();
	}
	private Button GetMovieButton()
	{
		return GameObject.Find("MovieButton").GetComponent<Button>();
	}
	private Button GetSoundButton()
	{
		return GameObject.Find("SoundButton").GetComponent<Button>();
	}
	private Button GetCommonWriteFileButton()
	{
		return GameObject.Find("CommonWriteFileButton").GetComponent<Button>();
	}
	private Button GetSolReadButton()
	{
		return GameObject.Find("SolReadButton").GetComponent<Button>();
	}
	private Button GetNativeButton()
	{
		return GameObject.Find("NativeButton").GetComponent<Button>();
	}
	private Button GetChangeButton()
	{
		return GameObject.Find("ChangeButton").GetComponent<Button>();
	}
	private Button GetPushButton()
	{
		return GameObject.Find("PushButton").GetComponent<Button>();
	}
	private Button GetUAButton()
	{
		return GameObject.Find("UAButton").GetComponent<Button>();
	}
	private Button GetFilePathButton()
	{
		return GameObject.Find("FilePathButton").GetComponent<Button>();
	}
	private Button GetCheckButton()
	{
		return GameObject.Find("CheckButton").GetComponent<Button>();
	}

	private Button GetDeleteButton()
	{
		return GameObject.Find("DeleteButton").GetComponent<Button>();
	}

	private Button GetNativeReadButton()
	{
		return GameObject.Find("NativeReadButton").GetComponent<Button>();
	}

	private Button GetNativeWriteButton()
	{
		return GameObject.Find("NativeWriteButton").GetComponent<Button>();
	}

	private Button GetCreateButton()
	{
		return GameObject.Find("CreateButton").GetComponent<Button>();
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
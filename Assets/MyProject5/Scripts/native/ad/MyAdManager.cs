using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Tapjoy
using TapjoyUnity;

// Adjust
using com.adjust.sdk;

// Facebook
//using Facebook;
//using Facebook.Unity;
using System.Linq;

public class MyAdManager : MonoBehaviour {
	private const string TAG = "MyAdManager";

	private static MyAdManager mInstance;

	// Tapjoy
	public TJPlacement offerwallPlacement;

	// Facebook
	// private string facebookStatus = "Ready";
	private string facebookLastResponse = string.Empty;

	// Private Constructor
	private MyAdManager () {		
		Initialize();
	}
	public static MyAdManager Instance {
		get {
			if( mInstance == null )  
			{
				mInstance = new MyAdManager();
				MyLog.I(TAG, "new MyAdManager");
			}
			return mInstance;
		}
	}

	private void Initialize() {
		if (!Tapjoy.IsConnected) {
			// Tapjoy.Connect(MyConfig.TAPJOY_KEY);
			MyLog.D(TAG, "Start to Tapjoy.Connect");
		}

		// FB init
//		if (FB.IsInitialized) {
//			FB.ActivateApp();
//		} else {
//			//Handle FB.Init
//			FB.Init( () => {
//				FB.ActivateApp();
//				MyLog.D("Facebook ActivateApp");
//			});
//		}
		//		FB.Init(this.OnInitComplete, this.OnHideUnity);
		//		facebookStatus = "FB.Init() called with " + FB.AppId;
		//		MyLog.D("Facebook = " + facebookStatus);	
	}

	#region Tapjoy
	public void TapjoyEvents() 
	{
		if(Tapjoy.IsConnected) {
			// Create offerwall placement
			if (offerwallPlacement == null) {
				offerwallPlacement = TJPlacement.CreatePlacement("unitys");

			}
			if(offerwallPlacement.IsContentReady()) {
				offerwallPlacement.ShowContent();
			} else {
				offerwallPlacement.RequestContent();
				offerwallPlacement.ShowContent();
				MyLog.W(TAG, "Tapjoy offerwallPlacement.IsContentReady false");
				//Code to handle situation where content is not ready goes here
			}
		} else {
			// Tapjoy.Connect(MyConfig.TAPJOY_KEY);
			MyLog.W(TAG, "Tapjoy.IsConnected false");
		}
	}
	public void OnDisable() {
		MyLog.D(TAG, "C#: Disabling and removing Tapjoy Delegates");

		// Placement delegates
		TJPlacement.OnRequestSuccess -= HandlePlacementRequestSuccess;
		TJPlacement.OnRequestFailure -= HandlePlacementRequestFailure;
		TJPlacement.OnContentReady -= HandlePlacementContentReady;
		TJPlacement.OnContentShow -= HandlePlacementContentShow;
		TJPlacement.OnContentDismiss -= HandlePlacementContentDismiss;
		TJPlacement.OnPurchaseRequest -= HandleOnPurchaseRequest;
		TJPlacement.OnRewardRequest -= HandleOnRewardRequest;
	}
	#endregion

	#region Placement Delegate Handlers
	public void HandlePlacementRequestSuccess(TJPlacement placement) {
		if (placement.IsContentAvailable()) {
			placement.ShowContent();
		} else {
			MyLog.D(TAG, "C#: No content available for " + placement.GetName());
		}
	}

	public void HandlePlacementRequestFailure(TJPlacement placement, string error) {
		MyLog.D(TAG, "C#: HandlePlacementRequestFailure");
		MyLog.D(TAG, "C#: Request for " + placement.GetName() + " has failed because: " + error);
	}

	public void HandlePlacementContentReady(TJPlacement placement) {
		MyLog.D(TAG, "C#: HandlePlacementContentReady");
		if (placement.IsContentAvailable()) {
			placement.ShowContent();
		} else {
			MyLog.D(TAG, "C#: no content");
		}
	}

	public void HandlePlacementContentShow(TJPlacement placement) {
		MyLog.D(TAG, "C#: HandlePlacementContentShow");
	}

	public void HandlePlacementContentDismiss(TJPlacement placement) {
		MyLog.D(TAG, "C#: HandlePlacementContentDismiss");
	}

	public void HandleOnPurchaseRequest (TJPlacement placement, TJActionRequest request, string productId)
	{
		MyLog.D(TAG, "C#: HandleOnPurchaseRequest");
		request.Completed();
	}

	public void HandleOnRewardRequest (TJPlacement placement, TJActionRequest request, string itemId, int quantity)
	{
		MyLog.D(TAG, "C#: HandleOnRewardRequest");
		request.Completed();
	}
	#endregion

	#region Facebook
//	private void OnInitComplete()
//	{
//		facebookStatus = "Success - Check log for details";
//		facebookLastResponse = "Success Response: OnInitComplete Called\n";
//		string logMessage = string.Format(
//			"OnInitCompleteCalled IsLoggedIn='{0}' IsInitialized='{1}'",
//			FB.IsLoggedIn,
//			FB.IsInitialized);
//		MyLog.I(logMessage);
//		if (AccessToken.CurrentAccessToken != null)
//		{
//			MyLog.I("UserId = " + AccessToken.CurrentAccessToken.UserId);
//		}
//	}
//
//	private void OnHideUnity(bool isGameShown)
//	{
//		facebookStatus = "Success - Check log for details";
//		facebookLastResponse = string.Format("Success Response: OnHideUnity Called {0}\n", isGameShown);
//		MyLog.I("Is game shown: " + isGameShown);
//	}
//
//	public void FBAuth() {
//		MyLog.I("FBAuth");
//		if (AccessToken.CurrentAccessToken != null) {
//			CallFBLogout();
//		} else {
//			CallFBLogin();
//			facebookStatus = "Login called";
//		}
//		MyLog.W("FacebookStatus = " + facebookStatus);
//	}
//
//	private void CallFBLogin()
//	{
//		MyLog.I("CallFBLogin");
//		FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" }, this.HandleResult);
//	}
//
//	private void CallFBLogout()
//	{
//		MyLog.I("CallFBLogout");
//		FB.LogOut();
//	}
//
//	protected void HandleResult(IResult result)
//	{
//		if (result == null)
//		{
//			facebookLastResponse = "Null Response\n";
//			MyLog.I(facebookLastResponse);
//			return;
//		}
//		// this.LastResponseTexture = null;
//
//		// Some platforms return the empty string instead of null.
//		if (!string.IsNullOrEmpty(result.Error))
//		{
//			facebookStatus = "Error - Check log for details";
//			facebookLastResponse = "Error Response:\n" + result.Error;
//		}
//		else if (result.Cancelled)
//		{
//			facebookStatus = "Cancelled - Check log for details";
//			facebookLastResponse = "Cancelled Response:\n" + result.RawResult;
//		}
//		else if (!string.IsNullOrEmpty(result.RawResult))
//		{
//			facebookStatus = "Success - Check log for details";
//			facebookLastResponse = "Success Response:\n" + result.RawResult;
//		}
//		else
//		{
//			facebookLastResponse = "Empty Response\n";
//		}
//		MyLog.I(result.ToString());
//	}
	#endregion

	public static void EndPurchase(string id)
	{
		MyLog.I(TAG, "MyAdManager EndPurchase");
		// 広告SDK関連処理
		Tapjoy.TrackPurchase(id, "JPY", (double)(200), null);

		// TODO Adjust
		//
		//		AdjustEvent adjustEvent = new AdjustEvent("abc123");
		//		adjustEvent.addPartnerParameter("key", "value");
		//		adjustEvent.addPartnerParameter("foo", "bar");
		//		Adjust.trackEvent(adjustEvent);

		// TODO FaceBook
		Dictionary<string, object> iapParameters = new Dictionary<string, object>();
		iapParameters["product"] = id;
	 //	FB.LogPurchase((long)(200), "JPY", iapParameters);
	}

	public void toFacebookEvent() {
		MyLog.I(TAG, "toFacebookEvent");
		// FB.LogAppEvent(AppEventName.CompletedRegistration, 200, null);
	}

	public void OnStart()
	{
		MyLog.I(TAG, "MyAdManager OnStart");
		// Adjust
		// zfrazid5itq8
		AdjustConfig adjustConfig = new AdjustConfig(MyConfig.ADJUST_TOKEN, AdjustEnvironment.Sandbox);
		adjustConfig.setLogLevel(AdjustLogLevel.Verbose);
		Adjust.start(adjustConfig);
	}

	public void OnUpdate()
	{
		if (Tapjoy.IsConnected) {
			if(null != offerwallPlacement && offerwallPlacement.IsContentReady()) {
				MyLog.W(TAG, "Update Tapjoy ShowContent");
				offerwallPlacement.ShowContent();
			}
		}
	}

	// Use this for initialization
	void Start() {MyLog.I(TAG, "MyAdManager Start");}

	// Update is called once per frame
	void Update() {MyLog.I(TAG, "MyAdManager Update");}
}

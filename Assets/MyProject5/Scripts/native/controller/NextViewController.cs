using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Diagnostics; // Conditional

using com.adjust.sdk;

/// <summary>
/// NextSene　コントローラー
/// </summary>
public class NextViewController : MonoBehaviour {
	private const string TAG = "NextViewController";

	#if UNITY_ANDROID
	private AndroidPlugin m_AndroidPluguin;
	#endif

	public void Awake()
	{
		MyLog.D(TAG, "TopViewController Awake start");

		#if UNITY_ANDROID
		// m_AndroidPluguin = gameObject.Find("AndroidPlugin").GetComponent<AndroidPlugin>();
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

		if (GetBackButton() != null) 
		{
			GetBackButton().onClick.AddListener(() => {
				#if UNITY_ANDROID
				SceneManager.LoadScene("top");
				#endif
			});
		}

		if (GetMovekButton() != null) 
		{
			GetMovekButton().onClick.AddListener(() => {
				bool resilt =  NextConfig.moveType;
				resilt = !resilt;
				NextConfig.moveType = resilt;
				MyLog.I(TAG, "GetMovekButton resilt = " + resilt);
			});
		}
	}
	public void Start()
	{
		MyLog.I(TAG, "start");
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
	private Button GetBackButton()
	{
		return GameObject.Find("BackButton").GetComponent<Button>();
	}
	private Button GetMovekButton()
	{
		return GameObject.Find("MovekButton").GetComponent<Button>();
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
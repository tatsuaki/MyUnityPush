using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HttpManager : MonoBehaviour {
	private const string TAG = "HttpManager";
	private HttpGetTask   m_HttpGetTask;

//	public static void FinishApi(object sender, EventArgs e){
//		MyLog.I("FinishApi " + (string)sender);
//	}

	public void startGetTask() {
		MyLog.I(TAG, "startGetTask");
		// nativeから取得
		MyUser user = new MyUser();
		user.Initialize("GJEJx0hhNa", "Tv5ujQDdBU");
		MyLog.W(TAG, "MyUser Initialize");

		user.checkValue();
		string build = user.GetAppVersionName_Android();
		MyLog.W(TAG, "MyUser build = " + build);

		// TODO API
		m_HttpGetTask = gameObject.AddComponent<HttpGetTask>();
		m_HttpGetTask.ExecApiTask(user);
	}

	// Use this for initialization
	void Start () {
		MyLog.I(TAG, "start");
	}
	
	// Update is called once per frame
	void Update () {
		MyLog.I(TAG, "Update");
	}
}

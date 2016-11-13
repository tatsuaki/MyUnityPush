using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HttpGetWithFbTask : HttpBaseTask {
	private const string TAG = "HttpGetWithFbTask";
	// URL
	private const string url = "https://ozef.stg.shall-we-date.com/OZEF/sgp/get/";

	public MyUser tmpUser;

	// https://ozef.stg.shall-we-date.com/OZEF/sgp/get/ param 
	// [marketType=2, termId=Tv5ujQDdBU, authCode=GJEJx0hhNa, warningDevice=0]

	// サーバへリクエストするデータ
	// {"entry":{"authCode":"gDJxUmvfDq","termId":"ConlVy4d9M","invitationCode":"KnfjVL1qqn"}}

	// FinishApi {"entry":{"appId":"95","authCode":"GJEJx0hhNa","gamecenterId":"","googleId":"",
	// "facebook_id":"105177593297634","invitationCode":"EtTe64bt4N","termId":"Tv5ujQDdBU","invitationId":"",
	// "userType":"0","status":"0"}}

	public override void ExecApiTask(MyUser user) {
		MyLog.D(TAG, "ExecApiTask");
		tmpUser = user;
		// サーバへPOSTするデータを設定 
		Dictionary<string, string> status = user.m_status;
		status.Add ("marketType", "2");
		status.Add ("warningDevice", "0");
		StartCoroutine(requestHttp(url, status));
		foreach (KeyValuePair<string, string> pair in status)
		{
			MyLog.I(TAG, pair.Key + " : " + pair.Value);
		}
	}

	// HTTP POST リクエスト
	public override IEnumerator requestHttp(string url, Dictionary<string, string> post)
	{
		MyLog.D(TAG, "requestHttp");
		string status = "-1";

		WWWForm form = new WWWForm();
		foreach(KeyValuePair<String, String> post_arg in post) {
			form.AddField(post_arg.Key, post_arg.Value);
		}
		WWW www = new WWW(url, form);

		// 15秒タイムアウト
		yield return StartCoroutine(CheckTimeOut(www, timeoutsec));

		Dictionary<string, string> array = www.responseHeaders;
		status = getStatus(array);
		MyLog.W(TAG, "STATUS = " + status);
		MyLog.E(TAG, "error " + www.error);
		MyLog.W(TAG, "www.text = " + www.text);

		httpTaskFinishedDelegate = TopViewController.HttpTaskFinishedDelegate;
		if (status.Equals(GET_SUCCESS)) { // 200
			// auth比較

			// 異なる　→ 上書き確認ダイアログ
			// 			finishApi(YSER_CANCEL, null, null);

			// 同一    → 処理継続
			httpTaskFinishedDelegate(GET_SUCCESS, www.text, null);
		} else if (status.Equals(NO_SUCCESS)){ // 404 → HttpLinkTask
			// to link
			HttpLinkTask m_HttpTask = gameObject.AddComponent<HttpLinkTask>();
			m_HttpTask.ExecApiTask(tmpUser);
			// httpTaskFinishedDelegate(NO_SUCCESS, null, null);
		} else if (status.Equals("MAINTENANCE")){
			httpTaskFinishedDelegate("555", null, null);
		} else {
			httpTaskFinishedDelegate("999",www.text, null);
		}
	}
}

// user.Initialize("", "", "105177593297635"); ng
// ↓ 404
// to link

// 400?
// 200
// HttpGet = {"entry":{"appId":"95","authCode":"GJEJx0hhNa","gamecenterId":"","googleId":"","facebook_id":"105177593297634","invitationCode":"EtTe64bt4N","termId":"6ui8qsNNzE","invitationId":"","userType":"0","status":"0"}}

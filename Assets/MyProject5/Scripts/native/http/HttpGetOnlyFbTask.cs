using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/** authCode無 FacebookId有 */
public class HttpGetOnlyFbTask : HttpBaseTask {
	private const string TAG = "HttpGetOnlyFbTask";
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
		foreach (KeyValuePair<string, string> pair in status)
		{
			MyLog.I(TAG, pair.Key + " : " + pair.Value);
		}
		StartCoroutine(requestHttp(url, status));
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
			httpTaskFinishedDelegate(GET_SUCCESS, www.text, null);
		} else if (status.Equals(NO_SUCCESS)){ // 404 → HttpCreateOnlyFbTask
			// to create(FB)
			HttpCreateOnlyFbTask m_HttpTask = gameObject.AddComponent<HttpCreateOnlyFbTask>();
			m_HttpTask.ExecApiTask(tmpUser);
			// httpTaskFinishedDelegate(NO_SUCCESS, null, null);
		} else if (status.Equals("MAINTENANCE")){
			httpTaskFinishedDelegate("555", null, null);
		} else {
			httpTaskFinishedDelegate("999",www.text, null);
		}
	}
}

// termそのまま
// user.Initialize("", "", "105177593297634"); ok
// ↓ 200
// FinishApi {"entry":{"appId":"95","authCode":"GJEJx0hhNa","gamecenterId":"",
// "googleId":"","facebook_id":"105177593297634","invitationCode":"EtTe64bt4N","
// termId":"6ui8qsNNzE","invitationId":"","userType":"0","status":"0"}}

// user.Initialize("", "", "105177593297635"); ng
// ↓ 404
// create(FB)
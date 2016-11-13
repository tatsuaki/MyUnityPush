using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/** authCode有 FacebookId無 */
public class HttpGetTask : HttpBaseTask {
	private const string TAG = "HttpGetTask";
	// URL
	private const string url = "https://ozef.stg.shall-we-date.com/OZEF/sgp/get/";
		
	// https://ozef.stg.shall-we-date.com/OZEF/sgp/get/ param 
	// [marketType=2, termId=Tv5ujQDdBU, authCode=GJEJx0hhNa, warningDevice=0]

	// サーバへリクエストするデータ
	// {"entry":{"authCode":"gDJxUmvfDq","termId":"ConlVy4d9M","invitationCode":"KnfjVL1qqn"}}

	// FinishApi {"entry":{"appId":"95","authCode":"GJEJx0hhNa","gamecenterId":"","googleId":"",
	// "facebook_id":"105177593297634","invitationCode":"EtTe64bt4N","termId":"Tv5ujQDdBU","invitationId":"",
	// "userType":"0","status":"0"}}

	public override void ExecApiTask(MyUser user) {
		MyLog.E(TAG, "StartGetTask");
		// サーバへPOSTするデータを設定 
		Dictionary<string, string> status = user.m_status;
		status.Add ("marketType", "2");
		status.Add ("warningDevice", "0");
		StartCoroutine(requestHttp(url, status));
		foreach (KeyValuePair<string, string> pair in status)
		{
			MyLog.I(TAG, "param = " + pair.Key + " " + pair.Value);
		}
		MyLog.E(TAG, "StartGetTask after");
	}

	// HTTP POST リクエスト
	public override IEnumerator requestHttp(string url, Dictionary<string, string> post)
	{
		MyLog.E(TAG, "requestHttp");
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
		MyLog.E(TAG, "STATUS = " + status);
		MyLog.E(TAG, www.error);
		MyLog.E(TAG, www.text);

		httpTaskFinishedDelegate = TopViewController.HttpTaskFinishedDelegate;
		if (status.Equals(GET_SUCCESS)) { // 200
			httpTaskFinishedDelegate(GET_SUCCESS, www.text, null);
		} else if (status.Equals(NO_SUCCESS)){ // 404
			// to link
			httpTaskFinishedDelegate("404", null, null);
		} else if (status.Equals("MAINTENANCE")){
			httpTaskFinishedDelegate("555", null, null);
		} else {
			httpTaskFinishedDelegate("999",www.text, null);
		}

		// link
	}
}

// NULL kv.Key.ToString -> HTTP/1.1 200 OK
// STATUS kv.Key.ToString -> HTTP/1.1 200 OK
// ACCESS-CONTROL-ALLOW-HEADERS kv.Key.ToString -> X-REQUESTED-WITH
// ACCESS-CONTROL-ALLOW-ORIGIN kv.Key.ToString -> *
// CACHE-CONTROL kv.Key.ToString -> no-store, no-cache, must-revalidate, post-check=0, pre-check=0
// CONNECTION kv.Key.ToString -> keep-alive
// CONTENT-TYPE kv.Key.ToString -> application/json; charset=utf-8
// DATE kv.Key.ToString -> Sun, 13 Nov 2016 10:20:31 GMT
// EXPIRES kv.Key.ToString -> Thu, 19 Nov 1981 08:52:00 GMT
// PRAGMA kv.Key.ToString -> no-cache
// SERVER kv.Key.ToString -> nginx
// SET-COOKIE kv.Key.ToString -> PHPSESSID=vqfjs315gfmigckjgj6jpnhmu5; path=/
// TRANSFER-ENCODING kv.Key.ToString -> chunked
// X-ANDROID-RECEIVED-MILLIS kv.Key.ToString -> 1479032431858
// X-ANDROID-RESPONSE-SOURCE kv.Key.ToString -> NETWORK 200
// X-ANDROID-SENT-MILLIS kv.Key.ToString -> 1479032431144


//		if (www.error != null) {
//			MyLog.I("HttpGet NG: " + www.error);
//		} else if (www.isDone) {
//			// サーバからのレスポンスを表示
//			MyLog.I("HttpGet OK: " + www.text);
//			// HttpGet OK: 
//			// {"entry":{"appId":"95",
//			// "authCode":"GJEJx0hhNa","gamecenterId":"","googleId":"","facebook_id":"105177593297634",
//			// "invitationCode":"EtTe64bt4N","termId":"Tv5ujQDdBU","invitationId":"","userType":"0","status":"0"}}
//
//		}

// user.Initialize("", "", "105177593297634");
// ↓ 200
// FinishApi {"entry":{"appId":"95","authCode":"GJEJx0hhNa","gamecenterId":"",
// "googleId":"","facebook_id":"105177593297634","invitationCode":"EtTe64bt4N","
// termId":"6ui8qsNNzE","invitationId":"","userType":"0","status":"0"}}

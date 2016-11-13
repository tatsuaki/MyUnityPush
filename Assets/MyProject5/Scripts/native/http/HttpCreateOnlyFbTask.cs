using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/** auth無 fbり */
public class HttpCreateOnlyFbTask : HttpBaseTask {
	private const string TAG = "HttpCreateOnlyFbTask";
	// URL
	private const string url = "https://ozef.stg.shall-we-date.com/OZEF/sgp/create/";

	public override void ExecApiTask(MyUser user) {
		MyLog.D(TAG, "ExecApiTask");

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
	public override  IEnumerator requestHttp(string url, Dictionary<string, string> post)
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
		if (status.Equals(CREATE_SUCCESS)) {			
			httpTaskFinishedDelegate(CREATE_SUCCESS, www.text, null);
		} else if (status.Equals("404")){
			httpTaskFinishedDelegate("404", null, null);
			// 		user.Initialize("", "ari", "105177593297634");
		} else if (status.Equals("433")){ // 『指定されたアカウントは登録済みです』 create(FB) 失敗存在しない
			httpTaskFinishedDelegate("433", null, null);
		} else if (status.Equals("MAINTENANCE")){
			httpTaskFinishedDelegate("555", null, null);
		} else {
			httpTaskFinishedDelegate("999",www.text, null);
		}
	} 
}

// 201
// {"entry":{"authCode":"6oP9XqUo7G","termId":"v7nvJdh08H","invitationCode":"J0Z1UgZ6cN"}}
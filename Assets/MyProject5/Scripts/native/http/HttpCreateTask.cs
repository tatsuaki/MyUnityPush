using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/** authCode無 FacebookId無 */
public class HttpCreateTask : HttpBaseTask {
	private const string TAG = "HttpCreateTask";
	// URL
	private const string url = "https://ozef.stg.shall-we-date.com/OZEF/sgp/create/";

	// https://ozef.stg.shall-we-date.com/OZEF/sgp/create/ param 
	// [marketType=2, termId=Tv5ujQDdBU, warningDevice=0]

	// FinishApi {"entry":{"authCode":"XrUb3OLx2","termId":"go7icWGxv","invitationCode":"Ba6QjzDvLs"}}

	public override void ExecApiTask(MyUser user) {
		MyLog.E(TAG, "ExecApiTask");
		// サーバへPOSTするデータを設定 
		Dictionary<string, string> status = user.m_status;
		status.Add ("marketType", "2");
		status.Add ("warningDevice", "0");
		foreach (KeyValuePair<string, string> pair in status)
		{
			MyLog.I(TAG, "param = " + pair.Key + " " + pair.Value);
		}
		StartCoroutine(requestHttp(url, status));
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
		if (status.Equals(CREATE_SUCCESS)) {			
			httpTaskFinishedDelegate(CREATE_SUCCESS, www.text, null);
		} else if (status.Equals("404")){
			httpTaskFinishedDelegate("404", null, null);
		} else if (status.Equals("433")){ // 『指定されたアカウントは登録済みです』 create(FB) 失敗存在しない
			httpTaskFinishedDelegate("433", null, null);
		} else if (status.Equals("MAINTENANCE")){
			httpTaskFinishedDelegate("555", null, null);
		} else {
			httpTaskFinishedDelegate("999",www.text, null);
		}
		// 201 555 それ以外 
	} 
}


// [marketType=2, termId=Tv5ujQDdBU, warningDevice=0]
// ↓
// FinishApi {"entry":{"authCode":"XrUb3OLx2","termId":"go7icWGxv","invitationCode":"Ba6QjzDvLs"}}

// FinishApi {"entry":{"authCode":"GKK6DxCA3y","termId":"TUruXp0THE","invitationCode":"EYuFSFmBS4"}}



// status.Add ("marketType", "2");
// status.Add ("warningDevice", "0");
// status.Add ("termId", "");
// status.Add ("facebookId", "105177593297634");
//  ↓
// get(fbのみ) 200
// FinishApi {"entry":{"appId":"95","authCode":"GJEJx0hhNa","gamecenterId":"","googleId":"",
// "facebook_id":"105177593297634","invitationCode":"EtTe64bt4N","termId":"tU2pjLfqnQ",
// "invitationId":"","userType":"0","status":"0"}}

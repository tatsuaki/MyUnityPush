using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class HttpBaseTask : MonoBehaviour {
	private const string TAG = "HttpBaseTask";
	public delegate void HttpTaskFinishedDelegate(string status, object sender, EventArgs e);
	public static HttpTaskFinishedDelegate httpTaskFinishedDelegate;

	#region ResponseCode
	public const string CREATE_SUCCESS    = "201";  // 作成成功
	public const string GET_SUCCESS       = "200";  // 取得成功
	public const string NO_SUCCESS        = "404";  // 指定されたアカウントは存在しません
	public const string CREATE_SUCCESS_no = "433";	// AlreadyEntry すでに存在します
	public const string MAINTENANCE       = "555";  // メンテナンス
	public const string USER_CANCEL       = "700";  // ユーザーキャンセル
	public const string ERROR             = "999";  // その他異常
	#endregion

	// タイムアウト時間
	protected float timeoutsec = 15f;

	public abstract void ExecApiTask(MyUser user);
	public abstract IEnumerator requestHttp(string url, Dictionary<string, string> post);

	// HTTPリクエストのタイムアウト処理
	protected IEnumerator CheckTimeOut(WWW www, float timeout)
	{
		float requestTime = Time.time;

		while(!www.isDone)
		{
			if(Time.time - requestTime < timeout)
				yield return null;
			else
			{
				MyLog.I(TAG, "TimeOut");  //タイムアウト
				break;
			}
		}
		yield return null;
	}

	public string getStatus(Dictionary<string, string> array) {
		string value = array["STATUS"];
		string[] valueArray = value.Split(' ');
		return valueArray[1];
	}
}

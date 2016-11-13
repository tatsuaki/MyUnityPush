using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyUser : MonoBehaviour {
	private const string TAG = "MyUser";

	public Dictionary<string, string> m_status;

	public void Initialize(string authCode, string termId, string facebookId, string googleId)
	{
		m_status = new Dictionary<string, string>();
		if (null != authCode) {
			m_status.Add("authCode", authCode);
		}
		if (null != termId) {
			m_status.Add("termId", termId);
		}
		if (null != facebookId) {
			m_status.Add("facebookId", facebookId); // レスポンスは facebook_id
		}
		if (null != googleId) {
			m_status.Add("googleId", googleId);
		}
	}

	public void Initialize(string authCode, string termId)
	{
		Initialize(authCode, termId, null, null);
	}

	public void Initialize(string authCode, string termId, string facebookId)
	{
		Initialize(authCode, termId, facebookId, null);
	}

	public void checkValue()
	{
		foreach (string key in m_status.Keys) {
			MyLog.W(TAG, "key = " + key + " value = " + m_status[key]);
		}
	}

    public string GetAppVersionName_Android ()
    {
        AndroidJavaObject   pInfo       = this.GetPackageInfo();
        string versionName = pInfo.Get<string>( "versionName" );
		int versionCode = pInfo.Get<int>( "versionCode" );
		return versionName + " " + versionCode;
    }
	public AndroidJavaObject GetPackageInfo () {
		AndroidJavaClass    unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject   context     = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getApplicationContext");
		AndroidJavaObject   pManager    = context.Call<AndroidJavaObject>("getPackageManager");
		AndroidJavaObject   pInfo       = pManager.Call<AndroidJavaObject>( "getPackageInfo", context.Call<string>("getPackageName"), pManager.GetStatic<int>("GET_ACTIVITIES") );
		return pInfo;
	}
}
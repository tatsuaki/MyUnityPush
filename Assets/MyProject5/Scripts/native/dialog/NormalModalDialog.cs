using UnityEngine;
using System.Collections;

/// <summary>
/// モーダルダイアログ
/// 自分自身以外のダイアログ入力禁止を行います
/// </summary>
public class NormalModalDialog : Dialog 
{	private const string TAG = "NormalModalDialog";
	/// <summary>
	/// 
	/// </summary>
	void Awake () 
	{
		MyLog.I(TAG, "Awake");
		IsUIEnable = false;
		IsGameEnable = true;
	}
}
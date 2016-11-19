using UnityEngine;
using System.Collections;

/// <summary>
/// Swipe 操作
/// </summary>
public class Swipe : MonoBehaviour {
	private const string TAG = "Swipe";

	private Vector3 touchStartPos;
	private Vector3 touchEndPos;
	// private string Direction;

	public float StartPos;
	public float EndPos;

	bool isSelected = false;

	Vector3 start;
	Vector3 after;

	public Camera mainCamera;
	private GameObject player;

	public const float width = 1920.0f;    // 横幅 (目標解像度)
	public const float height = 1080.0f;   // 高さ (目標解像度)
	public int rect;

	bool isForward;

	void Start(){
		// mainCamera = GameObject.Find ("MainCamera").GetComponent<Camera>();
		player = GameObject.Find("Player");
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			isSelected = true;
			Vector3 mousePos = Input.mousePosition;

			if (mousePos.y > (Screen.height / 2)) {
				isForward = true;
			} else {
				isForward = false;
			}
			MyLog.W(TAG, "mousePos x " + mousePos.x + " y " + mousePos.y + " z " + mousePos.z);
			mousePos.z = 1.0f;
			touchStartPos = mainCamera.ScreenToWorldPoint( mousePos ); 
			MyLog.I(TAG, "GetMouseButtonDown");
			MyLog.W(TAG, "ScreenToWorldPoint x " + touchStartPos.x + " y " + touchStartPos.y + " z " + touchStartPos.z);
		}
		if (Input.GetMouseButtonUp (0)) {
			isSelected = false;
			MyLog.I(TAG, "GetMouseButtonUp");
			MyLog.W(TAG, "x " + player.transform.position.x + " y " + player.transform.position.y + " z " + player.transform.position.z);
		}
		if (isSelected) {
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 1.0f;
			touchEndPos = mainCamera.ScreenToWorldPoint( mousePos );

			float result_z = 0;
			if (!isForward) {
				// touchEndPos.z = touchEndPos.z - 2;
				result_z = 2;
			}
			mainCamera.transform.position = new Vector3 (touchEndPos.x, 1, touchEndPos.z - result_z);
			player.transform.position = new Vector3 (touchEndPos.x, 1, touchEndPos.z - result_z);
			// MyLog.W(TAG, "x " + player.transform.position.x + " y " + player.transform.position.y + " z " + player.transform.position.z);
		}
	}
	void Flick(){
//		if (Input.GetKeyDown(KeyCode.Mouse0)){
//			touchStartPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
//    	}
//		if (Input.GetKeyUp(KeyCode.Mouse0)){
//			touchEndPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
//		}
//		GetDirection();
	}

	void GetDirection(){
		float directionX = touchEndPos.x - touchStartPos.x;
		float directionY = touchEndPos.y - touchStartPos.y;

//		if (Mathf.Abs(directionY) < Mathf.Abs(directionX)){
//			if (30 < directionX){
//				//右向きにフリック
//				Direction = "right";
//			} else if (-30 > directionX){
//				//左向きにフリック
//				Direction = "left";
//			}
//		} else if (Mathf.Abs(directionX)<Mathf.Abs(directionY)){
//			if (30 < directionY){
//				//上向きにフリック
//				Direction = "up";
//			}else if (-30 > directionY) {
//				//下向きのフリック
//				Direction = "down";
//			} else {
//				//タッチを検出
//				Direction = "touch";
//			}
		}
//		switch (Direction){
//		case "up": //上フリックされた時の処理
//			break;
//		case "down": //下フリックされた時の処理
//			break;
//		case "right": //右フリックされた時の処理
//			break;
//		case "left":　//左フリックされた時の処理
//			break;
//		case "touch": //タッチされた時の処理
//			break;
//		}
//	}

	public void Awake() {
		float targetAspect;  // 目標のアスペクト比
		float curAspect;     // 補正前の「Scene」のアスペクト比
		float ratio;         // 補正前の「Scene」のアスペクト比 ÷ 目標のアスペクト比

		targetAspect = width / height;
		// 補正前の「Scene」の横幅・縦幅はSceneのメンバ変数から取得可能
		curAspect = Screen.width * 1.0f / Screen.height;  
		ratio = curAspect / targetAspect;
		MyLog.I(TAG, "Screen.width = " + Screen.width + " Screen.height = " + Screen.height);
		// 表示領域の横幅・高さ・左上のXY座標をセット
		// 横長の場合
		if (1.0f > ratio) {
			//			cam.rect.x = 0.0f;
			//			cam.rect.width = 1.0f;
			//			cam.rect.y = (1.0f - ratio) / 2.0f;
			//			cam.rect.height = ratio;
			//			cam.orthographicSize = Screen.width / 2.0f;
		} else { // 縦長の場合
			ratio = 1.0f / ratio;
			//			cam.rect.x = (1.0f - ratio) / 2.0f;
			//			cam.rect.width = ratio;
			//			cam.rect.y = 0.0f;
			//			cam.rect.height = 1.0f;
			//			cam.orthographicSize = Screen.height / 2.0f;
		}
		// camRect = cam.rect;
	}
}
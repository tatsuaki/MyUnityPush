using UnityEngine;
using System.Collections;

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

	void Start(){
		// mainCamera = GameObject.Find ("MainCamera").GetComponent<Camera>();
		// player = GameObject.Find("player").GetComponent();
		player = GameObject.Find("Player");
	}
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			isSelected = true;
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 1.0f;
			touchStartPos = mainCamera.ScreenToWorldPoint( mousePos ); 
			StartPos = touchStartPos.x;
			start = player.transform.position;
			MyLog.I(TAG, "GetMouseButtonDown");
		}
		if (Input.GetMouseButtonUp (0)) {
			isSelected = false;
			bool resilt =  NextConfig.moveType;
//			MyLog.I(TAG, "GetMouseButtonUp");
//			Vector3 mousePos = Input.mousePosition;
//			mousePos.z = 1.0f;
//			touchEndPos = mainCamera.ScreenToWorldPoint( mousePos ); 
//			EndPos = touchEndPos.x;
//			float posi = touchStartPos.x - touchEndPos.x;
//			if (resilt) {
//				mainCamera.transform.position = new Vector3 (touchStartPos.x + posi, touchStartPos.y, 1);
//				player.transform.position = new Vector3 (touchStartPos.x + posi, touchStartPos.y, 1);
//			} else {
//				mainCamera.transform.position = new Vector3 (touchEndPos.x, touchEndPos.y, 1);
//				player.transform.position = new Vector3 (touchEndPos.x, touchEndPos.y, 1);
//			}
//			if (StartPos > EndPos) {
//				mainCamera.transform.position = new Vector3 (touchStartPos.x + posi, touchStartPos.y, 1);
//				player.transform.position = new Vector3 (touchStartPos.x + posi, touchStartPos.y, 1);
//			} else if (StartPos < EndPos) {
//				mainCamera.transform.position = new Vector3 (touchStartPos.x + posi, touchStartPos.y, 1);
//				player.transform.position = new Vector3 (touchStartPos.x + posi, touchStartPos.y, 1);
//			}
			MyLog.W(TAG, "player.transform.position.x " + player.transform.position.x);
			MyLog.W(TAG, "player.transform.position.y " + player.transform.position.y);
			StartPos = 0;
			EndPos = 0;	
		}
		if (isSelected) {
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 1.0f;
			touchEndPos = mainCamera.ScreenToWorldPoint( mousePos ); 
			EndPos = touchEndPos.x;
			float posi = touchStartPos.x - touchEndPos.x;
			mainCamera.transform.position = new Vector3 (touchEndPos.x, 1, touchEndPos.z);
			player.transform.position = new Vector3 (touchEndPos.x, 1, touchEndPos.z);
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
}
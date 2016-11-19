using UnityEngine; 
using System.Collections;

public class Player : MonoBehaviour {

	Vector3 direction; 
	//移動速度 
	public float move_speed = 5f; 
	//回転速度 
	public float rotate_speed = 180f; 
	//ジャンプ速度 
	public float jump_speed = 5f; 
	//重力 
	private float gravity=20f; 
//	//アニメーターコンポーネント 
//	Animator anim; 
//	//キャラコントローラー 
//	CharacterController chara;

	Transform cam_trans; 
	// Use this for initialization 
	void Start () { 
//		chara = GetComponent<CharacterController>(); 
//		anim = GetComponentInChildren<Animator>(); 
		cam_trans = GameObject.Find("MainCamera").GetComponent<Transform>(); 
	}

	// Update is called once per frame 
	void Update () {

//		if (chara.isGrounded) 
//		{
//
//			// direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); 
//			direction = (cam_trans.transform.right * Input.GetAxis("Horizontal")) + 
//				(cam_trans.transform.forward * Input.GetAxis("Vertical"));
//
//			Debug.Log(direction.sqrMagnitude);
//
//			if (direction.sqrMagnitude > 0.1f  && Input.GetAxis("Vertical")==0) 
//			{ 
//				Vector3 forward = Vector3.Slerp(transform.forward, direction, rotate_speed * Time.deltaTime / Vector3.Angle(transform.forward, direction)); 
//				transform.LookAt(transform.position + forward);
//
//			}
//
//			if (Input.GetKeyDown(KeyCode.Space)) 
//			{ 
//				direction.y = jump_speed; 
//			} 
//		}

		direction.y -= gravity * Time.deltaTime;

//		chara.Move(direction * Time.deltaTime * move_speed); 
//		anim.SetFloat("Speed", chara.velocity.magnitude);

		if(Input.touchCount > 0)
		{
			foreach(Touch t in Input.touches)
			{
				if (t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled) {
					Debug.Log("x=" + t.position.x + " y=" +  t.position.y);
				}
			}
		}
	}

} 

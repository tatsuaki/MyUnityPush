using UnityEngine;
using System.Collections;

public class MySoundManager : MonoBehaviour {
	private const string TAG = "MySoundManager";

	//音声ファイル格納用変数
	public AudioClip sound01;
	public AudioClip sound02;

	private AudioSource audioSource;

	void Start() {
		MyLog.I(TAG, "Start");
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	void Update () {
		//指定のキーが押されたら音声ファイルの再生をする
		if(Input.GetKeyDown(KeyCode.K)) {
			GetComponent<AudioSource>().PlayOneShot(sound01);
		}
		if(Input.GetKeyDown(KeyCode.L)) {
			GetComponent<AudioSource>().PlayOneShot(sound02);
		}
	}

	public void playSound1() {
		MyLog.I(TAG, "playSound1");
		audioSource.clip = sound01;
		audioSource.PlayOneShot(sound01);
	}

	public void playSound2() {
		MyLog.I(TAG, "playSound2");
		audioSource.clip = sound02;
		audioSource.PlayOneShot(sound02);
		// GetComponent<AudioSource>().PlayOneShot(sound02);
	}

	private AudioSource getAudioSource() {
		if (null == audioSource) {
			audioSource = gameObject.GetComponent<AudioSource>();
		}
		return audioSource;
	}
}
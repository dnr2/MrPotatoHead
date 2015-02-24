using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	public float timeDelay = 0.5f;
	public int state = 0;
	public string InitialScene;

	private float lastTime;
	
	private RawImage newGame;
	private RawImage exit;
	
	public Texture2D newGame1;
	public Texture2D newGame2;
	public Texture2D exit1;
	public Texture2D exit2;

	// Use this for initialization
	void Start () {
		lastTime = Time.time;
		
		newGame = GameObject.FindGameObjectWithTag("newGameImg").GetComponent <RawImage>();
		exit = GameObject.FindGameObjectWithTag("exitImg").GetComponent <RawImage>();
		newGame.texture = newGame2;
		exit.texture = exit1;
	}
	
	// Update is called once per frame
	void Update () {
	Debug.Log ("State = "+state);
		if ( Input.anyKeyDown && Time.time - lastTime > timeDelay) {
			int previousState = this.state;
			lastTime = Time.time;

			if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z)){
				if( state == 0){		
					Application.LoadLevel(InitialScene);
				}else{	
					Debug.Log( state );
					#if UNITY_EDITOR
						UnityEditor.EditorApplication.isPlaying = false;
					#else
						Application.Quit();
					#endif
				}

			}

			if (Input.GetKey(KeyCode.DownArrow)) {
				if (state < 1) {
					state += 1;
				}else{
					state = 0;
				}
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				if (state > 0) {
					state -= 1;
				}else{
					state = 1;
				}
			}
			
			if(state == 1){
				newGame.texture = newGame1;
				exit.texture = exit2;
			}else{
				newGame.texture = newGame2;
				exit.texture = exit1;
			}
		}
	}
}

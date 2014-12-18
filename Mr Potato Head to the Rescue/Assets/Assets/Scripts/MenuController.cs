using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {



	public float timeDelay = 0.5f;
	public int startState;
	public List<Text> texts;
	public string InitialScene = "PizzaPlanet";

	private int state;
	private int numStates;

	private float lastTime;

	// Use this for initialization
	void Start () {
		state = startState;
		numStates = texts.Count;
		lastTime = Time.time;
		Text text = texts [state];
		text.fontStyle = FontStyle.BoldAndItalic;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.anyKeyDown && Time.time - lastTime > timeDelay) {
			int previousState = this.state;
			lastTime = Time.time;

			if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z)){
				if( state == 0){		
					Application.LoadLevel(InitialScene);
				}
				if( state == 1){		
					Application.LoadLevel(InitialScene);
				}
				if( state == numStates-1){	
					Debug.Log( state );
					#if UNITY_EDITOR
						UnityEditor.EditorApplication.isPlaying = false;
					#else
						Application.Quit();
					#endif
				}

			}

			if (Input.GetKey(KeyCode.DownArrow)) {
					state += 1;
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
					state -= 1;
			}
			if (state < 0) {
					state = 0;
			}
			if (state >= numStates) {
					state = numStates - 1;
			}	
			Text previousText = texts [previousState];
			previousText.fontStyle = FontStyle.Normal;

			Text text = texts [state];
			text.fontStyle = FontStyle.BoldAndItalic;

		}
	}
}

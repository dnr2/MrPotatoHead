#pragma strict

 private var Potato : GameObject;
 public var openTexture : Texture2D;
 public var blinkTexture : Texture2D;
 public var framesPerSecond = 0.5;
 var time : int;
 
function Start () {
	Potato = GameObject.Find("MrPotatoHead/Potato_Low_final");	
	time = Time.time;
}

function Update () {

	if(Time.time > time + 3){
		time = Time.time;
		Potato.renderer.materials[9].mainTexture = blinkTexture;
	}else{
		if(Time.time > time + 0.1){
			Potato.renderer.materials[9].mainTexture = openTexture;
		}
	
	}
	
}
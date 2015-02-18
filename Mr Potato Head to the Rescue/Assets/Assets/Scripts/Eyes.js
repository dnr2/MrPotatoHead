#pragma strict

 public var potatoLowFinal : GameObject;
 public var openTexture : Texture2D;
 public var blinkTexture : Texture2D;
 public var framesPerSecond = 0.5;
 var time : int;
 
function Start () {	
	time = Time.time;
}

function Update () {

	if(Time.time > time + 3){
		time = Time.time;
		potatoLowFinal.renderer.materials[9].mainTexture = blinkTexture;
	}else{
		if(Time.time > time + 0.1){
			potatoLowFinal.renderer.materials[9].mainTexture = openTexture;
		}
	
	}
	
}
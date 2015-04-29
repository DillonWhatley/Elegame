#pragma strict

var crosshair : Texture;

function Start () {

}

function Update () {

}

function OnGUI () {
	GUI.DrawTexture (new Rect(Screen.width/2 - 20, Screen.height/2 - 20, 40, 40), crosshair);
}
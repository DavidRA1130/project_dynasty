/*This must be attached to the Audio listener of a scene(_usually the main camera_)*/
var x = 100;
var y = 100;
var w = 20;
var h = 20;

var vol : float = 0.5;

function Awake(){
	vol = PlayerPrefs.GetFloat("Volume");
	AudioListener.volume = vol;
}

function OnGUI(){
	GUI.Box(Rect(x, y, w, h), " ");	
	//*controls for volume*/
	vol = GUI.HorizontalSlider(Rect(x, (y + 1), w, h), vol, 0.0, 1.0);
	AudioListener.volume = vol;
	PlayerPrefs.SetFloat("Volume", vol);	
}
/*This must be attached to the Audio listener of a scene(_usually the main camera_)*/
var vol : float = 0.5;

function Awake(){
	vol = PlayerPrefs.GetFloat("Volume");
	AudioListener.volume = vol;
}
import UnityEngine.SceneManagement;
//*var that tracks if the game is paused*/
var paused : boolean = false;

var X = 120;
var Y = 90;
var W = 400;
var H = 160;

var guitext : String = "Main Menu";

//var L2L : String = "Main Menu";
var vol : float = 0.5;

function Awake() {
	if(PlayerPrefs.HasKey("Volume") == true){
		vol = PlayerPrefs.GetFloat("Volume");
		AudioListener.volume = vol;
	}
}

function Update () {
	if(Input.GetKeyDown("p" || "P") ){
		paused = !paused;
	}
}

function OnGUI(){
	if(paused == true){
		GUI.color = Color(0.9,0.4,0.6, 1); //changes color *uses Floats from 0.0-1.0 instead of 0-255*
		GUI.Box(Rect( (0.10*Screen.width), (0.10*Screen.height), (0.80*Screen.width), (0.80*Screen.height) ), "PAUSED"); //can display lvl title here

		////////////////////////1st colum of buttons
		if(GUI.Button(Rect( (0.35*Screen.width), (0.35*Screen.height), 75, 33), "Main Menu") ){
			SceneManagement.SceneManager.LoadScene("Main_Menu");
		}
		
		if(GUI.Button(Rect((0.35*Screen.width), (0.5*Screen.height), 75, 33), "Restart") ){
			SceneManagement.SceneManager.LoadScene(Application.loadedLevel);
		}

		////////////////////////2nd colum of buttons
		if(GUI.Button(Rect((0.55*Screen.width), (0.35*Screen.height), 80, 33), "Options") ){
			SceneManagement.SceneManager.LoadScene("Options_Scene");
		}
		
		//*controls for volume*/
		GUI.Box(Rect( (0.55*Screen.width), (0.50*Screen.height), 75, 28), "Volume");
		
		vol = GUI.HorizontalSlider(Rect( (0.55*Screen.width), ((0.55*Screen.height) +5), 80, 37), vol, 0.0, 1.0);
		AudioListener.volume = vol;
		PlayerPrefs.SetFloat("Volume", vol);
	}
}
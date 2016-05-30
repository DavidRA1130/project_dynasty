//Imgs can be "unlocked" using playerpref on awake
//if(haskey "att9")load att9 img into array; 
//possible for loop for making array size

//vars for debugging
var x = 100;
var y = 55;
var wit = 50;
var heit = 20;
var X2:int = 0;

var attCount = 0;
var defCount = 0;
var itemCount = 0;

var attImg0 : Texture;
var attImg1 : Texture;
var attImg2 : Texture;

var defImg0 : Texture;
var defImg1 : Texture;
var defImg2 : Texture;

var itemImg0 : Texture;
var itemImg1 : Texture;
var itemImg2 : Texture;

//var listSize = 5;
var SuperAttList = [attImg0, attImg1, attImg2];
var DefBuffList = [defImg0, defImg1, defImg2];
var ItemList = [itemImg0, itemImg1, itemImg2];
private var position = [410, 484, 554];

function onAwake(){
	/*for(var i=0; i<= 10; i++){ //i<= "?". "?" is the total amount of attack skills a character have and the code will check to see which have been saved for use in the next battle.
		if(PlayerPrefs.GetString("attSkill" + i) == "true"){
			SuperAttList.Add("attImg" + i);
			Debug.Log("i = " + i);
		}
	}*/
}

function Start () {
//can load imgs into the array based on what playpref sava data from upgrade screen
/*DEBUGGIN:*/ //PlayerPrefs.SetInt("KeysInput", 1); PlayerPrefs.SetString("attSkill0","true");
PlayerPrefs.DeleteKey("KeysInput"); //only works if player selected "keyboard" as input method. 
	SuperAttList  = [attImg0, attImg1, attImg2];
	DefBuffList = [defImg0, defImg1, defImg2];
	ItemList = [itemImg0, itemImg1, itemImg2];
}

function Update(){
	if(PlayerPrefs.GetInt("KeysInput") == 1) {
		if(Input.GetKeyUp(KeyCode.LeftArrow) && X2 > 0){X2--; /*code goes here*/}
		if(Input.GetKeyUp(KeyCode.RightArrow) && X2 < (position.Length-1) ){X2++; /*code goes here*/}
	
		if(Input.GetKeyUp(KeyCode.UpArrow) && X2 == 0 && attCount < (SuperAttList.Length - 1)){attCount++; /*code goes here*/}
		if(Input.GetKeyUp(KeyCode.DownArrow) && X2 == 0 && attCount > 0){attCount--; /*code goes here*/}
	
		if(Input.GetKeyUp(KeyCode.UpArrow) && X2 == 1 && defCount < (DefBuffList.Length - 1)){defCount++; /*code goes here*/}
		if(Input.GetKeyUp(KeyCode.DownArrow) && X2 == 1 && defCount > 0){defCount--; /*code goes here*/}
	
		if(Input.GetKeyUp(KeyCode.UpArrow) && X2 == 2 && itemCount < (ItemList.Length - 1)){itemCount++; /*code goes here*/}
		if(Input.GetKeyUp(KeyCode.DownArrow) && X2 == 2 && itemCount > 0){itemCount--; /*code goes here*/}
	}
}

function OnGUI() {
	GUI.color = Color(0,1,1,1);//Change highlight box color to blue then change it back to white for other GUI objects.
	GUI.Button(Rect(position[X2], 423, 50, 50), ".");// this highlighter is for the "keyboard" && "Controler" inputs
	
	if(PlayerPrefs.GetInt("KeysInput") == 1) {
		GUI.Box(Rect( (position[X2]+15), 400, 20, 22), "↑" );//y:402
		GUI.Box(Rect(position[X2]+15, 474, 20, 22), "↓");//y:424
	}
	
	GUI.color = Color.white;
	GUI.Box(Rect(410,423, 50, 50), SuperAttList[attCount]);
	GUI.Box(Rect(484,423, 50, 50), DefBuffList[defCount]);
	GUI.Box(Rect(554,423,50, 50), ItemList[itemCount]);
	
	if(PlayerPrefs.GetInt("MouseInput") == 1){MouseInput();}
	//MouseInput(); //testing
}

function MouseInput(){	
	if (GUI.Button(Rect(410,402,50,20),"Up")){if(attCount < (SuperAttList.Length - 1)){attCount++;} /*code goes here*/}
	if (GUI.Button(Rect(410,474,50,20),"Down")){if(attCount > 0){attCount--;} /*code goes here*/}
	
	if(GUI.Button(Rect(484,402,50,20),"Up")){if(defCount < (DefBuffList.Length - 1)){defCount++;} /*code goes here*/}
	if(GUI.Button(Rect(484,474,50,20),"Down")){if(defCount > 0){defCount--;} /*code goes here*/}
	
	if (GUI.Button(Rect(554,402,50,20),"Up")){if(itemCount < (ItemList.Length - 1)){itemCount++;} /*code goes here*/}
	if (GUI.Button(Rect(554,474,50,20),"Down")){if(itemCount > 0){itemCount--;} /*code goes here*/}
}
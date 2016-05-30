//vars for debugging
var x = 100;
var y = 55;
var wit = 50;
var heit = 20;
var X2:int = 0;

var attCount:int = 0;
var defCount = 0;
var itemCount = 0;
var attImg:Texture;

//elements of the array can be changed later
var SuperAttList = ['0','1','2','3','4','5'];
var DefBuffList = ['0','1','2','3','4','5'];
var ItemList = ['0','1','2','3','4','5'];
var position = [410, 484, 554];//these positions will be changed to be based on the players screen.

function Update(){
	if(Input.GetKeyUp(KeyCode.LeftArrow) && X2 > 0){X2--;}
	if(Input.GetKeyUp(KeyCode.RightArrow) && X2 < (position.Length-1) ){X2++;}
	
	if(Input.GetKeyUp(KeyCode.UpArrow) && X2 == 0 && attCount < (SuperAttList.Length - 1)){ attCount++;/*code goes here*/}
	if(Input.GetKeyUp(KeyCode.DownArrow) && X2 == 0 && attCount > 0){attCount--;/*code goes here*/}
	
	if(Input.GetKeyUp(KeyCode.UpArrow) && X2 == 1 && defCount < (DefBuffList.Length - 1)){defCount++;/*code goes here*/}
	if(Input.GetKeyUp(KeyCode.DownArrow) && X2 == 1 && defCount > 0){defCount--;/*code goes here*/}
	
	if(Input.GetKeyUp(KeyCode.UpArrow) && X2 == 2 && itemCount < (ItemList.Length - 1)){itemCount++;/*code goes here*/}
	if(Input.GetKeyUp(KeyCode.DownArrow) && X2 == 2 && itemCount > 0){itemCount--;/*code goes here*/}
}

function OnGUI() {
	GUI.color = Color(0,0,1,1);//Change highlight box color to blue then change it back to white for other GUI objects.
	GUI.Button(Rect(position[X2], 423, 50, 50), ".");
	GUI.Box(Rect( (position[X2]+15), 400, 20, 22), "↑" );
	GUI.Box(Rect(position[X2]+15, 474, 20, 22), "↓");
	
	GUI.color = Color.white;
	GUI.Box(Rect(410,423, 50, 50), SuperAttList[attCount]);//displays contents of the array
	GUI.Box(Rect(484,423, 50, 50), DefBuffList[defCount]);//displays contents of the array
	GUI.Box(Rect(554,423,50, 50), ItemList[itemCount]);//displays contents of the array
}
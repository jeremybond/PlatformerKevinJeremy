using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	//Adjustable Position's of the Menu's panels
	private float horizontalpos1,horizontalpos2,horizontalpos3,optionspos;
	//
	public AudioClip start;
	public GUIStyle ButtonStyle,closeStyle,simpletext;
 	private bool open,slidestart,slideoptions,slidequit,optionsopen,startgame;
	public Texture optionspanel,closebutton,note,sound;
	private float soundvolume,musicvolume;
	//Background
	bool testtoggle1,testtoggle2,testtoggle3,testtoggle4;
	int quality;
	FadeScript fade;
void Start(){
	//Start Music
	///
	horizontalpos1 = -300;
	horizontalpos2 = -300;
	horizontalpos3 = -300;
		optionspos = 960;
		optionsopen = false;
		OpenMenu();
		quality = 5;
		QualitySettings.SetQualityLevel(5);
		fade = GameObject.Find("MainCube").GetComponent<FadeScript>();
		startgame = false;
	}
	
void FixedUpdate(){
		Music.musicvolume = musicvolume;
		Music.soundvolume = soundvolume;
		if(startgame && fade.alphaFadeValue == 1){
			Debug.Log("OPEN GAME");
			Application.LoadLevel("Game");
		}
		if(quality <= 1)
		{
			quality = 1;
		}
		if(quality >= 5)
		{
			quality = 5;
		}
			
		//Movement Options		
		if(!optionsopen){
			optionspos += 4;
		}
		if(optionspos <= 635){
			optionspos = 635;
		}
		if(optionsopen && optionspos <= 960){
			optionspos -= 4;
		}
		if(optionspos >= 960){
			optionspos = 960;
		}
		///////////////////////
		//Opening Button's Left Side
		if(slidestart && horizontalpos1 <= 0){
		horizontalpos3 += 8f;
		}
		if(slideoptions && horizontalpos1 <= 0){
		horizontalpos2 += 8f;
		}
		if(slidequit && horizontalpos1 <= 0){
		horizontalpos1 += 8f;
		}
		if(horizontalpos1 >= 0){
		horizontalpos1 = 0;	
		slideoptions = true;
		}
		if(horizontalpos2 >= 0){
		horizontalpos2 = 0;	
		slidestart = true;
		}
		if(horizontalpos3 >= 0){
		horizontalpos3 = 0;	
		}
		////
	}
void OpenMenu(){
		slidequit = true;

	}
void  OnGUI (){
		GUI.depth = 2;
		//Scrolling Background Texture's
		////////
		//Start,Options & Quit buttons
		if(GUI.Button (new Rect (horizontalpos3,150,300,100), "Start", ButtonStyle)){
			//START GAME
			fade.fadingOut = true;
			startgame = true;
		}
		if(GUI.Button (new Rect (horizontalpos2,280,300,100), "Options", ButtonStyle)){
			switch(optionsopen){
			case false:
			optionsopen = true;	
			break;
			case true:
			optionsopen = false;	
			break;
			}
			
		}
		if(GUI.Button (new Rect (horizontalpos1,400,300,100), "Quit", ButtonStyle)){
			Application.Quit();
			Music.musicsource.clip = start;
	        Music.musicsource.Play();
		}
		//////////
		
		
		//Options Panel + Sound & Music Icon
		GUI.DrawTexture(new Rect(optionspos,0,200,300),optionspanel);
        GUI.DrawTexture(new Rect(optionspos+ 7,230,50,50),note);
		GUI.DrawTexture(new Rect(optionspos+ 9,190,40,40),sound);
		
		//Close Button on the Option's Panel
       if( GUI.Button(new Rect(optionspos+ 155,8,40,40),"", closeStyle)){
			optionsopen = false;
		
		}
		//
		
		//Quality
		if(GUI.Button(new Rect (optionspos + 140, 150, 40, 20), "+")){
			QualitySettings.IncreaseLevel();
			quality++;
		}
		if(GUI.Button(new Rect (optionspos + 90, 150, 40, 20), "-")){
			quality--;
			QualitySettings.DecreaseLevel();
		}
		///
		
		GUI.Label (new Rect (optionspos + 131, 126, 100, 20),""+ quality,simpletext);
		GUI.Label (new Rect (optionspos + 15, 140, 100, 20), "Quality",simpletext);
		GUI.Label (new Rect (optionspos + 15, 20, 100, 20), "Option1",simpletext);
		GUI.Label (new Rect (optionspos + 15, 60, 100, 20), "Option2",simpletext);
		GUI.Label (new Rect (optionspos + 15, 100, 100, 20), "Option3",simpletext);
		GUI.Label (new Rect (optionspos + 90, 175, 100, 20), "Sound",simpletext);
		GUI.Label (new Rect (optionspos + 90, 235, 100, 20), "Music",simpletext);
		testtoggle1 = GUI.Toggle(new Rect(optionspos + 100,26,30,30),testtoggle1,"");
		testtoggle2 = GUI.Toggle(new Rect(optionspos + 100,66,30,30),testtoggle2,"");
		testtoggle3 = GUI.Toggle(new Rect(optionspos + 100,106,30,30),testtoggle3,"");
		soundvolume  = GUI.HorizontalSlider(new Rect(optionspos+ 50,205,130,50),soundvolume,0,1.0f);
 		musicvolume  = GUI.HorizontalSlider(new Rect(optionspos+ 50,260,130,50),musicvolume,0,1.0f);
         //                             
		
                 
}
}
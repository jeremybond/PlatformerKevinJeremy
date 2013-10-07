using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	public static AudioSource soundsource,musicsource;
	public static float soundvolume,musicvolume;
	public AudioClip intro;
	// Use this for initialization
	void Start () {
	soundsource = GameObject.Find("Sound").GetComponent<AudioSource>();	
	musicsource = GameObject.Find("Music").GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
	musicsource.volume = musicvolume;
	soundsource.volume = soundvolume;
	}
}

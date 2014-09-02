using UnityEngine;
using System.Collections;
public class FadeScript : MonoBehaviour
{
    public Texture2D Fadetexture;
    public bool fadingOut = false;
    public float alphaFadeValue = 0;
    public float fadeSpeed = 1;
 
    // Use this for initialization
    void Start ()
    {
        if (Fadetexture == null) {
       Fadetexture = new Texture2D (1, 0);
       Fadetexture.SetPixel (1, 1, new Color (1, 1, 1, 1));
 
    }
    }
 
    // Update is called once per frame
    void OnGUI ()
    {
		GUI.depth = 1;
       alphaFadeValue = Mathf.Clamp01 (alphaFadeValue + ((Time.deltaTime / fadeSpeed) * (fadingOut ? 1 : -1)));
       if (alphaFadeValue != 0) {
         GUI.color = new Color (1, 1, 1, alphaFadeValue);
         GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), Fadetexture);
       }
    }
 
}
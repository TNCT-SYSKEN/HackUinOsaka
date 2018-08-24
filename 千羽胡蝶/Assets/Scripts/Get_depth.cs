using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_depth : MonoBehaviour {
    public int Width = 1920;
    public int Height = 1080;
    public int FPS = 30;

    private WebCamTexture webCamTexture;
    private Color32[] color32s;

	void Start () {

        //Planeのレンダラー
        Renderer renderer = GetComponent<Renderer>();
        webCamTexture = new WebCamTexture();

        //mainTextureにWebCamTextureを指定する
        renderer.material.mainTexture = webCamTexture;
        webCamTexture.Play();

	}
	
	void Update () {
        color32s = webCamTexture.GetPixels32();

        Texture2D texture = new Texture2D(webCamTexture.width, webCamTexture.height);
        GameObject.Find("Panel").GetComponent<Renderer>().material.mainTexture = texture;

        texture.SetPixels32(color32s);
        texture.Apply();
	}
}

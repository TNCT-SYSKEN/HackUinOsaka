using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_depth : MonoBehaviour {

    private WebCamTexture webCamTexture;

	// Use this for initialization
	void Start () {

        //Planeのレンダラー
        Renderer renderer = GetComponent<Renderer>();
        webCamTexture = new WebCamTexture();

        //mainTextureにWebCamTextureを指定する
        renderer.material.mainTexture = webCamTexture;
        webCamTexture.Play();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

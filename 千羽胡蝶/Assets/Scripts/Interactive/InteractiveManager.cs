using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractiveManager : MonoBehaviour {
    //Triggerを宣言
    public enum InteTrigger {wireworks, sample1};
    public InteTrigger inte;
    public GameObject fire;

    private WebCamTexture webCamTexture;
    private WebcamCodeReader qr_reader;

    // Use this for initialization
    void Start () {
        //Planeのレンダラー
        //Renderer renderer = GetComponent<Renderer>();
        webCamTexture = new WebCamTexture();
        qr_reader = new WebcamCodeReader();
        //mainTextureにWebCamTextureを指定する
        //renderer.material.mainTexture = webCamTexture;
        webCamTexture.Play();
    }
	
	// Update is called once per frame
	void Update () {
        //Triggerを更新
        //string trigger = webcamera.GetComponent<WebcamCodeReader>().Read(webCamTexture);
        if (webCamTexture == null || !webCamTexture.isPlaying) {
            return;
        }
        string trigger = qr_reader.Read(webCamTexture);
        if (trigger == "fireworks") {
            Debug.Log(trigger);
            fire.GetComponent<Fireworks>().make_fireworks();
            /*
            if (trigger == "fireworks")
            {
                fire.GetComponent<Fireworks>().make_fireworks();
            }
            else
            {
            //wireworks以外のオブジェクトの場合else if (trigger == "objectName")で追加
            }
            */
        }
        switch (inte) {
            case InteTrigger.wireworks:
                fire.GetComponent<Fireworks>().make_fireworks();
                break;
            case InteTrigger.sample1:
                //Debug.Log("sample1");
                break;
            default:
                //Debug.Log("End Interactive");
                break;
        }
    }
}

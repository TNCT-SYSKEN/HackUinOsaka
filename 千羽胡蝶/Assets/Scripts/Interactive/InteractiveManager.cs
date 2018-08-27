﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractiveManager : MonoBehaviour {
    //Triggerを宣言
    public enum InteTrigger {wireworks, sample1};
    public InteTrigger inte;
    public GameObject webcamera;
    public GameObject fire;
    private WebCamTexture webCamTexture;

    // Use this for initialization
    void Start () {
        webCamTexture = new WebCamTexture();
    }
	
	// Update is called once per frame
	void Update () {
        //Triggerを更新
        if (webCamTexture == null || !webCamTexture.isPlaying)
        {
            return;
        }
        string trigger = webcamera.GetComponent<WebcamCodeReader>().Read(webCamTexture);
        if (trigger != null)
        {

            if (trigger == "wireworks")
            {
                fire.GetComponent<Fireworks>().make_fireworks();
            }
            else
            {
                //wireworks以外のオブジェクトの場合else if (trigger == "objectName")で追加
            }

            switch (inte)
            {
                case InteTrigger.wireworks:
                    fire.GetComponent<Fireworks>().make_fireworks();
                    break;
                case InteTrigger.sample1:
                    Debug.Log("sample1");
                    break;
                default:
                    Debug.Log("End Interactive");
                    break;
            }
        }
    }
}

using UnityEngine;
using System;

public class Webcamera_Show : MonoBehaviour {
    public GameObject fireworks;
    public int FPS = 30;

    private float mainCameraSize;
    private WebCamTexture webCamTexture;
    private WebcamCodeReader qrReader;

    private string Fireworks_name = "fireworks";
    private string qr_result;

    private float fireTime = 2.55f;
    private float resetCount;

    void Start () {
        //Planeのレンダラー
        //Renderer renderer = GetComponent<Renderer>();
        //mainTextureにWebCamTextureを指定する
        //renderer.material.mainTexture = webCamTexture;

        mainCameraSize = Camera.main.orthographicSize;
        webCamTexture = new WebCamTexture();
        qrReader = new WebcamCodeReader();

        webCamTexture.Play();
	}

    void Update() {
        Debug.Log(resetCount);
        resetCount += Time.deltaTime;
        if (resetCount < fireTime) {
            if (webCamTexture == null || !webCamTexture.isPlaying) {
                return;
            }

            qr_result = qrReader.Read(webCamTexture);

            if (qr_result != null && qr_result != "404") {
                Debug.Log("meu");
                Instantiate(fireworks, new Vector3(UnityEngine.Random.Range(-mainCameraSize, mainCameraSize), UnityEngine.Random.Range(-mainCameraSize, mainCameraSize), 5), new Quaternion(0, -90, 0, 0));
            }

            resetCount += 1f;
        } else if (resetCount > fireTime*2) {
            resetCount = 0f;
        }
    }
}

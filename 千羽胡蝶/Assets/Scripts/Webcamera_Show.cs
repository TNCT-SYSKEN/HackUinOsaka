using UnityEngine;

public class Webcamera_Show : MonoBehaviour {

    public int FPS = 30;

    private WebCamTexture webCamTexture;
    private WebcamCodeReader qr_reader;

	void Start () {
        //Planeのレンダラー
        Renderer renderer = GetComponent<Renderer>();
        webCamTexture = new WebCamTexture();
        
        //mainTextureにWebCamTextureを指定する
        renderer.material.mainTexture = webCamTexture;
        webCamTexture.Play();

        qr_reader = new WebcamCodeReader();
	}

    void Update() {
        if (webCamTexture == null || !webCamTexture.isPlaying) {
            return;
        }
        string qr_result = qr_reader.Read(webCamTexture);
        if (qr_result != null) { 
            Debug.Log(qr_result);
        }
    }
}

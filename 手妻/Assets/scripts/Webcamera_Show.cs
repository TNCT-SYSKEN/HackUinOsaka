using UnityEngine;

public class Webcamera_Show : MonoBehaviour {
    public GameObject fireworksSeed;
    public ParticleSystem fireworksBoombParticle;
    public ParticleSystem fireworksSeedParticle;
    public int FPS = 30;

    private float mainCameraSize;
    private WebCamTexture webCamTexture;
    private WebcamCodeReader qrReader;

    private string Fireworks_name = "fireworks";
    private string qr_result;

    private float fireTime = 2.55f;
    private float resetCount;

    void Start () {
        mainCameraSize = Camera.main.orthographicSize;
        webCamTexture = new WebCamTexture();
        qrReader = new WebcamCodeReader();

        webCamTexture.Play();
	}

    void Update() {
        resetCount += Time.deltaTime;
        if (resetCount < fireTime) {
            if (webCamTexture == null || !webCamTexture.isPlaying) {
                return;
            }

            //花火の種と爆発の色をランダムに指定
            fireworksBoombParticle.startColor = new Color32(
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256)
            );
            fireworksSeedParticle.startColor = new Color32(
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256)
            );

            qr_result = qrReader.Read(webCamTexture);

            if (qr_result != null && qr_result != "404") {
                Instantiate(fireworksSeed, new Vector3(
                    Random.Range(-mainCameraSize, mainCameraSize),
                    Random.Range(-mainCameraSize, mainCameraSize),
                    5
                ),
                new Quaternion(0, -90, 0, 0));
            }

            resetCount += 1f;
        } else if (resetCount > fireTime*2) {
            resetCount = 0f;
        }
    }
}

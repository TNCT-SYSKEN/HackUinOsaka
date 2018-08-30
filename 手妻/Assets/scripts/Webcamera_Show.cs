using UnityEngine;

public class Webcamera_Show : MonoBehaviour {
    public GameObject fireworksSeed;
    [SerializeField]
    public ParticleSystem fireworksSeedParticle;
    [SerializeField]
    public ParticleSystem fireworksBombParticle;
    public int FPS = 30;

    private float mainCameraSize;
    private WebCamTexture webCamTexture;
    private WebcamCodeReader qrReader;

    private string Fireworks_name = "fireworks";
    private string qr_result;

    private float fireTime = 2.55f;
    private float resetCount;

    //花火の種と爆発の色を取得
    /*
    private ParticleSystem.MinMaxGradient FireworksSeedColor {
        get {
            var color = fireworksSeedParticle.main.startColor;
            return color;
        }
        set {
            Color32 color = new Color32(
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256)
            );
        }

    }
    private ParticleSystem.MinMaxGradient FirworksBombColor {
        get {
            var color = fireworksBombParticle.main.startColor;
            return color;
        }
    }
    */

    void Start () {
        mainCameraSize = Camera.main.orthographicSize;
        webCamTexture = new WebCamTexture();
        qrReader = new WebcamCodeReader();

        webCamTexture.Play();
	}

    void Update() {
        resetCount += Time.deltaTime;
        //カウントの値が一定以下の場合に花火の生成処理をする
        if (resetCount < fireTime) {
            if (webCamTexture == null || !webCamTexture.isPlaying) {
                return;
            }

            //花火の種と爆発の色をランダムに指定
            fireworksSeedParticle.startColor = new Color32(
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256),
                (byte)Random.Range(0, 256)
            );
            fireworksBombParticle.startColor = new Color32(
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

using UnityEngine;
using ZXing;

public class WebcamCodeReader {
    private Color32[] flame_data = null;
    private BarcodeReader qr_reader = new BarcodeReader();

    public string Read(WebCamTexture webCamTexture) {
        int width = webCamTexture.width;
        int height = webCamTexture.height;

        if (flame_data == null) {
            flame_data = new Color32[width * height];
        }

        webCamTexture.GetPixels32(flame_data);

        Result result = qr_reader.Decode(flame_data, width, height);

        if (result != null) {
            return result.Text;
        }

        return "404";
    }
}
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
            //result.TextをUnicode(リトルエンディアンのUTF-16)に変換
            byte[] QRTextBytes = System.Text.Encoding.Default.GetBytes(result.Text);
            string QRText = System.Text.Encoding.Unicode.GetString(QRTextBytes);
            
            return QRText;
        }

        return "404";
    }
}
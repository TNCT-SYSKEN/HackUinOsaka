using System;
using UnityEngine;
using ZXing;


public class WebcamCodeReader {
    // フレームの最大分割数
    public int max_split_sqrt = 32;

    private BarcodeReader qr_reader = new BarcodeReader();

    public string Read(WebCamTexture webCamTexture) {

        // テクスチャの分割処理
        // 縦横の分割幅
        for (int split_level=max_split_sqrt; split_level !=1; split_level=split_level/2) {
            int split_width = webCamTexture.width / split_level;
            int split_height = webCamTexture.height / split_level;
            for (int x=0; x < Math.Sqrt(split_level); x++) {
                for (int y=0; y < Math.Sqrt(split_level); y++) {
                    // フレームを分割してColor32に変換
                    Color[] tmp = webCamTexture.GetPixels(x * split_width, y * split_height, split_width, split_height);
                    Color32[] split_frame = new Color32[split_width * split_height];
                    for (int i=0; i<tmp.Length; i++) {
                        split_frame[i] = new Color(tmp[i][0], tmp[i][1], tmp[i][2], tmp[i][3]);
                    }

                    Result result = qr_reader.Decode(split_frame, split_width, split_height);

                    if (result != null) {
                        return result.Text;
                    }
                }
            }
        }
        return null;
    }
}
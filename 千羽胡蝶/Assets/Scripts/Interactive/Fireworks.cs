using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour {

    //プレハブ
    //public GameObject prefab_wireworks;
    //最大の花火の数を設定
    public int MaxObject = 1;
    //打ち上げる花火の座標
    private Vector3 random_posi;
    //打ち上げる花火の角度
    private Vector3 random_rota;
    private Quaternion qua_random_rota;
    private GameObject[] exists_object; //花火の数
    private int count_object;

    public void make_fireworks()
    {
        //現在の花火をカウント
        exists_object = GameObject.FindGameObjectsWithTag("Fireworks");
        count_object = exists_object.Length;

        if (count_object <= MaxObject)
        {
            //ランダムな座標
            random_posi = new Vector3(Random.Range(0, Screen.width), 0, 0);
            //ランダムな回転
            random_rota = new Vector3(0, 0, Random.Range(-30, 30));
            //vec -> qua
            qua_random_rota = Quaternion.Euler(random_rota);
            //花火のインスタンスを生成
            Instantiate(this.gameObject, random_posi, qua_random_rota);
        }
    }   
}
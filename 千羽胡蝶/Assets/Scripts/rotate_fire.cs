using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_fire : MonoBehaviour {
    public int y_rotate;

	void Update () {
        //打ちあがる花火の軸を回転させる
        transform.Rotate(new Vector3(0, y_rotate, 0) * Time.deltaTime, Space.World);
	}
}

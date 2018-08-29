using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldfish : MonoBehaviour {
    public float max_x_grid = 9.78f; //波右の限界値
    public float min_x_grid = -10.2f; //波左の限界値
    public float max_y_grid = -3.83f; //波上の限界値
    public float min_y_grid = -5.02f; //波下の限界値

    public float timeOut = 3.6f;
    public char gold_dir = 'r';
    public float timeElapsed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;
        if(timeElapsed < timeOut){
            if (gold_dir == 'r')
            {
                Vector3 now_pos = this.gameObject.transform.position;
                this.gameObject.transform.position = new Vector3(now_pos.x + 0.05f, now_pos.y, now_pos.z);
            }
            else
            {
                Vector3 now_pos = this.gameObject.transform.position;
                this.gameObject.transform.position = new Vector3(now_pos.x - 0.05f, now_pos.y, now_pos.z);
            }
        }else{
            if(gold_dir == 'r'){
                gold_dir = 'l';
            }else{
                gold_dir = 'r';
            }
            timeElapsed = 0.0f;
        }
	}
}

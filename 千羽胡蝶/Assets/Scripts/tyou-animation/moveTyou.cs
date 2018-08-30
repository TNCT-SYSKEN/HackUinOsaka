using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTyou : MonoBehaviour {
    //public GameObject tyou;
    private GameObject purposeObject;
    public float tyouLerpTime = 60f;
    private Vector3 startPos;
    private Vector3 endPos;
    private float currentLerpTime = 0;
    

	// Use this for initialization
	void Start () {
        purposeObject = GameObject.Find("from(Clone)");
        startPos = this.transform.position;
        endPos = purposeObject.transform.position;

    }

    // Update is called once per frame
    void Update () {
        //flame 
        if (purposeObject != null)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= tyouLerpTime)
            {
                currentLerpTime = tyouLerpTime;
            }
            float Perc = currentLerpTime / tyouLerpTime;
            this.transform.position = Vector3.Slerp(startPos, endPos, Perc);
        }
    }
}

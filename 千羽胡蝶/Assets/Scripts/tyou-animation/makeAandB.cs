using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeAandB : MonoBehaviour {
    public GameObject A;
    public GameObject B;
    private GameObject AIns;
    private GameObject BIns;
    public GameObject mainCamera;
    private float cameraSize;
    private Vector3 aPos;
    private Vector3 bPos;
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 nextPos;
    public float lerpTime = 10;
    public float thirdLerpTime = 15;
    private float currentLerpTime = 0;

    // Use this for initialization
    void Start()
    {
        aPos = Vector3.zero;//new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height),0);
        bPos = new Vector3(10,10,0);

        //camera size
        cameraSize = mainCamera.GetComponent<Camera>().orthographicSize;

        //random make instance
        Instantiate(A,aPos , Quaternion.identity);
        Instantiate(B,bPos , Quaternion.identity);
        
        //get instance object pos
        AIns = GameObject.Find("TYO b_000(Clone)");
        BIns = GameObject.Find("to(Clone)");

        //set startpos endpos
        startPos = AIns.transform.position;
        endPos = BIns.transform.position;
        nextPos = BIns.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        endPos = BIns.transform.position;
        nextPos = GameObject.Find("3rdPurpose").GetComponent<Transform>().position;

        if (AIns != null && BIns != null)
        {
            currentLerpTime += Time.deltaTime;
            if(currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float Perc = currentLerpTime / lerpTime;
            AIns.transform.position = Vector3.Lerp(startPos,endPos, Perc);
        }
        //ターゲットに向かせる
        Vector3 vec = (BIns.transform.position - AIns.transform.position).normalized;
        AIns.transform.rotation = Quaternion.FromToRotation(Vector3.up, vec);

        if (AIns != null && BIns != null)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >=thirdLerpTime)
            {
                currentLerpTime =thirdLerpTime;
            }
            float Perc = currentLerpTime /thirdLerpTime;
            BIns.transform.position = Vector3.Lerp(endPos, nextPos, Perc);
        }
    }

    public void initTyou()
    {
        startPos = endPos;
        lerpTime = 0;
    }

    public void initPurpose()
    {
        GameObject.Find("3rdPurpose").GetComponent<Transform>().position = new Vector3(Random.Range(-cameraSize, cameraSize), Random.Range(-cameraSize, cameraSize), 0);
        thirdLerpTime = 0;
    }
}

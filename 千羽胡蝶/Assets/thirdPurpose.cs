using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPurpose : MonoBehaviour {

    public GameObject purposes;

	void OnTriggerEnter2D(Collider2D col)
    {
        purposes = GameObject.Find("purposes");

        if(col.gameObject.tag == "thirdPurpose")
        {
            purposes.GetComponent<makeAandB>().initPurpose();
        }
    }
}

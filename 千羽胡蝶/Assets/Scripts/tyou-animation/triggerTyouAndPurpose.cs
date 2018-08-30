using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTyouAndPurpose : MonoBehaviour {
    private GameObject purpose;
    private Vector3 purposePos;

    //private GameObject 

    void OnTriggerEnter2D(Collider2D target)
    {

        purpose = GameObject.Find("purposes");
        if (target.tag == "purpose")
        {
            purpose.GetComponent<makeAandB>().initTyou();
        }
    }
}

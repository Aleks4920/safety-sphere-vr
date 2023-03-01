using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    private bool isCut = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chainsaw") { 
            isCut = true;
        }
    }

    public bool GetTreeState() {
        return isCut;
    }
}

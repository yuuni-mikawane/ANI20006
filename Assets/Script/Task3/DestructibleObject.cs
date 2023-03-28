using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public GameObject brokenObject;

    private void OnCollisionEnter(Collision collision)
    {
        if(brokenObject.transform.parent == gameObject.transform)
        {
            brokenObject.transform.parent = null;
        }
        brokenObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

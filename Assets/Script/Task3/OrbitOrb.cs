using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitOrb : MonoBehaviour
{
    public GameObject orb;
    public float speed = 10f;
    private Rigidbody orbRb;

    private void Start()
    {
        orbRb = orb.GetComponent<Rigidbody>();
    }

    public void LaunchAtTarget(Vector3 pos)
    {
        orb.transform.parent = null;
        orbRb.isKinematic = false;
        orbRb.velocity = (pos - orbRb.transform.position).normalized * speed;
    }
}

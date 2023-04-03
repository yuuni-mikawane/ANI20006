using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 10f;
    public GameObject glowOrb;
    public Rigidbody rigid;
    public GameObject explosionFX;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if(rb != null && rb.isKinematic == false && rb.gameObject.layer != 7)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        rigid.velocity = Vector3.zero;
        gameObject.layer = 6;
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveAndApplyVelocity : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 lastFramePos = Vector3.one;
    public Rigidbody rb;
    public bool momentumIsSet = false;
    public Animator animator;
    private Vector3 thisFramePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!momentumIsSet)
        {
            velocity = (transform.position - lastFramePos).normalized * (Vector3.Distance(transform.position, lastFramePos) / Time.fixedDeltaTime);
            lastFramePos = transform.position;
        }
    }

    public void ContinueMomentum()
    {
        momentumIsSet = true;
        thisFramePos = transform.position;
        animator.enabled = false;
        transform.position = thisFramePos;
        rb.isKinematic = false;
        rb.velocity = velocity;
    }
}

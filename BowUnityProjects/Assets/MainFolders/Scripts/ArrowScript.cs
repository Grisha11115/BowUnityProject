using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public TrailRenderer TrailRenderer;
    public GameObject EmptyArrow;


    private EnotScript Enot;
    public GameObject MotherEnot;

    private void Start()
    {
        Enot = MotherEnot.GetComponent<EnotScript>();
        Rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

    }
    public void SetToRope(Transform ropeTransform)
    {
        transform.parent = ropeTransform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        Rigidbody.isKinematic = true;
        TrailRenderer.enabled = false;

    }

    public void Shot(float velocity)
    {
        transform.parent = null;
        Rigidbody.isKinematic = false;
        Rigidbody.velocity = transform.up * velocity;
        TrailRenderer.Clear();
        TrailRenderer.enabled = true;

    }
    

}

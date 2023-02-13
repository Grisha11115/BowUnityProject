using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public TrailRenderer TrailRenderer;
    public GameObject EmptyArrow;

    public float VelocityMult;
    public float AngularVelocityMult;

    private EnotScript Enot;
    public GameObject MotherEnot;

    public GameObject CameraObject;

    private void Start()
    {
        Enot = MotherEnot.GetComponent<EnotScript>();
        Rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 cross = Vector3.Cross(transform.up, Rigidbody.velocity.normalized);
        Rigidbody.AddTorque(cross * Rigidbody.velocity.magnitude * VelocityMult);
        Rigidbody.AddTorque((-Rigidbody.angularVelocity + Vector3.Project(Rigidbody.angularVelocity, transform.up)) * Rigidbody.velocity.magnitude * AngularVelocityMult);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    [SerializeField] private GameObject EmptyArrow;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        { 
            Vector3 ArrowPos = collision.contacts[0].point;
            Instantiate(EmptyArrow, ArrowPos, collision.transform.rotation);
            collision.gameObject.SetActive(false);
        }
    }
}

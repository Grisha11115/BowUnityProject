using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    [SerializeField] private GameObject EmptyArrow;
    public GameObject Arrow;
    private ArrowScript ArrowScript;
    // Start is called before the first frame update
    void Start()
    {
        ArrowScript = Arrow.GetComponent<ArrowScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Vector3 ArrowPos = collision.contacts[0].point;
            Instantiate(EmptyArrow, ArrowPos, Arrow.transform.rotation);
            collision.gameObject.SetActive(false);
        }
    }
}

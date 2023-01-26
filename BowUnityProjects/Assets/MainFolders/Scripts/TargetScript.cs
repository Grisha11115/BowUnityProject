using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private GameObject EmptyArrow;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Vector3 ArrowPos = collision.contacts[0].point;
            Instantiate(EmptyArrow, ArrowPos, collision.transform.rotation);
            collision.gameObject.SetActive(false);

            
            float posX = Random.Range(-10, 25);
            float posZ = Random.Range(-25, 5);
            Vector3 newPos = new Vector3(posX, 1, posZ);
            Instantiate(this.gameObject, newPos, Quaternion.identity);
            
        }    
    }


}

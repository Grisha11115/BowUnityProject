using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void Relocate()
    {
        float posX = Random.Range(-10, 25);
        float posZ = Random.Range(-25, 5);

        Vector3 newPos = new Vector3(posX, 1, posZ);
        transform.position = newPos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Relocate();
        }

    }


}

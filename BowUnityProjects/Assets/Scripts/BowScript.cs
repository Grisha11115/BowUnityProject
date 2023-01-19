using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    public Vector3 threadFarPos;
    public Vector3 threadNearPos;

    public float _tension = 0f;
    public Transform _thread;
    private bool _pressed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // _pressed = true;
           // if (_pressed)
           // {
                if (_tension <= 1)
                {
                    _tension += Time.deltaTime * 5;
                }
                if (_tension > 1)
                {
                    _tension = 0f;
                }
                _thread.localPosition = Vector3.Lerp(threadNearPos, threadFarPos, _tension);


           // }
        }
        if (Input.GetMouseButtonUp(0))
        {
        //   _pressed = false;
            _tension = 0f;
        }
    }


}


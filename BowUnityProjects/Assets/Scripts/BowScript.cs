using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    public float _tension = 0;
    public GameObject Arrow;
    public float ArrowSpeed = 20f;

    public Transform _thread;
    private bool _pressed = false;
    public Vector3 threadNearPos;
    public Vector3 threadFarPos;

    public AnimationCurve threadReturnAnimation;
    private ArrowScript CurrentArrow;

    void Start()
    {
        CurrentArrow = Arrow.GetComponent<ArrowScript>();
    }

    void Update()
    {
        shot();
    }
    void shot()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Arrow.SetActive(true);
            _pressed = true;
            CurrentArrow.SetToRope(_thread);
        }


        if (Input.GetKeyUp(KeyCode.Q))
        {
            _pressed = false;
            _tension = 0;
            StartCoroutine(RopeReturn());
            CurrentArrow.Shot(ArrowSpeed);

        }
        if (_pressed)
        {
            if (_tension < 1f)
            {
                _tension += Time.deltaTime;
            }
            _thread.localPosition = Vector3.Lerp(threadNearPos, threadFarPos, _tension);
        }

        IEnumerator RopeReturn()
        {
            Vector3 StartNewPos = _thread.localPosition;
            for (float f = 0; f < 1f; f += Time.deltaTime)
            {
                _thread.localPosition = Vector3.LerpUnclamped(StartNewPos, threadNearPos, threadReturnAnimation.Evaluate(f));
                yield return null;
            }
        }
    }
}
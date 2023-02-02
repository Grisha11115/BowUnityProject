using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BowScript : MonoBehaviour
{

    public float _tension = 0;
    public GameObject Arrow;
    public float ArrowSpeed = 20f;
    public int ArrowIndex = 0;

    public Transform _thread;
    private bool _pressed = false;
    public Vector3 threadNearPos;
    public Vector3 threadFarPos;

    public AnimationCurve threadReturnAnimation;
    public ArrowScript CurrentArrow;

    public ArrowScript[] ArrowPool;

    public Camera Cam;
    private int MaxFieldOfView = 50;


    void Start()
    {
        CurrentArrow = Arrow.GetComponent<ArrowScript>();
    }


    void Update()
    {
        if (Cam.fieldOfView <= MaxFieldOfView)
        {
            Cam.fieldOfView = 50;
        }
        shot();
    }
    void shot()
    {
        if (_pressed)
        {
            if (_tension < 1f)
            {
                _tension += Time.deltaTime;
            }
            _thread.localPosition = Vector3.Lerp(threadNearPos, threadFarPos, _tension);
            Cam.fieldOfView -= 10 * _tension;

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (ArrowIndex >= ArrowPool.Length)
            {
                ArrowIndex = 0;
            }
            CurrentArrow = ArrowPool[ArrowIndex];
            CurrentArrow.gameObject.SetActive(true);
            ArrowIndex++;

            _pressed = true;
            CurrentArrow.SetToRope(_thread);
        }


        if (Input.GetKeyUp(KeyCode.Q))
        {
            Cam.fieldOfView += 10 * _tension;
            StartCoroutine(RopeReturn());
            CurrentArrow.Shot(ArrowSpeed * _tension);
            _pressed = false;
            _tension = 0f;

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
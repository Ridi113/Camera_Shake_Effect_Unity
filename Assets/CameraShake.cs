using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    Transform camTrans;
    public float shakeTime;
    public float shakeRange;
    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        camTrans = this.transform;    // Camera.main.transform  if the script is attached to other components
        originalPosition = camTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShakeCamera());
        }
    }

    IEnumerator ShakeCamera()
    {
        float elapsedTime = 0; //  when this  value is greater than shakeTime, then we stop  this Coroutine

        while(elapsedTime < shakeTime)
        {
            Vector3 pos = originalPosition + UnityEngine.Random.insideUnitSphere * shakeRange;
            //camTrans.position = originalPosition + UnityEngine.Random.insideUnitSphere * shakeRange;

            pos.z = originalPosition.z;

            camTrans.position = pos;
            
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        camTrans.position = originalPosition;
    }
}

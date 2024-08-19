using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform followTransform;

    void Update()
    {
        if(followTransform != null)
        {
            Vector3 newPosition = followTransform.position;
            newPosition.z = transform.position.z;

            transform.position = newPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public float FollowSpeed = 4f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
       UnityEngine.Vector3 newPos = new UnityEngine.Vector3(target.position.x,target.position.y,-10f);
        transform.position = UnityEngine.Vector3.Slerp(transform.position,newPos, FollowSpeed*Time.deltaTime*60);
    }
}

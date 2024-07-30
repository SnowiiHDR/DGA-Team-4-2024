using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
    
{
    public float speed;
    public int startingpoint;
    public Transform[] points;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingpoint].position; ///Start from the left point
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[index].position, speed * (Time.deltaTime));

        if (Vector2.Distance(transform.position, points[index].position) < 0.02f) /// If close to a point. Switch to the next point in the list.
        {
            index = index + 1;
            if (index == 1){
                index = 0;
                    }
        
        }
    }
}

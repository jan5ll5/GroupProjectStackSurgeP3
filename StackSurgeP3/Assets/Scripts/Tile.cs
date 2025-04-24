using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    float distance;
    float maxDistance;
    float stepLength;
    bool moveForward;
    bool moveX;
    // Start is called before the first frame update
    void Start()
    {
        maxDistance = 5.0f;
        distance = maxDistance;
        moveForward = false;
        if (moveX)
        {
            transform.Translate(distance, 0, 0):
        }

        else
        {
            transform.Translate(0, 0, distance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        stepLength = Time.deltaTime * 6.0f;
        if (moveX)
        {
            MoveX();
        }
        else
        {
            MoveZ();
        }
    }

    void MoveX()
    {
        if (moveForward)
        {
            if(distamc)
        }
    }

    void MoveZ()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube {  get; private set; }
    public static MovingCube LastCube {  get; private set; }

    [SerializeField]
    private float moveSpeed = 2f;

    private void OnEnable()
    {
        if(LastCube == null)
        {
            LastCube = GameObject.Find("Start").GetComponent<MovingCube>();
        }

        CurrentCube = this;
    }

    internal void Stop()
    {
        moveSpeed = 0f;
        float hangover = transform.position.z - LastCube.transform.position.z;
        Debug.Log(hangover);

        SplitCubeOnZ(hangover);
    }

    private void SplitCubeOnZ(float hangover)
    {
        float newZSize = LastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newZSize;

        float newZPosition = LastCube.transform.position.z + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

        float cubeEdge = transform.position.z + (newZSize / 2f);
        float fallingBlockZPosition = cubeEdge + fallingBlockSize / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
}

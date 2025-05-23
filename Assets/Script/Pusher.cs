using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 starPosition;
    public float amplitude;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        starPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float z = amplitude * Mathf.Sin(Time.time * speed);
        transform.localPosition = starPosition + new Vector3(0, 0, z);
    }
}

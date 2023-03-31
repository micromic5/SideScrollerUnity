using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offset;

    void Start()
    {
        offset = gameObject.transform.position - target.position;
    }

    void Update()
    {
        gameObject.transform.position = target.position + offset;
    }
}

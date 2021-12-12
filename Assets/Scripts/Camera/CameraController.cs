using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    [SerializeField] private float xMaxPos;
    [SerializeField] private float xMinPos;
    [SerializeField] private float yMaxPos;
    [SerializeField] private float yMinPos;

    [SerializeField] private float xMaxOffset;
    [SerializeField] private float yMaxOffset;

    private void Start()
    {
        transform.position = new Vector3(xMaxPos, yMinPos, -10f);
    }

    private void Update()
    {
        Vector3 position = transform.position;
        Vector3 targetPosition = target.transform.position;
        Vector3 distance = targetPosition - position;
        Vector3 absoluteDistance = new Vector3(Mathf.Abs(distance.x), Mathf.Abs(distance.y), 0f);
        Vector3 newPosition = Vector3.one;
        newPosition.z = -10f;
        newPosition.x = targetPosition.x - Math.Sign(distance.x) * ((absoluteDistance.x > xMaxOffset) ? xMaxOffset : absoluteDistance.x);
        newPosition.y = targetPosition.y - Math.Sign(distance.y) * ((absoluteDistance.y > yMaxOffset) ? yMaxOffset : absoluteDistance.y);
        
        
        transform.position = newPosition;
    }
}

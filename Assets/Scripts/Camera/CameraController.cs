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
        if(Mathf.Abs(distance.x)<xMaxOffset && Mathf.Abs(distance.y)<yMaxOffset) return;

        Vector3 newPosition = position;
        newPosition.x = (Mathf.Abs(distance.x) >= xMaxOffset) ? (targetPosition.x-xMaxOffset*Mathf.Sign(distance.x)) : position.x ;
        newPosition.y = (Mathf.Abs(distance.y) >= yMaxOffset) ? (targetPosition.y-yMaxOffset*Mathf.Sign(distance.y)) : position.y ;

        if (newPosition.x > xMaxPos) newPosition.x = xMaxPos;
        if (newPosition.x < xMinPos) newPosition.x = xMinPos;
        if (newPosition.y > yMaxPos) newPosition.y = yMaxPos;
        if (newPosition.y < yMinPos) newPosition.y = yMinPos;
        transform.position = newPosition;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera Camera2Follow;
    public float CameraDistance = 3.0F; //거리
    public float smoothTime = 0.3F;     //부드럽기 정도
    private Vector3 velocity = Vector3.zero;
    private Transform target = null;

    private void Awake()
    { 
        target = Camera2Follow.transform;
    }
                                                        //플레이어의 시선, 거리에 맞춰 오브젝트 이동

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, CameraDistance));

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        transform.LookAt(transform.position + Camera2Follow.transform.rotation * Vector3.forward, Camera2Follow.transform.rotation * Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 35 * Time.deltaTime);
    }
}

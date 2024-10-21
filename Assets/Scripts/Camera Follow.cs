using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float yOffset = 1.0f;
    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (target == null) return;
        Vector3 position = new Vector3(target.position.x, target.position.y + yOffset, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, position, speed * Time.deltaTime);
    }
}

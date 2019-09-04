using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed;

    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        if (bounds)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
    public void SetMinCamPos()
    {
        minCameraPos = gameObject.transform.position;
    }
    public void SetMaxCamPos()
    {
        maxCameraPos = gameObject.transform.position;
    }
}

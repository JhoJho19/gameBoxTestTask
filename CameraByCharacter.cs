using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Put this script to the Main Camera to chase any object you want.
/// </summary>
public class CameraByCharacter : MonoBehaviour
{
    [SerializeField] private Transform target; // Object to chase.
    [SerializeField] private float smoothSpeed = 0.125f; // Movement delay.
    [SerializeField] private Vector3 offset; // Adjusting the camera position in relation to the anchor object

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = transform.position.y; // Vertical faxing.
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
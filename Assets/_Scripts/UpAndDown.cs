using Merges;
using UnityEngine;

/// <summary>
/// This scrit can smoothly move 2D-object by the Y-axis.
/// </summary>
public class UpAndDown : MonoBehaviour
{
    [SerializeField] private GameObject thisGameObject;
    [SerializeField] private float moveDistance = 0.3f; // Distance for movement.
    [SerializeField] private float moveSpeed = 1f; // Speed of movement.
    public bool isAnimationOn; // Flag for on/off animation from other scripts.

    private float startY;

    private void Start()
    {
        // Get start position of button.
        startY = thisGameObject.transform.position.y;
    }

    private void Update()
    {
        if(isAnimationOn)
        {
            // Set new position of button
            float newPosition = startY + (moveDistance * Mathf.Sin(Time.time * moveSpeed));

            // Go to new position
            thisGameObject.transform.position = new Vector3(thisGameObject.transform.position.x, newPosition, gameObject.transform.position.z);
        }
    }
}

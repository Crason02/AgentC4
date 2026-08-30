using UnityEngine;

public class RowScript : MonoBehaviour
{
    public Transform player;
    public Transform goal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get flat (horizontal) direction to goal, ignoring height
    Vector3 direction = goal.position - player.position;
    direction.y = 0f;

    // Get the world-space angle to the goal
    float angleToGoal = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

    // Subtract player's Y rotation to make it relative to where they're facing
    float relativeAngle = angleToGoal - player.eulerAngles.y;

    // Apply to arrow (rotating on Z axis for a 2D arrow UI)
    transform.rotation = Quaternion.Euler(0f, 0f, -relativeAngle);
    }
}

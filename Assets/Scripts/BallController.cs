using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallControl : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
        Debug.Log($"Ball Speed: {rig.velocity}");
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 0);
    }
    public void ActivateSpeedUp(float speed)
    {
        rig.velocity *= speed;
        Debug.Log($"Ball Speed after SpeedUp: {rig.velocity}");
    }
}

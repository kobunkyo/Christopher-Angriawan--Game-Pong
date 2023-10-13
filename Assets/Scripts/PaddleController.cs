using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int defaultSpeed;
    public KeyCode upKey;
    public KeyCode downKey;
    public String kalimat;
    private float multiple;
    private bool speedPaddle = false;
    private bool lengthPaddle = false;
    private float timer;
    private Rigidbody2D rig;
    private float defaultX;
    private float defaultY;
    private float defaultZ;


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Debug.Log($"transform.y {rig.transform.localScale.y}");
        defaultX = rig.transform.localScale.x;
        defaultY = rig.transform.localScale.y;
        defaultZ = rig.transform.localScale.z;

        multiple = defaultSpeed;
    }

    public void Update()
    {
        if(multiple == defaultSpeed)
        {
            Debug.Log("Normal!");
            MoveObject(GetInput());
            Debug.Log($"Velocity: {rig.velocity}");
        }
        else
        {
            timer += Time.deltaTime;
            Debug.Log("Getting Power Up!");
            // Debug.Log($"Time: {timer}");
            if(timer >= 5)
            {
                Debug.Log("Back to default");
                multiple = defaultSpeed;
                speedPaddle = false;
                lengthPaddle = false;
                rig.transform.localScale = new Vector3(defaultX, defaultY, defaultZ);
                timer = 0;
            }else
            {
                if(speedPaddle)
                {
                    Debug.Log("Speed Up");
                    MoveObject(GetInput()*multiple);
                }
                if(lengthPaddle)
                {
                    Debug.Log("Length Up");
                    rig.transform.localScale = new Vector3(defaultX, multiple, defaultZ);
                    MoveObject(GetInput());
                }
            }

            
        }
        
    }
    private Vector2 GetInput()
    {
        
        if (Input.GetKey(upKey))
        {
            //atas
           return Vector2.up * defaultSpeed;
        }
        else if(Input.GetKey(downKey))
        {
            // bawah
           return Vector2.down * defaultSpeed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        rig.velocity = movement;
        // Debug.Log($"Paddle Speed: {rig.velocity}");
    }

    public void ActivatePaddleSpeed(float speedUp)
    {
        multiple = speedUp * defaultSpeed;
        speedPaddle = true;
        Debug.Log($"Paddle Speed Up: {multiple}\n{kalimat}");
    }

    public void ActivatePaddleLength(float lengthUp)
    {
        multiple = defaultY * lengthUp;
        lengthPaddle = true;
        Debug.Log($"Length UP by {lengthUp}");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float moveX;
    public float moveY;
    public float speed = 20f;
    public int rotationDegrees = 20;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rig.velocity = new Vector2(moveX * speed, moveY * speed);

        // ASIX Y
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            FlipZ(rotationDegrees);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FlipZ(-rotationDegrees);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            FlipZ(0);
        }

    }

    void FlipZ(int degrees) 
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * degrees);
    }
}

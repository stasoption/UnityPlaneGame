using UnityEngine;
using System.Collections;

public class heroScript : MonoBehaviour {
    public float speed = 10f;

    bool facingRight = true;

    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    float posX, posY;
    public int score = 0;
    Rigidbody2D rig;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        posX = rig.position.x;
        posY = rig.position.y;

	}
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        float move;
        move = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(move * speed, rig.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            rig.AddForce(new Vector2(0, 500f));
        }

        if ((move < 0) && facingRight)
            Flip();
        else if ((move > 0) && !facingRight)
            Flip();
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //If collided object is block
        if (col.GetComponent<PolygonCollider2D>().tag == "star")
        {
            Destroy(col.gameObject);
            score++;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            rig.position = new Vector2(posX, posY);

        }
        if (col.gameObject.tag == "endLevel")
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }



    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 100), "Score = " + score);
    }
}

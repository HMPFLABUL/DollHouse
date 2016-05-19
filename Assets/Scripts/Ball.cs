using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Rigidbody2D rb;
    //private CircleCollider2D box;
    private float sign = 1;
    private float xsign =1;
    // Use this for initialization
    void Start () {
        
        rb = GetComponent<Rigidbody2D>();
        sign = (Random.Range(0, 2) - 0.5f) * 2f;
        xsign = (Random.Range(0, 2) - 0.5f) * 2f;
        transform.position=new Vector2(sign*9.5f,Random.Range(-2.85f,4.35f));
        rb.AddForce(new Vector2(-sign*120, xsign*120));
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0f, 0f, sign*5));
        if (transform.position.y > 5f && rb.velocity.y > 0)
            Redirect();
        if (transform.position.y < -2.85f && rb.velocity.y < 0)
            Redirect();
        if (Mathf.Abs(transform.position.x) > 15)
            Destroy(gameObject);


    }
    void Redirect()
    {
        rb.velocity = Vector2.zero;
        xsign = -xsign;
        rb.AddForce(new Vector2(-sign * 120, xsign * 120));
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "PlayerInAction")
        {
            Destroy(gameObject);
        }
    }
}

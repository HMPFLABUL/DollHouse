using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float sign=1;
    private float h=-1.2f;
    public GameObject w1;
    public GameObject w2;
    // Use this for initialization
    void Start () {
        w1.SetActive(true);
        w2.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        sign = (Random.Range(0, 2) - 0.5f) * 2f;
        sprite = GetComponent<SpriteRenderer>();
        // Debug.Log(sign);
        
        transform.position = new Vector3(sign*13f, Random.Range(0, 4)* 1.8f +h, 0f);
        if(sign==1)
            sprite.flipX = true;
       
        //transform.rotation = Quaternion.Euler(new Vector3(0f,180f,0f)) ;
        Invoke("Wait", 1f);
        //rb.AddForce(new Vector2(-sign*300, 0));
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(new Vector2(-sign * 0.5f, 0));
        //if (transform.position.x > Mathf.Abs(5.9f))
        //{
        //    rb.AddForce(new Vector2(-sign*1, 15));
        //}
        if (Mathf.Abs(transform.position.x) > 15)
            Destroy(gameObject);
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            if (Mathf.Abs(transform.position.x) > 6.4f)
            {
                transform.Rotate(new Vector3(0f, 0f, -sign*3.5f));
                rb.AddForce(new Vector2(-sign * 10, 100));
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "PlayerInAction")
        {
            Destroy(gameObject);
        }
    }

    void Wait()
    {
        rb.isKinematic = false;
        rb.AddForce(new Vector2(-sign * 300, 0));
    }
}

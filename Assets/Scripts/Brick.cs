using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    private bool moving = true;
    private float rotateSpeed = 4f;
    public GameObject warrrning;
	// Use this for initialization
	void Start () {
        warrrning.SetActive(true); 
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        transform.position = new Vector3(Random.Range(-7.5f,7.5f), 6.5f, 0f);
        //rb.AddForce(new Vector2(0, -90));
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(moving)
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed));
        if (transform.position.y < -5.5)
            Destroy(gameObject);
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            moving = false;
            StartCoroutine(Wait(col));
        }
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "PlayerInAction")
        {
            Destroy(gameObject);
        }


    }


    IEnumerator Wait(Collision2D col)
    {
        rotateSpeed = -rotateSpeed;
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(box, col.collider, true);
        //box.enabled = false;
        moving = true;
        StartCoroutine(Wait2(col));
    }
    IEnumerator Wait2(Collision2D col)
    {
        yield return new WaitForSeconds(1.2f);
        Physics2D.IgnoreCollision(box, col.collider, false);
        //box.enabled = true;
    }

}

using UnityEngine;
using System.Collections;

public class boost : MonoBehaviour
{
    // Use this for initialization
    private int floor = 0;
    void Start()
    {
        Reposition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player"|| col.tag == "PlayerInAction")
        {
           Reposition();
        }
    }

    void Reposition()
    {
        float posY;
        float posX = Random.Range(-7.75f,7.75f);
        int x = floor;
        while (x == floor)
        {
            x = (int)Random.Range(0f,4f);
            Debug.Log(x);
        }
        floor = x;
        posY = floor * 1.8f - 1.9f;
        transform.position = new Vector2(posX, posY);
        
    }
}

using UnityEngine;
using System.Collections;

public class HPsys : MonoBehaviour {

    public GameObject FHbuff;
    public GameObject EHbuff;
    private static GameObject fullHeart;
    private static GameObject emptyHeart;
    private static int actualHP = 3;
   /* public int ActualHP
    {
        get { return actualHP; }
        set { actualHP = value; }

    }*/
    
    private static GameObject[] hearts;
    // Use this for initialization
    void Start() {
        actualHP = 3;
        fullHeart = FHbuff;
        emptyHeart = EHbuff;
        hearts = new GameObject[9];
        Fill();
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    private static void Fill()
    {
        for (int i = 0; i < actualHP; i++)
        {
            Destroy(hearts[i]);
            
            hearts[i] = Instantiate(fullHeart, new Vector2(-3.3f + 0.8f * i, -4f), Quaternion.identity) as GameObject;
        }
        for (int i = actualHP; i < hearts.Length; i++)
        {
            Destroy(hearts[i]);
            
            hearts[i] = Instantiate(emptyHeart, new Vector2(-3.3f + 0.8f * i, -4f), Quaternion.identity) as GameObject;
        }


    }

    public static void addHP(int x)
    {
        actualHP += x;
        if (actualHP > 9)
            actualHP = 9;
        if (actualHP <= 0)
        {
            actualHP = 0;
            Debug.Log("Gameover");
            Player.gameover = true;
        }
       
        //hearts = new GameObject[9];
        Fill();
    }
}

using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

    // Use this for initialization
    //TEST
    
    public static float test_czas;
    public float czasBuf;
    //private bool test_bool = true;
    [SerializeField]
    private GameObject[] test_objs;

    public static bool nextLvl;
    //private Vector3 test_V3 = new Vector3(-7.5f, -4f, 0f); 

	void Start () {
        nextLvl = false;
        //test_czas = 2f;
        /////// StartCoroutine(SpawnNextObj(test_czas, test_bool, test_objs));
        test_czas = czasBuf;
        InvokeRepeating("SpawnNextObj", 3, test_czas);


    }
	
	// Update is called once per frame
	void Update () {
        if (nextLvl)
        {
            Reinvoke();
            nextLvl = false;
        }
    }
   //// void SpawnTest()
   // {
   //         StartCoroutine(SpawnNextObj(test_czas, test_bool, test_obj, test_V3));
                   
   // }StartCoroutine(SpawnNextObj(test_czas, test_bool, test_obj, test_V3));


    void SpawnNextObj()
    {
       // while (slacz)
        //{

            //Debug.Log(Random.Range(0, obj.Length));
            //pos += new Vector3(1f, 0f, 0f);
            //yield return new WaitForSeconds(czas);
            Instantiate(test_objs[(Random.Range(0, test_objs.Length))], Vector3.zero, Quaternion.identity);
       // }
    }

    public void Reinvoke()
    {
        CancelInvoke("SpawnNextObj");
        InvokeRepeating("SpawnNextObj", 0, test_czas);
    }

    /*  private IEnumerator SpawnNextObj(float czas,bool slacz, GameObject[] obj)
      {
          while (slacz)
          {

              //Debug.Log(Random.Range(0, obj.Length));
              //pos += new Vector3(1f, 0f, 0f);
              yield return new WaitForSeconds(czas);
              Instantiate(obj[(Random.Range(0, obj.Length))], Vector3.zero, Quaternion.identity);
          }
      }*/

}

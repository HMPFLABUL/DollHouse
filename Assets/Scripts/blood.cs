using UnityEngine;
using System.Collections;

public class blood : MonoBehaviour {

	// Use this for initialization
	//void OnAwake() {
        //Invoke("Deactive", 1f);
	//}
	
	// Update is called once per frame
	void Update () {
        //Invoke("Deactive", 1f);
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}

using UnityEngine;
using System.Collections;

public class warrning : MonoBehaviour {
    private Vector2 pos;
    private Quaternion rot;
    // Use this for initialization
    void Start () {
        Invoke("DestroyGO", 1);
        pos = transform.position;
        rot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = pos;
        transform.rotation = rot;
	}
    void DestroyGO()
    {
        Destroy(gameObject);
    }
}

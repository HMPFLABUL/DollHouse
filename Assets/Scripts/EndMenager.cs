using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenager : MonoBehaviour {

    public Text YS;
    public Text HS;

    // Use this for initialization
    void Start () {
	YS.text = ""+PlayerPrefs.GetInt("YourScore");
    HS.text = ""+PlayerPrefs.GetInt("HighScore");

    }

    public void Restart()
    {
       // HPsys.addHP(3);
        SceneManager.LoadScene("Main");
    }
    public void MENUB()
    {
        // HPsys.addHP(3);
        SceneManager.LoadScene("MENU");
    }


}

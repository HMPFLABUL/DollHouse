using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMenager : MonoBehaviour
{

   // public Text YS;
    public Text HS;

    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.SetInt("HighScore", 0);
      //  YS.text = "" + PlayerPrefs.GetInt("YourScore");
        HS.text = "Best Score: " + PlayerPrefs.GetInt("HighScore");

    }

    public void Play()
    {
        // HPsys.addHP(3);
        SceneManager.LoadScene("Main");
    }


}

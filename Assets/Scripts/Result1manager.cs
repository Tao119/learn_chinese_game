using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result1manager : MonoBehaviour
{
    public Text pointText;
    // Start is called before the first frame update
    void Start()
    {
        pointText.text = Game1Manager.point.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void retry()
    {
        SceneManager.LoadScene("Game1");
    }
    public void backButton()
    {
        SceneManager.LoadScene("Home");
    }
}

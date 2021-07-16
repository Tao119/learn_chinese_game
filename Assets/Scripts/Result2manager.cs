using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result2manager : MonoBehaviour
{
    public Text pointText;
    // Start is called before the first frame update
    void Start()
    {
        pointText.text = Game2Manager.point.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void retry()
    {
        SceneManager.LoadScene("Game2");
    }
    public void backButton()
    {
        SceneManager.LoadScene("Home");
    }
}

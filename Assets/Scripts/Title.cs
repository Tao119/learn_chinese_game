using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject rangeOption;
    public Button startButton;
    public Toggle[] rangeOpts = new Toggle[9];
    public static bool[] choosed = new bool[9];


    // Start is called before the first frame update
    void Start()
    {
        rangeOption.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void game1()
    {
        rangeOption.SetActive(true);
        startButton.GetComponent<Button>().onClick.AddListener(Sgame1);
    }
    public void game2()
    {
        rangeOption.SetActive(true);
        startButton.GetComponent<Button>().onClick.AddListener(Sgame2);
    }
    public  void game3()
    {
        rangeOption.SetActive(true);
        startButton.GetComponent<Button>().onClick.AddListener(Sgame3);
    }
    public void backButton()
    {
        SceneManager.LoadScene("Home");
    }


    public void checkTog(GameObject obj)
    {
        int name = Convert.ToInt16(obj.name);
        choosed[name-1] = obj.GetComponent<Toggle>().isOn;
    }


    public void Sgame1()
    {
        int count = 0;
        for(int i = 0; i < 9; i++)
        {
            if (choosed[i]==true)
            {
                count++;
            }
        }
        if (count != 0)
        {
            SceneManager.LoadScene("Game1");
        }
    }
    public void Sgame2()
    {
        int count = 0;
        for (int i = 0; i < 9; i++)
        {
            if (choosed[i]==true)
            {
                count++;
            }
        }
        if (count != 0)
        {
            SceneManager.LoadScene("Game2");
        }
    }
    public void Sgame3()
    {
        int count = 0;
        for (int i = 0; i < 9; i++)
        {
            if (choosed[i]==true)
            {
                count++;
            }
        }
        if (count != 0)
        {
            SceneManager.LoadScene("Game3");
        }
    }
}

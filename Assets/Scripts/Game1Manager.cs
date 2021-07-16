using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class Game1Manager : MonoBehaviour
{
    public string[,] datas; 
    public Text[] optTexts = new Text[4];
    public Text probText;
    public Text pronText;
    public int num;
    private int probNum;
    public int trueAns;
    int[] randomNum=new int[10];
    public Text pointText;
    bool isPlaying;

    public GameObject trueMark;
    public GameObject falseMark;

    public float timer;
    float defTime = 5.0f;

    public Slider timeSlider;

    public static int point;

    public GameObject menuObj;

    public Button[] options;
    int correctOpt;

    string[,] dataSet;
    // Start is called before the first frame update
    void Start()
    {
        datas = new string[0,7];
        importDatas();
        num =datas.GetLength(0);
        probNum = 0;
        trueAns = 0;
        point = 0;
        timer = defTime;
        isPlaying = true;
        menuObj.SetActive(false);
        correctOpt = 0;
        for (int i = 0; i < 10; i++)
        {
            randomNum[i] = UnityEngine.Random.Range(0, num);
            if (i != 0)
            {
                for (int k = 0; k < i; k++)
                {
                    if (randomNum[i] == randomNum[k])
                    {
                        i--;
                    }
                }
            }
        }
        optionsSet();
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = point.ToString();
        if (isPlaying)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                timeSlider.value = timer / defTime;
            }
            else
            {
                options[correctOpt].image.color = Color.blue;
                falseMark.SetActive(true);
                if (probNum < 9)
                {
                    probNum++;

                    Invoke("optionsSet", 2.0f);
                }
                else
                {
                    Invoke("toResult", 2.0f);
                }
                isPlaying = false;
            }
        }
    }
    void optionsSet()
    {
        probText.text = datas[randomNum[probNum], 0];
        pronText.text = datas[randomNum[probNum], 1];
        options[correctOpt].image.color = Color.white;
        int[] randomNum2 = new int[4];
        for (int i = 0; i < 4; i++)
        {
            randomNum2[i] = UnityEngine.Random.Range(0, 4);
            if (i != 0)
            {
                for (int k = 0; k < i; k++)
                {
                    if (randomNum2[i] == randomNum2[k])
                    {
                        i--;
                    }
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            optTexts[i].text = datas[randomNum[probNum],randomNum2[i]+3];
            if (options[i].GetComponentInChildren<Text>().text== datas[randomNum[probNum], 2])
            {
                correctOpt = i;
            }
        }
        isPlaying = true;
        trueMark.SetActive(false);
        falseMark.SetActive(false);
        timer = defTime;
    }
    public void buttonPress(GameObject obj)
    {
        options[correctOpt].image.color = Color.blue;
        if (isPlaying)
        {
            if (obj.GetComponentInChildren<Text>().text == datas[randomNum[probNum], 2])
            {
                point += 10;
                trueMark.SetActive(true);
            }
            else
            {
                falseMark.SetActive(true);
            }

            if (probNum < 9)
            {
                probNum++;

                Invoke("optionsSet", 2.0f);
            }
            else
            {
                Invoke("toResult", 2.0f);
            }
            isPlaying = false;
        }
    }
    void toResult()
    {
        SceneManager.LoadScene("Result1");
    }
    public void menuButton()
    {
        if (isPlaying)
        {
            menuObj.SetActive(true);
            isPlaying = false;
        }
    }
    public void resumeButton()
    {
        menuObj.SetActive(false);
        isPlaying = true;
    }
    public void retryButton()
    {
        Start();
    }
    public void titleButton()
    {
        SceneManager.LoadScene("Home");
    }
    public void importDatas()
    {
        if (Title.choosed[8]) {
            string[,] datasHolder = new string[datas.GetLength(0) + dataManager.datas9.GetLength(0), 7];
            Array.Copy(datas, datasHolder, datas.Length);
            Array.Copy(dataManager.datas9, 0, datasHolder, datas.Length, dataManager.datas9.Length);
            datas = datasHolder;
        }
        if (Title.choosed[7])
        {
            string[,] datasHolder = new string[datas.GetLength(0) + dataManager.datas8.GetLength(0), 7];
            Array.Copy(datas, datasHolder, datas.Length);
            Array.Copy(dataManager.datas8, 0, datasHolder, datas.Length, dataManager.datas8.Length);
            datas = datasHolder;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class Game2Manager : MonoBehaviour
{
    string[,] datas;
    public int num;
    private int probNum;
    int[] randomNum;
    int[] randomNum2;
    public Text pointText;
    bool isPlaying;

    public GameObject trueMark;
    public GameObject falseMark;

    public float timer;
    float defTime = 45.0f;

    public Slider timeSlider;

    public static int point;

    public GameObject menuObj;

    public Button optionsButton;
    public Button[] options;

    public GameObject canvas;
    public Text trueAnswerText;

    string[,] dataSet;

    public Text ansText;
    string trueAnsText;
    // Start is called before the first frame update
    void Start()
    {
        datas = new string[0, 11];
        importDatas();
        num = datas.GetLength(0);
        probNum = 0;
        point = 0;
        timer = defTime;
        isPlaying = true;
        menuObj.SetActive(false);
        ansText.text = "";
        canvas= GameObject.Find("Canvas");
        randomNum = new int[5];
        for (int i = 0; i < 5; i++)
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
                falseMark.SetActive(true);
                trueAnswerText.gameObject.SetActive(true);
                if (probNum < 4)
                {
                    probNum++;

                    Invoke("optionsSet", 2.0f);
                }
                else
                {
                    SceneManager.LoadScene("Result2");
                }
                isPlaying = false;
            }
        }
    }
    void optionsSet()
    {
        ansText.text = "";
        trueAnswerText.text = "";
        trueAnsText = "";
        trueAnswerText.gameObject.SetActive(false);
        GameObject[] opts= GameObject.FindGameObjectsWithTag("option");
        foreach (GameObject cube in opts)
        {
            Destroy(cube);
        }

        int numb = 0;
        int pos_y=0;
        while ((datas[randomNum[probNum],numb]!= "。") &&
            (datas[randomNum[probNum], numb] != "！") &&
            (datas[randomNum[probNum], numb] != "？"))
        {

            trueAnsText += datas[randomNum[probNum], numb];
            numb++;

        }
        trueAnsText += datas[randomNum[probNum], numb];
        trueAnswerText.text = trueAnsText;

        randomNum2 = new int[numb+1];
        for (int i = 0; i < numb+1; i++)
        {
            randomNum2[i] = UnityEngine.Random.Range(0, numb+1);
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
        options = new Button[numb+1];
        for (int i = 0; i < numb+1 ; i++)
        {
            options[i] = Instantiate(optionsButton, new Vector3(0, pos_y, 0), Quaternion.identity) as Button;
            options[i].transform.SetParent(canvas.transform);
            switch (i % 3)
            {
                case 0:
                    options[i].GetComponent<RectTransform>().localPosition = new Vector3(0, pos_y, 0);
                    break;
                case 1:
                    options[i].GetComponent<RectTransform>().localPosition = new Vector3(250, pos_y, 0);
                    break;
                case 2:
                    options[i].GetComponent<RectTransform>().localPosition = new Vector3(-250, pos_y, 0);
                    pos_y -= 200;
                    break;
            }

            options[i].transform.localScale = new Vector3(1,1,1);
            options[i].GetComponentInChildren<Text>().text = datas[randomNum[probNum], i];
            GameObject buttonObj = options[i].gameObject;
            options[i].GetComponent<Button>().onClick.AddListener(() => { buttonPress(buttonObj); });
        }
        isPlaying = true;
        trueMark.SetActive(false);
        falseMark.SetActive(false);
        timer = defTime;
    }

    

    public void buttonPress(GameObject obj)
    {
        if (isPlaying)
        {
            ansText.text += obj.GetComponentInChildren<Text>().text;
            Destroy(obj);
        }
    }
    public void clearButton()
    {
        if (isPlaying)
        {
            optionsSet();
        }
    }
    public void enterButton()
    {
        if (isPlaying)
        {
            if (ansText.text == trueAnsText)
            {
                point += 20;
                trueMark.SetActive(true);
            }
            else
            {
                falseMark.SetActive(true);
                trueAnswerText.gameObject.SetActive(true);
            }
            if (probNum < 4)
            {
                probNum++;

                Invoke("optionsSet", 2.0f);
            }
            else
            {
                SceneManager.LoadScene("Result2");
            }
            isPlaying = false;
        }
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
        if (Title.choosed[8])
        {
            string[,] datasHolder = new string[datas.GetLength(0) + dataManager.datas9_2.GetLength(0), 11];
            Array.Copy(datas, datasHolder, datas.Length);
            Array.Copy(dataManager.datas9_2, 0, datasHolder, datas.Length, dataManager.datas9_2.Length);
            datas = datasHolder;
        }
        if (Title.choosed[7])
        {
            string[,] datasHolder = new string[datas.GetLength(0) + dataManager.datas8_2.GetLength(0), 11];
            Array.Copy(datas, datasHolder, datas.Length);
            Array.Copy(dataManager.datas8_2, 0, datasHolder, datas.Length, dataManager.datas8_2.Length);
            datas = datasHolder;
        }
    }
}

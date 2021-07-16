using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class Game3Manager : MonoBehaviour
{
    
    private int probNum;
    public Text probText;
    public int num;
    public Text pointText;
    bool isPlaying;

    public GameObject trueMark;
    public GameObject falseMark;

    public float timer;
    float defTime = 45.0f;

    public Slider timeSlider;

    public static int point;

    public GameObject menuObj;

    string[,] dataSet;

    string ansWord;
    public Text ansText;
    string[,] datas;
    int[] randomNum = new int[10];

    public Text correctAns;



    // Start is called before the first frame update
    void Start()
    {
        datas = new string[0,2];
        importDatas();
        num = datas.GetLength(0);
        ansText.text = "";
        ansWord = "";

        
        probNum = 0;
        point = 0;
        timer = defTime;
        isPlaying = true;
        menuObj.SetActive(false);
        correctAns.gameObject.SetActive(false);
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
        ansText.text = ansWord;
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
                correctAns.text = datas[randomNum[probNum], 1];
                correctAns.gameObject.SetActive(true);
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
        isPlaying = true;
        trueMark.SetActive(false);
        falseMark.SetActive(false);
        timer = defTime;
        ansWord = "";
        correctAns.gameObject.SetActive(false);
    }
    void toResult()
    {
        SceneManager.LoadScene("Result3");
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

    public void enterbutton()
    {
        if(ansWord== datas[randomNum[probNum], 1])
        {
            point += 10;
            trueMark.SetActive(true);
            if (probNum < 9)
            {
                probNum++;

                Invoke("optionsSet", 2.0f);
            }
            else
            {
                SceneManager.LoadScene("Result");
            }
            isPlaying = false;
        }
        else
        {
            falseMark.SetActive(true);
            timer -= 10;
            Invoke("destroyMark", 1.0f);

        }
        ansWord = "";
    }
    void destroyMark()
    {
        falseMark.SetActive(false);
    }

    public void PinyinButton(GameObject obj)
    {
        if (isPlaying)
        {
            ansWord+=obj.GetComponentInChildren<Text>().text.ToLower();
        }
    }
    public void delete1Button()
    {
        ansWord = ansWord.Substring(0, ansWord.Length - 1);
    }
    public void deleteAllButton()
    {
        ansWord = "";
    }
    public void spaceButton()
    {
        ansWord = ansWord+ " ";
    }
    public void ToneButton(GameObject obj)
    {
        if(ansWord.Substring(ansWord.Length - 1)=="a")
        {
            switch (obj.GetComponentInChildren<Text>().text)
            {
                case "1":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ā";
                    break;
                case "2":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "á";
                    break;
                case "3":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ǎ";
                    break;
                case "4":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "à";
                    break;
            }
        }
        if (ansWord.Substring(ansWord.Length - 1) == "i")
        {
            switch (obj.GetComponentInChildren<Text>().text)
            {
                case "1":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ī";
                    break;
                case "2":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "í";
                    break;
                case "3":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ǐ";
                    break;
                case "4":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ì";
                    break;
            }
        }
        if (ansWord.Substring(ansWord.Length - 1) == "u")
        {
            switch (obj.GetComponentInChildren<Text>().text)
            {
                case "1":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ū";
                    break;
                case "2":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ú";
                    break;
                case "3":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ǔ";
                    break;
                case "4":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ù";
                    break;
            }
        }
        if (ansWord.Substring(ansWord.Length - 1) == "ü")
        {
            switch (obj.GetComponentInChildren<Text>().text)
            {
                case "1":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ǖ";
                    break;
                case "2":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ǘ";
                    break;
                case "3":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ǚ";
                    break;
                case "4":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ǜ";
                    break;
            }
        }
        if (ansWord.Substring(ansWord.Length - 1) == "e")
        {
            switch (obj.GetComponentInChildren<Text>().text)
            {
                case "1":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ē";
                    break;
                case "2":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "é";
                    break;
                case "3":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ě";
                    break;
                case "4":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "è";
                    break;
            }
        }
        if (ansWord.Substring(ansWord.Length - 1) == "o")
        {
            switch (obj.GetComponentInChildren<Text>().text)
            {
                case "1":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ō";
                    break;
                case "2":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ó";
                    break;
                case "3":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ǒ";
                    break;
                case "4":
                    ansWord = ansWord.Substring(0, ansWord.Length - 1) + "ò";
                    break;
            }
        }
    }
    public void titleButton()
    {
        SceneManager.LoadScene("Home");
    }
    public void importDatas()
    {
        if (Title.choosed[8])
        {
            string[,] datasHolder = new string[datas.GetLength(0) + dataManager.datas9_3.GetLength(0), 2];
            Array.Copy(datas, datasHolder, datas.Length);
            Array.Copy(dataManager.datas9_3, 0, datasHolder, datas.Length, dataManager.datas9_3.Length);
            datas = datasHolder;
        }
        if (Title.choosed[7])
        {
            string[,] datasHolder = new string[datas.GetLength(0) + dataManager.datas8_3.GetLength(0), 2];
            Array.Copy(datas, datasHolder, datas.Length);
            Array.Copy(dataManager.datas8_3, 0, datasHolder, datas.Length, dataManager.datas8_3.Length);
            datas = datasHolder;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataManager : MonoBehaviour
{
    public static data9 Data9;
    public static data9_2 Data9_2;
    public static string[,] datas9;
    public static int count9 = 0;
    public static string[,] datas9_2;
    public static int count9_2 = 0;
    public static string[,] datas9_3;
    public static int count9_3 = 0;

    public static data8 Data8;
    public static datas8_2 Data8_2;
    public static string[,] datas8;
    public static int count8 = 0;
    public static string[,] datas8_2;
    public static int count8_2 = 0;
    public static string[,] datas8_3;
    public static int count8_3 = 0;
    // Start is called before the first frame update
    void Start()
    {
        Data9 = Resources.Load("data9") as data9;
        Data9_2 = Resources.Load("data9_2") as data9_2;

        while (Data9.sheets[0].list[count9].option1 != "")
        {
            count9++;
        }
        datas9 = new string[count9 - 1, 7];
        for (int j = 0; j < count9 - 1; j++)
        {
            for (int i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        datas9[j, i] = Data9.sheets[0].list[j].word;
                        break;
                    case 1:
                        datas9[j, i] = Data9.sheets[0].list[j].pinyin;
                        break;
                    case 2:
                        datas9[j, i] = Data9.sheets[0].list[j].meaning;
                        break;
                    case 3:
                        datas9[j, i] = Data9.sheets[0].list[j].option1;
                        break;
                    case 4:
                        datas9[j, i] = Data9.sheets[0].list[j].option2;
                        break;
                    case 5:
                        datas9[j, i] = Data9.sheets[0].list[j].option3;
                        break;
                    case 6:
                        datas9[j, i] = Data9.sheets[0].list[j].option4;
                        break;
                }
            }
        }
        count9_2 = Data9_2.sheets[0].list.ToArray().Length;
        datas9_2 = new string[count9_2-1, 11];
        for (int j = 0; j < count9_2-1; j++)
        {
            for (int i = 0; i < 11; i++)
            {
                switch (i)
                {
                    case 0:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].a;
                        break;
                    case 1:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].b;
                        break;
                    case 2:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].c;
                        break;
                    case 3:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].d;
                        break;
                    case 4:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].e;
                        break;
                    case 5:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].f;
                        break;
                    case 6:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].g;
                        break;
                    case 7:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].h;
                        break;
                    case 8:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].i;
                        break;
                    case 9:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].j;
                        break;
                    case 10:
                        datas9_2[j, i] = Data9_2.sheets[0].list[j].k;
                        break;
                }
            }
        }
        count9_3 = Data9.sheets[0].list.ToArray().Length;

        datas9_3 = new string[count9_3, 2];
        for (int j = 0; j < count9_3; j++)
        {
            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        datas9_3[j, i] = Data9.sheets[0].list[j].word;
                        break;
                    case 1:
                        datas9_3[j, i] = Data9.sheets[0].list[j].pinyin;
                        break;
                }
            }
        }

        Data8 = Resources.Load("data8") as data8;
        Data8_2 = Resources.Load("data8_2") as datas8_2;
        while (Data8.sheets[0].list[count8].option1 != "")
        {
            count8++;
        }
        datas8 = new string[count8 - 1, 7];
        for (int j = 0; j < count8 - 1; j++)
        {
            for (int i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        datas8[j, i] = Data8.sheets[0].list[j].word;
                        break;
                    case 1:
                        datas8[j, i] = Data8.sheets[0].list[j].pinyin;
                        break;
                    case 2:
                        datas8[j, i] = Data8.sheets[0].list[j].meaning;
                        break;
                    case 3:
                        datas8[j, i] = Data8.sheets[0].list[j].option1;
                        break;
                    case 4:
                        datas8[j, i] = Data8.sheets[0].list[j].option2;
                        break;
                    case 5:
                        datas8[j, i] = Data8.sheets[0].list[j].option3;
                        break;
                    case 6:
                        datas8[j, i] = Data8.sheets[0].list[j].option4;
                        break;
                }
            }
        }
        count8_2 = Data8_2.sheets[0].list.ToArray().Length;
        datas8_2 = new string[count8_2 - 1, 11];
        for (int j = 0; j < count8_2 - 1; j++)
        {
            for (int i = 0; i < 11; i++)
            {
                switch (i)
                {
                    case 0:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].a;
                        break;
                    case 1:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].b;
                        break;
                    case 2:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].c;
                        break;
                    case 3:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].d;
                        break;
                    case 4:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].e;
                        break;
                    case 5:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].f;
                        break;
                    case 6:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].g;
                        break;
                    case 7:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].h;
                        break;
                    case 8:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].i;
                        break;
                    case 9:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].j;
                        break;
                    case 10:
                        datas8_2[j, i] = Data8_2.sheets[0].list[j].k;
                        break;
                }
            }
        }
        count8_3 = Data8.sheets[0].list.ToArray().Length;

        datas8_3 = new string[count8_3, 2];
        for (int j = 0; j < count8_3; j++)
        {
            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        datas8_3[j, i] = Data8.sheets[0].list[j].word;
                        break;
                    case 1:
                        datas8_3[j, i] = Data8.sheets[0].list[j].pinyin;
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

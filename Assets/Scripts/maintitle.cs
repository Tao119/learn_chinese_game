using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class maintitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void solo()
    {
        SceneManager.LoadScene("Home1");
    }
    public void multi()
    {
        SceneManager.LoadScene("Home2");
    }
}
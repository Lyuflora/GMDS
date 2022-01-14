using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class start : MonoBehaviour
{
    Animator ani;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        ani = canvas.GetComponent<Animator>();
    }
    
    public void click1()
    {
        Invoke("stop", 0.3f);
    }
    void stop()
    {
        SceneManager.LoadScene("dialog");

    }
    public void click2()
    {
        Application.Quit();
    }
    public void click3()
    {
        ani.SetBool("end",true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject options;
    public Text EnterName;
    public void Start()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Options()
    {
        EnterName.text = Settings.name;
        menu.SetActive(false);
        options.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }   
    public void Back()
    {
        Settings.name = EnterName.text;
        menu.SetActive(true);
        options.SetActive(false);
    }

}

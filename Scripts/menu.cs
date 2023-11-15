using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadScene()
    {
        SceneManager.LoadScene("intro");
    }

    public void ExitGame()
    {
       Application.Quit();
    }

    public void ShowOptions()
    {
        Panel.SetActive(true);
    }

    public void BackToMenu()
    {
        Panel.SetActive(false);
    }
}

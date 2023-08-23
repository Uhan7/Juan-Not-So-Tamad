using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMaster : MonoBehaviour
{

    public GameObject blackscreen;
    public GameObject BGM;

    public void Waiter(string funcName)
    {
        blackscreen.SetActive(true);
        Destroy(BGM);
        Invoke(funcName, 3.5f);
    }

    public void GoLuksoGame()
    {
        SceneManager.LoadScene("Lukso Game Intro");
    }

}

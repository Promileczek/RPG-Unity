using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void SCENA_NowaGra()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("NewGame");
    }

        public void SCENA_Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}

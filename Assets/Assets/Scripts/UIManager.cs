using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button restartBtn;

    public void Reset()
    {
        SceneManager.LoadScene("MainGamePlay");
    }
}

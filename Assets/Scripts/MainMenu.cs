using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public void StartNew()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.playerName = playerNameText.text;
    }
}

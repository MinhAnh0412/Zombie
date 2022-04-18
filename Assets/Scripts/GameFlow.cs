using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }
    public void OnPlayerDead()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int soldiersRescued;
    public int solidersPicked;
    public bool canPlayerControl = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndGame()
    {
        canPlayerControl = false;
        // TODO show game over UI
        StartCoroutine(DoRestart(5));
    }

    public IEnumerator DoRestart(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Game restarted!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
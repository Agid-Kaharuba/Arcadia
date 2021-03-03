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
    public int rescuedToWin = 3;

    public int RescuedCount
    {
        get { return soldiersRescued; }
        set
        {
            soldiersRescued = value;
            
            if (soldiersRescued >= rescuedToWin)
            {
                EndGame(true);
            }
        }
    }

    public int PickedCount
    {
        get { return solidersPicked; }
        set { solidersPicked = value; }
    }

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

    public void EndGame(bool hasWon = false)
    {
        canPlayerControl = false;

        if (hasWon)
        {
            UIManager.Instance.ShowWin(true);
        }
        else
        {
            UIManager.Instance.ShowLose(true);
        }

        StartCoroutine(DoRestart(5));
    }

    public IEnumerator DoRestart(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Game restarted!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        // Make sure to reset anything belonging to GameManager
        canPlayerControl = true;
        soldiersRescued = 0;
        solidersPicked = 0;
    }
}
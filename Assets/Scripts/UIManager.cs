using System;
using TMPro;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winObject;
    [SerializeField] private GameObject loseObject;
    [SerializeField] private TMP_Text pickedText;
    [SerializeField] private TMP_Text rescuedText;
    
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Nice quick and simple, though not very optimised
        pickedText.text = $"Picked Up: {GameManager.Instance.solidersPicked}";
        rescuedText.text = $"Rescued: {GameManager.Instance.soldiersRescued}";
    }

    public void ShowWin(bool isVisible)
    {
        winObject.SetActive(isVisible);
    }

    public void ShowLose(bool isVisible)
    {
        loseObject.SetActive(isVisible);
    }
}
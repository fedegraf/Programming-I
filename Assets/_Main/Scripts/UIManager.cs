using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject winUI;
    [SerializeField] public GameObject looseUI;
    [SerializeField] public GameObject uI;
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public Button startButton;
    [SerializeField] public Button resetButtonL;
    [SerializeField] public Button exitGameW;
    [SerializeField] public Button exitGameL;
    [SerializeField] public Button resetButtonW;
    [SerializeField] public Image lifeBar;
    [SerializeField] public Image bossLifeBar;
    [SerializeField] public GameObject character;
    [SerializeField] public Text textoTutorial;
    [SerializeField] public FinalBossEnemyManager finalBoss;
    private void Awake()
    {

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            winUI.gameObject.SetActive(false);
            looseUI.gameObject.SetActive(false);
            uI.gameObject.SetActive(false);
            winUI.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
            startButton.onClick.AddListener(StartGame);
            resetButtonW.onClick.AddListener(Continue);
            resetButtonL.onClick.AddListener(ResetGame);
            exitGameL.onClick.AddListener(ExitGame);
            exitGameW.onClick.AddListener(ExitGame);
            LifeManager lifeManageScript = character.GetComponent<LifeManager>();
            lifeManageScript.looseEvent.AddListener(ShowLooseUI);
        }
        else
        {
            winUI.gameObject.SetActive(false);
            looseUI.gameObject.SetActive(false);
            uI.gameObject.SetActive(true);
            winUI.gameObject.SetActive(false);
            resetButtonW.onClick.AddListener(ResetGame);
            resetButtonL.onClick.AddListener(ResetGame); 
            exitGameL.onClick.AddListener(ExitGame);
            exitGameW.onClick.AddListener(ExitGame);
            LifeManager lifeManageScript = character.GetComponent<LifeManager>();
            lifeManageScript.looseEvent.AddListener(ShowLooseUI);
            finalBoss.updateUI += UpdateUIFinalBoss;
            finalBoss.finalBossDefeated.AddListener(ShowWinUI);
            Debug.Log("Suscribite perri");
        }

    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        winUI.gameObject.SetActive(false);
        looseUI.gameObject.SetActive(false);
        uI.gameObject.SetActive(true);
        winUI.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        textoTutorial.gameObject.SetActive(true);
        Destroy(textoTutorial, 5f);

    }
    private void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void Continue()
    {
        SceneManager.LoadScene("FinalBossScene");
    }

    public void updateLifeBar(float currentlife)
    {
        lifeBar.fillAmount = currentlife / 100; 
    }
    public void UpdateUIFinalBoss(float currentlife)
    {
        currentlife = currentlife * 100 / finalBoss.maxLife;
        Debug.Log("La concha de tu madre all Boys");
        bossLifeBar.fillAmount = currentlife / 100;
    }

    private void ShowLooseUI()
    {
        winUI.gameObject.SetActive(false);
        looseUI.gameObject.SetActive(true);
        uI.gameObject.SetActive(false);
        winUI.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
    }
    private void ShowWinUI()
    {
        looseUI.gameObject.SetActive(false);
        uI.gameObject.SetActive(false);
        winUI.gameObject.SetActive(true);
    }
}

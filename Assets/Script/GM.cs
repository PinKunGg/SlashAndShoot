using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    float CurrentScene;
    public Text TimerTxt;
    public GameObject Player, WinPanel,PlayUI, ChristMasTree, TreeSpawnCollect;
    string ConvertTime;
    [SerializeField] float MinTimer, SecTimer, MaxMapSpawnRange, MinMapSpawnRange, MaxDeepMapSpawnRange, MinDeepMapSpawnRange, MaxTree;
    [SerializeField] bool isTitle;
    private void Start()
    {   
        if(isTitle == false)
        {
            WinPanel.SetActive(false);
            CurrentScene = SceneManager.GetActiveScene().buildIndex;
        }
        GenerateMap();
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if(MinTimer > 0f || SecTimer > 0f && isTitle == false)
        {
            if(SecTimer > 0f)
            {
                SecTimer -= Time.deltaTime;
            }
            else if(MinTimer > 0f)
            {
                MinTimer -= 1f;
                SecTimer = 60f;                
            }

            if(Mathf.Round(SecTimer) <= 9f && Mathf.Round(MinTimer) <= 9f)
            {
                ConvertTime = "0" + Mathf.Round(MinTimer).ToString() + " : " + "0" + Mathf.Round(SecTimer).ToString();
                TimerTxt.text = ConvertTime;
            }
            else if(Mathf.Round(SecTimer) <= 9f)
            {
                ConvertTime = Mathf.Round(MinTimer).ToString() + " : " + "0" + Mathf.Round(SecTimer).ToString();
                TimerTxt.text = ConvertTime;
            }
            else if(Mathf.Round(MinTimer) <= 9f)
            {
                ConvertTime = "0" + Mathf.Round(MinTimer).ToString() + " : " + Mathf.Round(SecTimer).ToString();
                TimerTxt.text = ConvertTime;
            }
            else
            {
                ConvertTime = Mathf.Round(MinTimer).ToString() + " : " + Mathf.Round(SecTimer).ToString();
                TimerTxt.text = ConvertTime;
            }
        }
        else
        {
            if(isTitle == false)
            {
                WinPanel.SetActive(true);
                PlayUI.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }

    public void GenerateMap()
    {
        for(int i = 0; i < MaxTree; i++)
        {
            Vector3 SpawnPos = new Vector3(Random.Range(-MinMapSpawnRange,MaxMapSpawnRange),-2f,Random.Range(-MinDeepMapSpawnRange,MaxDeepMapSpawnRange));
            GameObject Tree =  Instantiate(ChristMasTree,Player.transform.position + SpawnPos,Quaternion.identity);
            Tree.transform.parent = TreeSpawnCollect.transform;

            if(Tree.transform.position.z < 10f && Tree.transform.position.z > -10f)
            {
                Destroy(Tree);
            }
        }
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider HpBar;
    public Image Hit_Fx, HpBarFill;
    public GameObject DeathUI,PlayUI;

    private void Start()
    {
        Time.timeScale = 1f;
        Hit_Fx.CrossFadeAlpha(0f,0f,false);
        PlayUI.SetActive(true);
        DeathUI.SetActive(false);
        HpBar.maxValue = 100f;
        HpBar.value = 100f;   
    }
    private void Update()
    {
        if(HpBar.value <= 0)
        {
            PlayUI.SetActive(false);
            DeathUI.SetActive(true);
            Time.timeScale = 0f;
        }

        if(HpBar.value > HpBar.maxValue / 2f)
        {
            HpBarFill.color = Color.green;
        }
        else if(HpBar.value <= HpBar.maxValue / 2f && HpBar.value > HpBar.maxValue / 4f)
        {
            HpBarFill.color = Color.yellow;
        }
        else if(HpBar.value <= HpBar.maxValue / 4f)
        {
            HpBarFill.color = Color.red;
        }

    }
    public void TakeHit(float index)
    {
        if(index == 1)
        {
            Hit_Fx.CrossFadeAlpha(1f,0.1f,false);
            HpBar.value -= 5f;
            Invoke("ResetHitFx",0.5f);
        }
        else if(index == 2)
        {
            Hit_Fx.CrossFadeAlpha(1f,0.1f,false);
            HpBar.value -= 10f;
            Invoke("ResetHitFx",0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            Hit_Fx.CrossFadeAlpha(1f,0.1f,false);
            HpBar.value -= 5f;
            Invoke("ResetHitFx",0.5f);
        }
        if(other.gameObject.CompareTag("enemy2"))
        {
            Hit_Fx.CrossFadeAlpha(1f,0.1f,false);
            HpBar.value -= 10f;
            Invoke("ResetHitFx",0.5f);
        }
    }
    void ResetHitFx()
    {
        Hit_Fx.CrossFadeAlpha(0f,0.5f,false);
    }
}

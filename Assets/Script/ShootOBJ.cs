using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootOBJ : MonoBehaviour
{
    public GameObject arCamera;
    public Text scoreText;
    public Animator animator;
    public ParticleSystem ShootFx;
    public Slider SlashBar;
    public Image SlahBarFill;
    bool isAttack, canShoot, isSlash;

    int pointValue;

    private void Start()
    {
        canShoot = true;    
    }

    private void Update()
    {
        if(SlashBar.value <= 0 && isSlash == true)
        {
            SlahBarFill.color = Color.cyan;
            canShoot = true;
            isSlash = false;
        }

        if(SlashBar.value < SlashBar.maxValue / 2f && isSlash == false)
        {
            SlahBarFill.color = Color.cyan;
        }
        else if(SlashBar.value >= SlashBar.maxValue / 2f)
        {
            isSlash = true;
            SlahBarFill.color = Color.yellow;
        }
    }
    public void Shoot()
    {
        if(canShoot == true)
        {
            RaycastHit hit;    
            if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
            {
                if (hit.transform.CompareTag("enemy"))
                {
                    ShootFx.Play(true);
                    print(pointValue);
                    AddCoin(10);
                    Destroy(hit.transform.gameObject);
                    SlashBar.value += 1f;
                }
                if (hit.transform.CompareTag("enemy2"))
                {
                    ShootFx.Play(true);
                    print(pointValue);
                    AddCoin(20);
                    Destroy(hit.transform.gameObject);
                    SlashBar.value += 1f;
                }
            }
        }
    }
    public void Slash()
    {
        if(isSlash == true)
        {
            canShoot = false;
            if(isAttack == false)
            {
                SlashBar.value -= 1f;
                isAttack = true;
                animator.SetTrigger("isAttack");
                Invoke("ResetSlah",0.2f);
            }
        }
    }
    void ResetSlah()
    {
        isAttack = false;
    }
    public void AddCoin(int score)
    {
        pointValue = pointValue + score;
        scoreText.text = "SCORE: " + pointValue.ToString();
    }
}

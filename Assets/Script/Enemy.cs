using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject PlayerPos;
    ShootOBJ ShootOBJ;
    public ParticleSystem explosionParticle;
    
    private void Awake()
    {
        ShootOBJ = GameObject.Find("GM").GetComponent<ShootOBJ>();
        PlayerPos = GameObject.Find("PlayerPos");
    }
    private void OnDestroy()
    {
        ParticleSystem Fx = Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(Fx.gameObject,1f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,PlayerPos.transform.position, 5f * Time.deltaTime);
        transform.LookAt(PlayerPos.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Sword"))
        {
            Destroy(gameObject);

            if(this.gameObject.CompareTag("enemy"))
            {
                ShootOBJ.AddCoin(10);
            }
            else if(this.gameObject.CompareTag("enemy2"))
            {
                ShootOBJ.AddCoin(20);
            }
        }
    }
}

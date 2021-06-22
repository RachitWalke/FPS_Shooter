using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent enemy;

    public Animator anim;

    public float enemyHealth = 50.0f;
    public float enemyDamage = 5.0f;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public GameObject ui;
    public UImanager uImanager;

    public AudioSource audiosrc;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        anim.SetTrigger("Walk_Cycle_1");
        ui = GameObject.FindGameObjectWithTag("ui");
        uImanager = ui.GetComponent<UImanager>();
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(target.gameObject.transform.position);
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;

        if(enemyHealth == 0)
        {
            audiosrc.PlayOneShot(clip);
            anim.SetTrigger("Die");
            uImanager.UpdateScore(1);
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (timeBtwAttack <= 0)
            {
                if(enemyHealth > 0)
                {
                    anim.SetTrigger("Attack_2");
                    collision.gameObject.GetComponent<Player>().PlayerTakeDamage(enemyDamage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            } 
        }
    }
}


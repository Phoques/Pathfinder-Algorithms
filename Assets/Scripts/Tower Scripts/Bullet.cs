using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    private int damage = 25;

    EnemyHealth enemyHealth;



    private void Start()
    {
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }


    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void HitTarget()
    {
        Destroy(gameObject);
        Debug.Log("Hit Enemy");

        enemyHealth.health -= damage;

        if (enemyHealth.health <= 0)
        {
            Destroy(target.gameObject);
        }

    }

}

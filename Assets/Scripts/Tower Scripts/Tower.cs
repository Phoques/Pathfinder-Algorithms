using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform target;

    private float _range = 2f;
    public float fireRate = 1f;
    private float _fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public string enemyTag = "Enemy";



    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    private void Update()
    {
        if (target == null) return;

        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / fireRate;
        }

        _fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null )
        {
            bullet.Seek(target);
        }

    }



    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= _range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }



    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(transform.position, _range);
    }


}

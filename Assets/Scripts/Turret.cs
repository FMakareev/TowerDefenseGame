using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    public float fireCountdown = 0f;


    [Header("Unity Setup Fields")]

    public string enemyTag;

    public float turnSpeed = 10f;

    public Transform partToRotate;

    public GameObject bulletPrefab;

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("UpdateTarget", 0f, 0.5f);


    }


    void UpdateTarget()
    {
        GameObject[] emenies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach (var enemy in emenies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }


    private void Update()
    {
        if (target == null)
        {
            return;
        }

        // получаем путь из точки А в точку Б
        Vector3 dir = target.position - transform.position;

        // Создаем кватернион
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        // получаем преоразованный кватернион в углы Эйлера, нужно чтобы делать вращение только по Y
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        if (fireCountdown <= 0f)
        {
            Shoot();

            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {

        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
    }
}

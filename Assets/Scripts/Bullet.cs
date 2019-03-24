 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // объект в который пуля летит
    public Transform target;

    // скорость полета пули
    public float speed = 70f;

    // Запись 
    public void Seek(Transform _target) => target = _target;

    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Если цели нет то объект удаляется
        if (target == null)
        {
            Destroy(gameObject);
            return; 
        }

        // Получаем расстояние от позиции объекта до целевой позиции
        Vector3 dir = target.position - transform.position;

        // получаем скорость перемещения
        float distanceThisFrame = speed * Time.deltaTime;

        Debug.Log(distanceThisFrame);
        Debug.Log(dir.magnitude);

        // если длина вектора расстояние до объекта меньше чем скорость перемещения
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }


        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        Debug.Log("HitTarget");

        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(effectIns, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}

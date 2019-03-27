using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    // Это шаблон синглтон, мы создаем статическую переменную в которой будет в единственном числе экземпяр BuildManager, 
    // это необходимо для того чтобы для всех потребителей BuildManager был в единственном экземпляре и чтобы для каждого потребителя данные в BuildManager были одинаковыми
    // 
    public static BuildManager instance;
    
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in scene");
            return;
        }


        // присваиваем в статическую переменную экземпляр класса BuildManager
        instance = this;
    }

    public GameObject standartTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    // Start is called before the first frame update
    void Start()
    {
        turretToBuild = standartTurretPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

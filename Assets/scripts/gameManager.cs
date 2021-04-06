using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public float resetDistanceY;
    public int lines = 4;
    public float[] roadLinesCentersX;

    SpawnManager spawnManager;
    PrefabStorage PrefabStorage;

    public void SpawnObstacles(float roadLineCenterY)
    {
        spawnManager.SpawnObjects(roadLineCenterY);
    }

    // Start is called before the first frame update
    void Start()
    {
        Road.manager = this;
        SpawnManager.manager = this;
        PrefabStorage = GetComponent<PrefabStorage>(); // вытаскиваем скрипт из объекта на котором этот скрипт
        SpawnManager.PrefabStorage = PrefabStorage;
        spawnManager = new SpawnManager(); // создать экземпляр класса




    }

    
}

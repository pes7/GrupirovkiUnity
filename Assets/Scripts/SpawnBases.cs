using UnityEngine;
using System.Collections;

public class SpawnBases : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpawnWaves();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    //Объект метеорита 
    public GameObject hazard;

    //Координаты Появления Метеорита В Простанстве 
    //В примере координаты  на оси X будут изменяться случайно в рамках           //определенного значения, остальные будут заданы сразу и изменятся не       //будут. 
    public Vector3 spawnValues;


    void SpawnWaves()
    {

        //Генерация случайной координаты X для метеорита 
        //C помощью RandomRange() 

        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

        //Для создания объекта в сцене нужно указать, как он будет повернут. 
        //Quaternion.identity - указывает на то, что поворачивать объект не                //нужно 
        Quaternion spawnRotation = Quaternion.identity;

        //Создание объекта в сцене 
        Instantiate(hazard, spawnPosition, spawnRotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    GameObject enemy;
    int index = 0;
    float timeCounter = 2f;
    float timeBetweenWaves = 10f;

    private void Update()
    {
        if(timeCounter <= 0)
        {
            StartCoroutine(CreateWaves());
            timeCounter = timeBetweenWaves;
        }
        timeCounter -= Time.deltaTime;
    }

    IEnumerator CreateWaves()
    {
        index++;
        for (int i = 0; i < index; i++)
        {
            Create();
            yield return new WaitForSeconds(1f);
        }        
    }

    void Create()
    {
        enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemy.transform.tag = "Enemy";
        enemy.GetComponent<Renderer>().material.color = Color.cyan;
        enemy.AddComponent<SphereCollider>();
        enemy.GetComponent<SphereCollider>().isTrigger = true;
        Vector3 pos = new Vector3();
        pos.x = 12.13f;
        pos.y = 0.46f;
        pos.z = 11.87f;
        enemy.transform.position = pos;

        enemy.AddComponent<Enemy>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject enemy;
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
        GameObject e = Instantiate(enemy, Vector3.zero, Quaternion.identity);
        Vector3 pos = new Vector3();
        pos.x = 12.13f;
        pos.y = 0.46f;
        pos.z = 11.87f;
        e.transform.position = pos;

        e.AddComponent<Enemy>();
    }
}

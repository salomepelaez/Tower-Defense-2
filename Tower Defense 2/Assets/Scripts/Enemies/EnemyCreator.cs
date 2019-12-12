using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject enemy;

    public GameObject[] enemies; // Este array almacena los tres tipos de enemigos que hay en el juego.
    
    int index;
    int enemiesIndex;

    // Las siguientes son variables para el tiempo entre oleadas de enemigos.
    float timeCounter = 2f;
    float timeBetweenWaves = 10f;

    private void Update()
    {
        // El siguiente bloque de código es el que inicializa la creación de enemigos cuando el contador llega a 0. 
        if(timeCounter <= 0)
        {
            StartCoroutine(CreateWaves());
            timeCounter = timeBetweenWaves; // Luego, el primer contador pasa a tomar en cuenta el tiempo de espera asignado en el segundo contador.
        }
        timeCounter -= Time.deltaTime; // Esta línea es la encargada de disminuir estos contadores.
    }

    IEnumerator CreateWaves()
    {
        index = Random.Range(0, 6); // Se asignó un número aleatorio para la oleada de enemigos.

        for (int i = 0; i < index; i++)
        {
            Create();
            yield return new WaitForSeconds(1f); // Con diferencia de 1 segundo para que no se generen uno sobre el otro.
        }        
    }

    void Create()
    {
        if (Manager.inGame == true)
        {
            // Se asigna la variable como un número aleatorio entre 0 y la cantidad de GameObjects que hay en el array.
            enemiesIndex = Random.Range(0, enemies.Length); 
            enemy = enemies[enemiesIndex]; // Se asigna el GameObject como la posición aleatoria que
            GameObject e = Instantiate(enemy, Vector3.zero, Quaternion.identity);
            Vector3 pos = new Vector3();
            pos.x = 12.13f;
            pos.y = 0.46f;
            pos.z = 11.87f;
            e.transform.position = pos;
        }
    }
}

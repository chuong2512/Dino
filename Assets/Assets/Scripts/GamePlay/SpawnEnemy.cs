using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;

    [SerializeField] public List<int>[] randomPoint;

    public float time = 2, timeCount = 2;


    private void Spawn()
    {
        var enemy = Instantiate(enemies[Random.Range(0, enemies.Length)],
            transform.position, transform.rotation);
    }

    void Update()
    {
        if (GameManager.Instance.currentState != State.Playing) return;
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = timeCount;

            Spawn();
        }
    }
}
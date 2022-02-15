using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject molPrefab;
    public Transform[] spawns;
    public float gameTime = 5f;
    bool start;

    // public class Mol
    // {
    //     void Start()
    //     {

    //     }
    //     void Update()
    //     {

    //     }
    //     void OnDestroy()
    //     {
    //         Debug.Log("Destroyed");
    //     }
    // }
    void Start()
    {
        SpawnMol(true);
    }

    void Update()
    {
        gameTime -= Time.deltaTime;
        Debug.Log(gameTime);
        if (gameTime < 0)
        {
            gameTime = 5f;
            SpawnMol();
        }
    }

    public GameObject SpawnMol(bool def = false)
    {
        GameObject mol = Instantiate(molPrefab) as GameObject;
        if (def)
        {
            mol.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            mol.transform.position = spawns[Random.Range(0, spawns.Length)].transform.position;
        }
        return mol;
    }

}
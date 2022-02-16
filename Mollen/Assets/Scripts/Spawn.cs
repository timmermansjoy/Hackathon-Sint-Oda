using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject molPrefab;
    public GameObject spawnPrefab;
    public GameObject currentMol;
    public Transform[] spawns;
    public float gameTime = 5f;
    public bool start;
    public int score;
    [SerializeField] float scaleHitbox = 0.0f;
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
        setSpawns();
        score = 0;
        currentMol = SpawnMol();

    }

    void Update()
    {
        if (start)
        {
            gameTime -= Time.deltaTime;
        }
        //Debug.Log(gameTime);
        if (gameTime < 0)
        {
            gameTime = Random.Range(2f, 6f);
            currentMol = SpawnMol();
        }
    }

    public GameObject SpawnMol()
    {
        GameObject mol = Instantiate(molPrefab) as GameObject;
        CapsuleCollider2D molCollider = GetComponent<CapsuleCollider2D>();
        mol.transform.localScale += new Vector3(scaleHitbox, scaleHitbox, 0.0f);


        mol.transform.position = spawns[Random.Range(0, spawns.Length)].transform.position;
        mol.transform.position = new Vector3(mol.transform.position.x, mol.transform.position.y + 0.75f, 0);
        // mol.transform.parent = spawns[0];

        return mol;
    }
    public void setSpawns()
    {
        GameObject spawn;
        int count = 0;
        for (int i = -1; i < 2; i += 2)
        {
            for (int j = -6; j < 7; j += 2)
            {
                //Debug.Log(j);
                spawn = Instantiate(spawnPrefab) as GameObject;
                spawn.transform.position = new Vector3(j + (Random.Range(0f, 0.4f)), (2 * i) + (Random.Range(0f, 1.5f)), 0);
                spawns[count] = spawn.transform;
                count++;
            }

        }

    }

}
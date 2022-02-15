using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject molPrefab;
    public GameObject currentMol;
    public Transform[] spawns;
    public float gameTime = 5f;
    public bool start;
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
        currentMol = SpawnMol(true);
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
            gameTime = 5f;
            Destroy(currentMol);
            currentMol = SpawnMol();
        }
    }

    public GameObject SpawnMol(bool def = false)
    {
        GameObject mol = Instantiate(molPrefab) as GameObject;
        CapsuleCollider2D molCollider = GetComponent<CapsuleCollider2D>();
        mol.transform.localScale += new Vector3(scaleHitbox, scaleHitbox, 0.0f);
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
    public void setSpawns()
    {

    }

}
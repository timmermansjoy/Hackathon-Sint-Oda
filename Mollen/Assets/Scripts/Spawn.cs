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
    private float gameTime = PlayerPrefs.GetInt("pauze");
    public bool start;
    public int score;
    public int counter = 0;
    [SerializeField] float scaleHitbox = 0.0f;


    private int speed;
    private int pauze;
    private int grootte;
    private int holes;


    void Start()
    {
        setSpawns();
        score = 0;
        currentMol = SpawnMol();


        // settings
        speed = PlayerPrefs.GetInt("speed");
        pauze = PlayerPrefs.GetInt("pauze");
        grootte = PlayerPrefs.GetInt("grootte");
        holes = PlayerPrefs.GetInt("holes");


    }

    void Update()
    {
        if (start)
        {
            if (counter < 1) { Debug.Log(gameTime); }
            gameTime -= Time.deltaTime;
        }
        //Debug.Log(gameTime);
        if (gameTime < 0)
        {
            gameTime = Random.Range(2f, 6f - speed) + (pauze / 2);
            currentMol = SpawnMol();
        }
    }




    public GameObject SpawnMol()
    {
        GameObject mol = Instantiate(molPrefab) as GameObject;


        CapsuleCollider2D molCollider = GetComponent<CapsuleCollider2D>();
        mol.transform.localScale += new Vector3(scaleHitbox * (grootte), scaleHitbox * (grootte), 0.0f);


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
                spawn.transform.position = new Vector3(j + (Random.Range(0f, 1f)), (2 * i) + (Random.Range(0f, 1.5f)), 0);
                spawns[count] = spawn.transform;
                count++;
            }

        }
    }

    public void randomSpawn(){
        // Place X number of spawners in the camera view and randomize their position
        GameObject spawn;
        int count = 0;

    }

}

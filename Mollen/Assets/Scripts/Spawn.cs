using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject molPrefab;
    public GameObject spawnPrefab;
    public GameObject bombPrefab;
    public GameObject currentMol;
    public GameObject currentBom;
    public Transform[] spawns;
    private float gameTime;
    public bool start;
    public int score;
    [SerializeField] float scaleHitbox = 0.0f;

    float bombTime;


    private int speed;
    private int pauze;
    private int grootte;
    private int holes;


    void Start()
    {
        setSpawns();
        score = 0;
        bombTime = Random.Range(10f, 20f);
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
            gameTime -= Time.deltaTime;
            bombTime -= Time.deltaTime;
        }
        //Debug.Log(gameTime);
        if (gameTime < 0)
        {
            gameTime = Random.Range(2f, 6f - speed) + (pauze / 2);
            currentMol = SpawnMol();
        }
        if (bombTime < 0)
        {
            Destroy(currentBom);
            currentBom = SpawnBomb();
            bombTime = Random.Range(10f, 20f);

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
    public GameObject SpawnBomb()
    {
        GameObject bom = Instantiate(bombPrefab) as GameObject;
        bom.transform.position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 1f), 0f);
        return bom;
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
                Debug.Log(spawn);
                spawn.transform.position = new Vector3(j + (Random.Range(0f, 1f)), (1.8f * i) - 2.4f + (Random.Range(0f, 1.5f)), 0);
                spawns[count] = spawn.transform;
                count++;
            }
        }
    }
}

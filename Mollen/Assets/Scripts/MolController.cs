using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolController : MonoBehaviour
{
    private Spawn spawner;
    public float lifeTime = 5f;
    public Sprite[] molSprites;
    public GameObject molDoodPrefab;
    GameObject ded;
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawn>();
        lifeTime = Random.Range(2f, 8f);
        int soort = Random.Range(0, 10);
        Sprite spr;
        if (soort == 1)
        {
            spr = molSprites[1];
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, 0);
        }
        else if (soort == 2)
        {
            spr = molSprites[2];
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, 0);
        }
        else if (soort == 3)
        {
            spr = molSprites[3];
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, 0);
        }
        else if (soort == 4)
        {
            spr = molSprites[4];
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, 0);
        }
        else
        {
            spr = molSprites[0];
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = spr;
    }

    void Update()
    {
        if (spawner.start)
        {
            lifeTime -= Time.deltaTime;
        }
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        ded = Instantiate(molDoodPrefab) as GameObject;
        ded.transform.position = transform.position;
    }
    private void OnApplicationQuit()
    {
        //Debug.Log("End");
    }

}

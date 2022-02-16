using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class molDood : MonoBehaviour
{
    public float lifeTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {

        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}

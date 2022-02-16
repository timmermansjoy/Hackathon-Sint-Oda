using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveStar : MonoBehaviour
{
    Camera cam;
    TMPro.TextMeshProUGUI txt;
    float speed = 10f;
    public int score = 0;
    public Transform mol;
    private Spawn spawner;

    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawn>();
        txt = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

    }

    void Update()
    {
        transform.Rotate(0, 0, 1f);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, cam.ScreenToWorldPoint(txt.transform.position), step);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoreObject")
        {
            spawner.score += 1;
            txt.text = spawner.score.ToString();
            cam.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

    }
}

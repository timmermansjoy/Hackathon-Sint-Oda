using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    public ParticleSystem stars;
    private Spawn spawner;

    public GameObject starPrefab;
    // public TMPro.TextMeshProUGUI txt;
    // Camera cam;
    void Start()
    {
        spawner = GetComponent<Spawn>();
        // txt = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
        // cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse2D = new Vector2(mouse.x, mouse.y);
            RaycastHit2D hit = Physics2D.Raycast(mouse2D, Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject.tag == "Mol")
            {
                // playStarsParticle(mouse);
                GameObject star = Instantiate(starPrefab) as GameObject;
                star.transform.position = hit.transform.gameObject.transform.position;
                //Debug.Log(star);
                Destroy(hit.transform.gameObject);
                if (!spawner.start)
                {
                    spawner.start = true;
                }
                // score++;
                // txt.text = score.ToString();
                //Debug.Log(cam.WorldToScreenPoint(txt.transform.position));
            }
        }
    }

    // void playStarsParticle(Vector3 mousePos)
    // {
    //     ParticleSystem.ShapeModule _editableShape = stars.shape;
    //     _editableShape.position = new Vector3(mousePos.x, 0, mousePos.y);
    //     stars.Play();
    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    public ParticleSystem stars;
    private Spawn spawner;
    void Start()
    {
        spawner = GetComponent<Spawn>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse2D = new Vector2(mouse.x, mouse.y);
            RaycastHit2D hit = Physics2D.Raycast(mouse2D, Vector2.zero);
            if (hit.collider != null)
            {
                playStarsParticle(mouse);
                Destroy(hit.transform.gameObject);
                if (!spawner.start)
                {
                    spawner.start = true;
                }
            }
        }
    }
    void playStarsParticle(Vector3 mousePos)
    {
        ParticleSystem.ShapeModule _editableShape = stars.shape;
        _editableShape.position = new Vector3(mousePos.x, 0, mousePos.y);
        stars.Play();
    }
}

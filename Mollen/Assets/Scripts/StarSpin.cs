using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpin : MonoBehaviour
{
    private float spinDur = 1f;
    public bool spin;
    void Start()
    {

    }

    void Update()
    {
        if (spin)
        {
            spinDur -= Time.deltaTime;
            transform.Rotate(0, 0, 1f);
            transform.localScale += new Vector3(0.03f, 0.03f, 0f);
        }
        if (spinDur < 0)
        {
            spin = false;
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, transform.rotation.w);
            transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            spinDur = 1f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAnim : MonoBehaviour
{
    public float speed = 1f;
    public float height = 0.125f;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector2(startPos.x, newY);
    }
}

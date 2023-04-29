using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundSun : MonoBehaviour
{
    private float radius;
    public float rotateSpeed;

    private float startPositionY;
    private float angle;

    Vector2 center;
    // Start is called before the first frame update
    void Start()
    {
        center = new Vector2(0, 0);
        rotateSpeed *= .01f;
        radius = Vector2.Distance(transform.position, new Vector2(0, 0));
        angle = Random.Range(0, 360);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angle += rotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle) * 0.7f) * radius;
        transform.position = center + offset;
    }
}

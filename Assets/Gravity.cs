using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityForce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GameObject[] packages = GameObject.FindGameObjectsWithTag("Package");
        foreach (GameObject package in packages)
        {
            Vector3 targetVector = new Vector3(package.transform.position.x - transform.position.x, package.transform.position.y - transform.position.y, 0);
            float distance = Vector3.Distance(package.transform.position, transform.position);

            package.GetComponent<Rigidbody2D>().AddForce(targetVector.normalized * gravityForce / (distance * distance));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityForce;

    private GameStateManager gameStateManager;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = Camera.main.GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStateManager.currentTarget.ToString().ToLower() == gameObject.name.ToLower())
        {
            gravityForce = -100;
        }
        else
        {
            gravityForce = -35;
        }
        GameObject[] packages = GameObject.FindGameObjectsWithTag("Package");
        foreach (GameObject package in packages)
        {
            Vector3 targetVector = new Vector3(package.transform.position.x - transform.position.x, package.transform.position.y - transform.position.y, 0);
            float distance = Vector3.Distance(package.transform.position, transform.position);

            package.GetComponent<Rigidbody2D>().AddForce(targetVector.normalized * gravityForce / (distance * distance));
            package.GetComponent<Package>().appliedForces += Vector3.Magnitude(targetVector.normalized * gravityForce / (distance * distance));
        }
    }
}

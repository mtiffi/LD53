using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageShooter : MonoBehaviour
{

    public GameObject packagePrefab;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetVector = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0);
            float angleRad = Mathf.Atan2(targetVector.x, targetVector.y);
            float angleDeg = (180 / Mathf.PI) * angleRad;

            GameObject newPackage = GameObject.Instantiate(packagePrefab, transform.position, Quaternion.Euler(0, 0, -angleDeg));
            newPackage.GetComponent<Rigidbody2D>().AddForce(targetVector.normalized * speed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageShooter : MonoBehaviour
{

    public GameObject packagePrefab;
    public float fillSpeed;

    public Image filling;

    private float speed = 0;
    public float maxSpeed;
    private string[] planets = {
       "sun", "mercury", "venus", "mars", "jupiter", "saturn", "uranus", "neptune"
    };

    private GameStateManager gameStateManager;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = Camera.main.GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameStateManager.currentGameState == GameStateManager.GameState.Ready)
        {

            if (Input.GetMouseButton(0) && speed <= maxSpeed)
            {
                speed += fillSpeed * Time.deltaTime;
            }
            if (Input.GetMouseButtonUp(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 targetVector = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0);
                float angleRad = Mathf.Atan2(targetVector.x, targetVector.y);
                float angleDeg = (180 / Mathf.PI) * angleRad;

                GameObject newPackage = GameObject.Instantiate(packagePrefab, transform.position, Quaternion.Euler(0, 0, -angleDeg));
                newPackage.GetComponent<Rigidbody2D>().AddForce(targetVector.normalized * speed);
                newPackage.GetComponent<Package>().target = planets[Random.Range(0, 8)];
                speed = 0;
                gameStateManager.currentGameState = GameStateManager.GameState.OnDelivery;
            }
        }
        filling.rectTransform.sizeDelta = new Vector2(522 * (speed / maxSpeed), filling.rectTransform.sizeDelta.y);

    }
}

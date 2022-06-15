using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    private float impPower;
    private float torquePos;
    private float objectPosX;
    private float objectPosY;


    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        impPower = Random.Range(12, 16);
        torquePos = Random.Range(-10, 10);
        objectPosX = Random.Range(-4, 4);
        objectPosY = 6;

        targetRB = GetComponent<Rigidbody>();
        gameManager =GameObject.Find("GameManager").GetComponent<GameManager>();
        
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive) 
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy (gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

    }

    Vector3 RandomForce() 
    {
        return (Vector3.up * impPower);
    }

    float RandomTorque() 
    {
        return (torquePos);
    }

    Vector3 RandomSpawnPos() 
    {
        return new Vector3(objectPosX, objectPosY);
    }
}

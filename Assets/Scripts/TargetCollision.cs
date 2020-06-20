using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TargetCollision : MonoBehaviour
{
    public GameObject spawnedTarget;
    public int scoreValue;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Laser(Clone)")
        {
            //Destroying target before adding to score
            Destroy(spawnedTarget);

            gameManager.AddToScore(scoreValue);
        }
    }
}

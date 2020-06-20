using UnityEngine;

public class TargetManager : MonoBehaviour
{
    //Used to determine when the game has started
    public bool startSpawning = false;

    //target model prefabs
    public GameObject easyTargetPrefab;
    public GameObject mediumTargetPrefab;
    public GameObject hardTargetPrefab;

    //target bounds
    public float lowerY = 2f;
    public float upperY = 3f;

    public float lowerX = -4f;
    public float upperX = 5f;

    public float lowerZ = 3f;
    public float upperZ = 8f;

    //Time variables to determine when to destroy or spawn a target
    public float lifeSpan = 3f;
    public float spawnRate = 0.5f;
    private float spawnTimer = 0f;

    //movement variables
    public float moveSpeed = 2f;
    public float moveRightLower = -5f;
    public float moveRightUpper = -3f;
    public float moveLeftLower = 3f;
    public float moveLeftUpper = 5f;

    // Update is called once per frame
    void Update()
    {
        if(startSpawning)
        {
            SpawnTargets();
        }
        //If the game has ended, destroy any targets still in the scene.
        else
        {
            GameObject[] leftOvers = GameObject.FindGameObjectsWithTag("Target");

            foreach(GameObject target in leftOvers)
            {
                Destroy(target);
            }
        }
    }

    void SpawnTargets()
    {
        spawnTimer += Time.deltaTime;

        //Spawns a target at the time of spawnRate
        if (spawnTimer >= spawnRate)
        {
            int targetNum = Random.Range(1, 4);

            //Determines which target to spawn
            switch (targetNum)
            {
                case 1:
                    SpawnEasy();
                    break;
                case 2:
                    SpawnMedium();
                    break;
                case 3:
                    SpawnHard();
                    break;
            }

            spawnTimer = 0f;
        }
    }

    void SpawnEasy()
    {
        float x, y, z;

        //setting x, y, z coordinates
        x = Random.Range(lowerX, upperX);
        y = Random.Range(lowerY, upperY);
        z = Random.Range(lowerZ, upperZ);

        //Creating spawned target position and rotation
        Vector3 spawnPosition = new Vector3(x, y, z);

        //Spawning target
        GameObject spawnedTarget = Instantiate(easyTargetPrefab, spawnPosition, easyTargetPrefab.transform.rotation);
        MoveTarget(spawnedTarget, x);
        Destroy(spawnedTarget, lifeSpan);
    }
    void SpawnMedium()
    {
        float x, y, z;

        //setting x, y, z coordinates
        x = Random.Range(lowerX, upperX);
        y = Random.Range(lowerY, upperY);
        z = Random.Range(lowerZ, upperZ);

        //Creating spawned target position and rotation
        Vector3 spawnPosition = new Vector3(x, y, z);

        //Spawning target
        GameObject spawnedTarget = Instantiate(mediumTargetPrefab, spawnPosition, mediumTargetPrefab.transform.rotation);
        MoveTarget(spawnedTarget, x);
        Destroy(spawnedTarget, lifeSpan);
    }
    void SpawnHard()
    {
        float x, y, z;

        //setting x, y, z coordinates
        x = Random.Range(lowerX, upperX);
        y = Random.Range(lowerY, upperY);
        z = Random.Range(lowerZ, upperZ);

        //Creating spawned target position and rotation
        Vector3 spawnPosition = new Vector3(x, y, z);

        //Spawning target
        GameObject spawnedTarget = Instantiate(hardTargetPrefab, spawnPosition, hardTargetPrefab.transform.rotation);
        MoveTarget(spawnedTarget, x);
        Destroy(spawnedTarget, lifeSpan);
    }

    void MoveTarget(GameObject target, float x)
    {
        //Moving left
        if(x > moveLeftLower && x < moveLeftUpper)
        {
            target.GetComponent<Rigidbody>().velocity = moveSpeed * -Vector3.right;
        }
        //Moving right
        else if(x > moveRightLower && x < moveRightUpper)
        {
            target.GetComponent<Rigidbody>().velocity = moveSpeed * Vector3.right;
        }
        //Target is safe to move either direction
        else
        {
            //Choose a random direction to move
            int randomDirection = Random.Range(0, 2);

            //Moving left
            if(randomDirection == 0)
            {
                target.GetComponent<Rigidbody>().velocity = moveSpeed * -Vector3.right;
            }
            //Moving right
            else
            {
                target.GetComponent<Rigidbody>().velocity = moveSpeed * Vector3.right;
            }
        }
    }
}

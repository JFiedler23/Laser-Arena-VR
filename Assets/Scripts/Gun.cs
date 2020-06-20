using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform barrelExit;
    public ParticleSystem muzzleFlash;
    public GameObject laserPrefab;

    public float bulletSpeed = 20f;

    public void Fire()
    {
        GameObject spawnedLaser = Instantiate(laserPrefab, barrelExit.position, Quaternion.identity);
        spawnedLaser.GetComponent<Rigidbody>().velocity = bulletSpeed * barrelExit.forward;
        Destroy(spawnedLaser, 2f);
    }
}

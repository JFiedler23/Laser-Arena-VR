using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject laser;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(laser);
    }
}

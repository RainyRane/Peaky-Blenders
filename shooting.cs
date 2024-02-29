using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Rendering;

public class GunSystem : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();

    }

    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            enemy_movement target = hit.transform.GetComponent<enemy_movement>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
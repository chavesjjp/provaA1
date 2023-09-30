using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public ParticleSystem fogoArma;
    public Transform raycastOrigin;

    Ray ray;
    RaycastHit hitInfo;
    public void StartFiring()
    {
        isFiring = true;
        fogoArma.Emit(1);

        ray.origin = raycastOrigin.position;
        ray.direction = raycastOrigin.forward;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.DrawRay(ray.origin, hitInfo.point, Color.red, 1);
            if (hitInfo.collider.CompareTag("guarda"))
            {
                Destroy(hitInfo.transform.gameObject);
            }
        }
    }
    public void StopFiring()
    {
        isFiring = false;
    }
}

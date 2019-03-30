using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public bool isRingCollision = false;

    public LayerMask bulletMask;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();

        // Checks for collisions using raycasts. Both before and after going through a 'portal'.
        RaycastHit[] hits;
        hits = Physics.RaycastAll(fpsCam.transform.position, fpsCam.transform.forward, range);
        if (hits != null && hits.Length > 0)
        {
            if (hits[0].collider.isTrigger && hits[0].collider.tag == "Ring")
            {
                Debug.Log(hits[0].collider.name);
                Target target = hits[hits.Length - 1].transform.GetComponent<Target>();
                //All targets that get shot through the ring should take damage.
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
                //Gives knockback to the targets that get hit through a ring.
                if (hits[hits.Length - 1].rigidbody != null)
                {
                    hits[hits.Length - 1].rigidbody.AddForce(-hits[hits.Length - 1].normal * impactForce);

                }
                //Creates a particle effect on an object hit through a ring.
                if (hits.Length > 1)
                {
                    Debug.Log(hits[hits.Length - 1].collider.name);
                    Instantiate(impactEffect, hits[hits.Length - 1].point, Quaternion.LookRotation(hits[hits.Length - 1].normal));
                }
            }
            //Creates a particle effect on an object not hit through a ring.
            else
            {
                Debug.Log(hits[hits.Length - 1].collider.name);
                Instantiate(impactEffect, hits[hits.Length - 1].point, Quaternion.LookRotation(hits[hits.Length - 1].normal));
            }
        }
    }
}

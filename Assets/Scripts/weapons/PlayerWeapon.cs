using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject grenadePrefab;


    public Transform bulletSpawn;

    public float bulletSpeed = 30;
    public float grandeSpeed = 30;


    public float lifeTime = 3;

    // Update is called once per frame
    void Update()
    {
  
    }

    public void Fire()
    {
        GameObject bullet;

        if (GetComponent<FieldOfView>().GetCurrentDistance() <= 21 && GetComponent<FieldOfView>().GetCurrentDistance() >= 0)
        {
            GetComponent<FieldOfView>().animator.SetInteger("State", 5);


            bullet = Instantiate(bulletPrefab);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

            Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
                               bulletSpawn.parent.GetComponent<Collider>());

            bullet.transform.position = bulletSpawn.position;

            var rot = bullet.transform.rotation.eulerAngles;

            bullet.transform.rotation = Quaternion.Euler(rot.x, transform.eulerAngles.y, rot.z);


            StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
        }
        else
        {
            GetComponent<FieldOfView>().animator.SetInteger("State", 6);


            bullet = Instantiate(grenadePrefab);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * grandeSpeed, ForceMode.Impulse);

            Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
                               bulletSpawn.parent.GetComponent<Collider>());

            bullet.transform.position = bulletSpawn.position;

            var rot = bullet.transform.rotation.eulerAngles;

            bullet.transform.rotation = Quaternion.Euler(rot.x, transform.eulerAngles.y, rot.z);


            StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
        }


    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }


}

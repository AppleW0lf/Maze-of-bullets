using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float fireForce = 20f;

    public void Fire(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Collider2D>().isTrigger = true;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * fireForce;
    }
}
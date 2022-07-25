using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;

    private IObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnGetBullet,
            OnReleaseBullet,

            // If generate bullet > 3, these bullets will be destroyed after invisible
            OnDestroyBullet,
            maxSize: 3
        );
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Debug.Log($"OnDestroyBullet {bullet.GetInstanceID()}");
        Destroy(bullet.gameObject);
    }

    private void OnReleaseBullet(Bullet bullet)
    {
        Debug.Log($"OnReleaseBullet {bullet.GetInstanceID()}");
        bullet.gameObject.SetActive(false);
    }

    private void OnGetBullet(Bullet bullet)
    {
        Debug.Log($"OnGetBullet {bullet.GetInstanceID()}");
        bullet.transform.position = this.transform.position;
        bullet.gameObject.SetActive(true);
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab);
        Debug.Log($"CreateBullet {bullet.GetInstanceID()}");
        bullet.SetPoolOwner(bulletPool);
        return bullet;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Bullet bullet = Instantiate(bulletPrefab);
            // bullet.transform.position = this.transform.position;

            bulletPool.Get();
        }
    }
}

using System;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{

    public Player player;
    public GameObject targetObject;

    public GameObject bulletPrefab;
    public GameObject bulletAkPrefab;
    public float bulletSpeed = 10f; 
    public float bulletLifeTime = 1f;


    public GameObject grenadePrefab;
    public float grenadeSpeed = 10f;
    public float grenadeLifeTime = 1.5f;


    private Transform aimTransform;
    private Transform aimGunEndPointTransform;
    private Inventory.Slot selectedItem;
    private SpriteRenderer spriteRenderer;

    
    /*void Start()
    {
        Destroy(bulletPrefab, bulletLifeTime);
    }*/
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimGunEndPointTransform = transform.Find("Aim/Weapon/GunEndPointPosition");
    }

    private void Update()
    {
        selectItem();
        if(selectedItem != null)
        {
            handleAiming();
            handleShooting();
        }
    }

    void selectItem()
    {
        if (player.inventory.slots[0].type != CollectableType.NONE)
        {
            if(selectedItem == null)
            {
                selectedItem = player.inventory.slots[0];
                LoadAndSetSprite(selectedItem.icon);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && (player.inventory.slots[0].type != CollectableType.NONE))
            {
                selectedItem = player.inventory.slots[0];
                LoadAndSetSprite(selectedItem.icon);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && (player.inventory.slots[1].type != CollectableType.NONE))
            {
                selectedItem = player.inventory.slots[1];
                LoadAndSetSprite(player.inventory.slots[1].icon);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && (player.inventory.slots[2].type != CollectableType.NONE))
            {
                selectedItem = player.inventory.slots[2];
                LoadAndSetSprite(player.inventory.slots[2].icon);
            }
        }
    }
    void LoadAndSetSprite(Sprite icon)
    {
        spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = icon;
    }
    void handleAiming()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        // Flip the transform based on the angle
        if (angle > 90f && angle <= 180f || angle < -90f && angle >= -180f)
        {
            aimTransform.localScale = new Vector3(1, -1, 1);
        }
        else if (angle > -90f && angle <= 90f)
        {
            aimTransform.localScale = new Vector3(1, 1, 1);
        }
    
    }
    void handleShooting()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 gunEndPositon = aimGunEndPointTransform.position;
            Vector3 shootPositon = mousePosition;
            Vector3 shootDirection = (shootPositon - gunEndPositon).normalized;
            if (selectedItem.type == CollectableType.PISTOL)
            {
                SpawnBullet(gunEndPositon, shootDirection, bulletPrefab);
            }
            else if (selectedItem.type == CollectableType.RIFFLE)
            {
                SpawnBullet(gunEndPositon, shootDirection, bulletAkPrefab);
            }
            else if(selectedItem.type == CollectableType.GRENADE)
            {
                SpawnGrenade(gunEndPositon, shootDirection);
            }
            

        }
    }

    void SpawnBullet(Vector3 position, Vector3 direction, GameObject bulletPrefab)
    {
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        Destroy(bullet, bulletLifeTime);
    }

    void SpawnGrenade(Vector3 position, Vector3 direction)
    {
        GameObject grenade = Instantiate(grenadePrefab, position, Quaternion.identity);

        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * grenadeSpeed;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        grenade.transform.rotation = Quaternion.Euler(0, 0, angle);

        Destroy(grenade, grenadeLifeTime);
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}


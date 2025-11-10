using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;

    private float nextFireTime;
    private InputSystem_Actions inputActions;
    private Camera mainCam;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        mainCam = Camera.main;
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        if (mainCam == null) return;

        // 1) On fait regarder l'arme vers la souris
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f;

        Vector2 dir = (mouseWorldPos - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // 2) On tire quand l'action Attack est déclenchée
        if (inputActions.Player.Attack.WasPerformedThisFrame() && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null) return;

        // Instancie la balle avec la même rotation que l'arme
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
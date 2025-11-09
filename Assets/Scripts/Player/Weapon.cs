using UnityEngine;
using UnityEngine.InputSystem;
public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.3f;
    private float nextFireTime;

    private InputSystem_Actions inputActions;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    void OnEnable() => inputActions.Enable();
    void OnDisable() => inputActions.Disable();

    void Update()
    {
        if (inputActions.Player.Attack.WasPerformedThisFrame() && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
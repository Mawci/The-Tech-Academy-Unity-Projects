using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rBody;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private Animator fireEffect;
    Vector2 mousePosition;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            fireEffect.SetTrigger("Shot");
            Debug.Log("Player has shot");
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePosition - rBody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 45f;
        rBody.rotation = angle;
    }
}

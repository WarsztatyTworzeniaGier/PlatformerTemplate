using GMTK.PlatformerToolkit;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    public float dashPower = 10f;
    public float dashCooldown = 1.5f;
    public int dashLimit = 1;


    private float currentCooldown;
    public bool canIDash = true;
    public Vector2 savedVelocity;

    private Rigidbody2D rb;
    private characterGround ground;

    private int dashCount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<characterGround>();
    }

    void Update()
    {
        if (ground.GetOnGround()) dashCount = 0;
        if (currentCooldown > 0)
        {
            canIDash = false;
            currentCooldown -= Time.deltaTime;
            //if I put saved velocity here, it will continue to move at savedVelocity until dashCooldown = 0? so it can't go here? right?
        }
        if (currentCooldown <= 0)
        {
            canIDash = true;
            //if I put savedVelocity here it doesn't return to savedVelocity until dashCooldown <=0 so... it doesn't go here either right...?
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canIDash == true)
        {
            if (dashCount >= dashLimit) return;
            DoDash();
        }
    }

    public void DoDash()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var direction = new Vector2(x, y);
        rb.linearVelocity = direction * dashPower;
        currentCooldown = dashCooldown;
        dashCount++;
    }
}
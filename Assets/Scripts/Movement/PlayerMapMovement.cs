using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMapMovement : MonoBehaviour
{
    private float speed = 1.25F;
    public Rigidbody2D rb;
    public GameObject sunObject;
    public ParticleSystem particleSystem;
    public TextMeshProUGUI coordinatesText;
    public TextMeshProUGUI sunDistanceText;
    public RectTransform miniMap;
    public ShipMono ShipMono;
    private bool isMoving = false;
    Vector2 movement;
    
    private InputActionMap playerActionMap;
    private InputAction UpKey;
    private InputAction DownKey;
    private InputAction RightKey;
    private InputAction LeftKey;

    private void Start()
    {
        playerActionMap = GetComponent<PlayerInput>().actions.FindActionMap("GSPlayer");
        UpKey = playerActionMap.FindAction("Up");
        DownKey = playerActionMap.FindAction("Down");
        RightKey = playerActionMap.FindAction("Right");
        LeftKey = playerActionMap.FindAction("Left");
    }
    void Update()
    {
        movement.y = 0;
        movement.x = 0;
        if (UpKey.ReadValue<float>() > 0 || DownKey.ReadValue<float>() > 0)
        {
            movement.y = Input.GetAxisRaw("Vertical");
        }

        if (LeftKey.ReadValue<float>() > 0 || RightKey.ReadValue<float>() > 0)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        }
  
        if (LeftKey.ReadValue<float>() > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            //miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 90);
           // miniMap.transform.Rotate(0, 0, 90);
        }
        if (RightKey.ReadValue<float>() > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 270);
           // miniMap.transform.Rotate(0, 0, 270);
        }
        if (UpKey.ReadValue<float>() > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (DownKey.ReadValue<float>() > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 180);
           //miniMap.transform.Rotate(0, 0, 180);
        }
        if (LeftKey.ReadValue<float>() > 0 && UpKey.ReadValue<float>() > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 45);
           // miniMap.transform.Rotate(0, 0, 45);
        }
        if (LeftKey.ReadValue<float>() > 0 && DownKey.ReadValue<float>() > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 145);
           // miniMap.transform.Rotate(0, 0, 145);
        }
        if (DownKey.ReadValue<float>() > 0 && RightKey.ReadValue<float>() > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 215);
           // miniMap.transform.Rotate(0, 0, 215);
        }
        if (UpKey.ReadValue<float>() > 0 && RightKey.ReadValue<float>() > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           // miniMap.transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(0, 0, 325);
           // miniMap.transform.Rotate(0, 0, 325);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 5f;
            //particleSystem.Play();
            particleSystem.maxParticles = 20000;
            //particleSystem.enableEmission = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;
            //particleSystem.Stop();
            particleSystem.maxParticles = 0;
            //StartCoroutine(ParticleDespawn());
        }

        if(Registry.profile.Ship.Data.fuel <= 0)
        {
            speed = 1.25f;
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Registry.profile.Ship.Data.fuel > 0)
            {
                Registry.profile.Ship.Data.fuel -= 0.7f;
            }
            else
            {
                Registry.profile.Ship.Data.fuel = 0;
            } 
        }
        coordinatesText.text = "X = " + rb.position.x + ", Y = " + rb.position.y;
        if (sunObject != null)
        {
            sunDistanceText.text = Registry.Language.sun_distance + Vector2.Distance(rb.position, sunObject.transform.position);
        }
        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
        }
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;
        }
        
        if (!isMoving)
        {
            GetComponent<Orbit>().speed = 0.15f;
            GetComponent<SelfRotation>().speed = 0.75f;
            if (ShipMono != null)
            {
                ShipMono.STATE = ShipState.IDLE;
            }
        } else if (isMoving)
        {
            GetComponent<Orbit>().speed = 0f;
            GetComponent<SelfRotation>().speed = 0f;
            if (ShipMono != null)
            {
                ShipMono.STATE = ShipState.FLIGHT;
            }
        }
    }
    
    void FixedUpdate()
    {
        //rb.AddRelativeForce(-rb.velocity);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}


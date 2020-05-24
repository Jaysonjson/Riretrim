using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMapMovement : MonoBehaviour
{
    private float speed = 1.75F;
    public Rigidbody2D rb;
    public GameObject sunObject;
    public ParticleSystem particleSystem;
    public TextMeshProUGUI coordinatesText;
    public TextMeshProUGUI sunDistanceText;
    public RectTransform miniMap;
    public float friction = 2f;
    private float __friction;
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
        __friction = friction;
    }
    void Update()
    {  
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
            speed = 7f;
            //particleSystem.Play();
            particleSystem.maxParticles = 20000;
            //particleSystem.enableEmission = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 1.75F;
            //particleSystem.Stop();
            particleSystem.maxParticles = 0;
            //StartCoroutine(ParticleDespawn());
        }

        if(Registry.profile.Ship.Data.fuel <= 0)
        {
            speed = 1.75F;
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
            sunDistanceText.text = Registry.Language.sun_distance + getDistanceToSun();
        }
        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
           // Debug.Log("Force!");
           // Debug.Log(transform.forward);
           // rb.AddForce(transform.forward * 2000, ForceMode2D.Force);
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
        rb.AddForce(transform.forward * 10000f, ForceMode2D.Impulse);
        /*  movement.y = 0;
          movement.x = 0;
          if (UpKey.ReadValue<float>() > 0 || DownKey.ReadValue<float>() > 0)
          {
              movement.y = Input.GetAxisRaw("Vertical");
          }

          if (LeftKey.ReadValue<float>() > 0 || RightKey.ReadValue<float>() > 0)
          {
              movement.x = Input.GetAxisRaw("Horizontal");
          }
          rb.velocity = movement * speed;
        */
        Vector3 movement = new Vector3();
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (isMoving)
        {
            friction = __friction; //* speed
        }
        else if (!isMoving)
        {
            if (friction > 0)
            {
                friction -= 0.0001f;
            }
        }
        //rb.velocity = friction * movement * speed;
        rb.velocity = movement * speed;
        // rb.AddForce(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public float getDistanceToSun()
    {
        return Vector2.Distance(rb.position, sunObject.transform.position);
    }
}


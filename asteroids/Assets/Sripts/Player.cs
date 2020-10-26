using Sripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    // TODO: change to load from resources
    public GameObject bulletPrefab;

    // component stuff
    private Animator animator;
    private Transform localTransform;

    // movement stuff
    private Vector2 direction = new Vector2(0f, 1f);
    private Vector2 engineVelocity = new Vector2(0f, 0f);
    private readonly Vector2 maxEngineVelocity = new Vector2(4.75f, 5.75f);
    private const float TurnSpeed = 230f;
    private const float EngineSpeed = 0.135f;

    // store inputs
    private float engineInput;
    private float turnInput;

    void Start()
    {
        animator = GetComponent<Animator>();
        localTransform = transform;
    }

    void Update()
    {
        engineInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Shoot"))
        {
            var bullet = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
            var bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Direction = direction;
        }

        animator.SetBool("isOn", engineInput != 0);
    }

    private void FixedUpdate()
    {
        // rotation part
        transform.Rotate(Vector3.back, turnInput * TurnSpeed * Time.deltaTime);
        var z = (localTransform.eulerAngles.z + 90f) * Mathf.Deg2Rad; // + 90 cause of start direction
        direction.x = Mathf.Cos(z);
        direction.y = Mathf.Sin(z);

        // add velocity
        if (engineInput != 0)
        {
            engineVelocity += direction * EngineSpeed;
        }
        else
        {
            engineVelocity *= new Vector2(0.985f, 0.985f);
        }

        // limit velocity
        engineVelocity.x = Mathf.Clamp(engineVelocity.x, -maxEngineVelocity.x, maxEngineVelocity.x);
        engineVelocity.y = Mathf.Clamp(engineVelocity.y, -maxEngineVelocity.y, maxEngineVelocity.y);
        // update position
        Vector2 pos = localTransform.position;
        pos += engineVelocity * Time.deltaTime;
        localTransform.position = pos;
        var o = gameObject;
        ScreenWrapper.Wrap(ref o);
    }
}
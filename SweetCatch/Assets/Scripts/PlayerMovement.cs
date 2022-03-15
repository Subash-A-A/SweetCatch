using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float speedMultiplier = 2f;
    [SerializeField] KeyCode SprintKey = KeyCode.LeftShift;

    private Rigidbody2D rb;

    // Input Vars
    private float horizontal;
    private bool isSprinting = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MyInput();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveDirection = new Vector3(moveSpeed * horizontal, 0f, 0f);
        Vector3 sprintDirection = new Vector3(moveSpeed * horizontal * speedMultiplier, 0f, 0f);
        rb.velocity = isSprinting ? sprintDirection : moveDirection;
    }

    void MyInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isSprinting = Input.GetKey(SprintKey);
    }

}

using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    float gravity = -9.15f;
    [SerializeField] Vector2 playerMovementInput = new Vector2(0, 0);
    float moveRotation = 0;
    float currentVelocity;
    [SerializeField] float speed;
    float maxSpeed = 15f;
    float minSpeed = 5f;
    Vector3 movement;



    [SerializeField] CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        movement.y += gravity * Time.deltaTime;

        controller.Move(movement * Time.deltaTime * speed);


        float rotation = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;

        moveRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, 0.05f);

        if (playerMovementInput.sqrMagnitude == 0) return;

        transform.rotation = Quaternion.Euler(0f, moveRotation, 0f);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        playerMovementInput = context.action.ReadValue<Vector2>();
        movement = Vector3.Lerp(movement, new Vector3(playerMovementInput.x, 0f, playerMovementInput.y), speed);
    }
}


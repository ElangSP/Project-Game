using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private InputActionReference moveActionReference;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void OnEnable()
    {
        if (moveActionReference != null && moveActionReference.action != null)
        {
            moveActionReference.action.Enable();
            moveActionReference.action.performed += OnMovePerformed;
            moveActionReference.action.canceled += OnMoveCanceled;
        }
        else
        {
            Debug.LogWarning("MoveActionReference belum di-assign di Inspector!");
        }
    }

    void OnDisable()
    {
        if (moveActionReference != null && moveActionReference.action != null)
        {
            moveActionReference.action.performed -= OnMovePerformed;
            moveActionReference.action.canceled -= OnMoveCanceled;
            moveActionReference.action.Disable();
        }
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }
}
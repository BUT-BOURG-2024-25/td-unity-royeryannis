using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference MovementAction = null;

    [SerializeField]
    private InputActionReference JumpAction = null;

    [SerializeField]
    private InputActionReference OnClick = null;


    public static InputManager Instance { get { return _instance; } }
    public static InputManager _instance = null;

    public Vector3 movementInput { get; private set; }

    public void RegisterOnJumpInput(Action<InputAction.CallbackContext> OnJumpAction)
    {
        JumpAction.action.performed += OnJumpAction;
    }

    public void UnRegisterOnJumpInput(Action<InputAction.CallbackContext> OnJumpAction)
    {
        JumpAction.action.performed -= OnJumpAction;
    }

    public void RegisterOnClick(Action<InputAction.CallbackContext> OnClickAction)
    {
        OnClick.action.performed += OnClickAction;
    }

    public void UnRegisterOnClick(Action<InputAction.CallbackContext> OnClickAction)
    {
        OnClick.action.performed -= OnClickAction;
    }




    private void Awake()
    {
        
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = MovementAction.action.ReadValue<Vector2>();
        movementInput = new Vector3(moveInput.x, 0, moveInput.y);
    }
}
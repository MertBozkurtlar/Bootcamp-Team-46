using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMovement : MonoBehaviour
{
    private MyInputs controls;

    private void Awake() {
        controls = new MyInputs();
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        controls.Combat.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        Debug.Log("Key Pressed");
    }
}

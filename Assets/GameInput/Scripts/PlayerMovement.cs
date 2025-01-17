using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    private Vector2 moveDirection = Vector2.zero; 
    public float moveSpeed = 2f; 
    
    private void Awake()
    {
        characterController = this.GetComponent<CharacterController>();
        Actions.MoveEvent += UpdateMoveVector;
    }
    // Update is called once per frame
    void Update()
    {
        HandlePlayerMovement(moveDirection); 
    }

    private void UpdateMoveVector(Vector2 InputVector)
    {
        moveDirection = InputVector;

    }

    public void HandlePlayerMovement(Vector2 moveDir) 
    {
        characterController.Move(moveDir * Time.deltaTime * moveSpeed);
    }

    /*private void OnEnable()
    {
        Actions.MoveEvent += HandlePlayerMovement;
        
    }
    */ 
    private void OnDisable()
    {
        Actions.MoveEvent -= HandlePlayerMovement; 
    }
}

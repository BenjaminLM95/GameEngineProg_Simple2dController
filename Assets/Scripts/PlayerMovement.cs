using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    private Vector2 moveDirection = new Vector2(0.00f, -1.00f);
    public float moveSpeed = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        characterController = this.GetComponent<CharacterController>(); 
    }

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandlePlayerMovement(Vector2 moveDir) 
    {
        characterController.Move(moveDir * Time.deltaTime * moveSpeed);
    }

    private void OnEnable()
    {
        Actions.MoveEvent += HandlePlayerMovement;
        
    }

    private void OnDisable()
    {
        Actions.MoveEvent -= HandlePlayerMovement; 
    }
}

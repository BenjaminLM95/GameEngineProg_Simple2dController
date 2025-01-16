using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{
    private GameInput gameInput; 

    void Awake() 
    {
        gameInput = new GameInput();
        gameInput.Player.Enable();
        gameInput.Player.SetCallbacks(this); 
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Receiving move Input : " + context.ReadValue<Vector2>());
        Actions.MoveEvent?.Invoke(context.ReadValue<Vector2>()); 
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {

        while(context.performed) 
        {
            Actions.GrowCircle?.Invoke();
            Debug.Log("GrowCircle"); 
        }
    }
}


public static class Actions
{
    public static Action<Vector2> MoveEvent;
    public static Action GrowCircle; 
    
}



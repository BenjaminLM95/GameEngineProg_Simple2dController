using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{
    private GameInput gameInput;
    private bool right; 

    void Awake() 
    {
        gameInput = new GameInput();
        gameInput.Player.Enable();
        gameInput.Player.SetCallbacks(this);
        right = true; 
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Receiving move Input : " + context.ReadValue<Vector2>());
        Actions.MoveEvent?.Invoke(context.ReadValue<Vector2>()); 
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {

        if(context.started) 
        {
            Actions.TargetingCowBoy?.Invoke(); 
        }

        if (context.performed) 
        {
            Actions.ChangeSprite?.Invoke();
            Debug.Log("ChangeSprite");

            Actions.GrowCircle?.Invoke();
            Debug.Log("GrowCircle");
        }


        if (context.canceled) 
        {            
            Actions.StopGrowing?.Invoke();

            if (right)
            {
                Actions.ChangeSprite?.Invoke();
                Debug.Log("ChangeSprite");
                right = false;
            }
            else
            {
                Actions.ReturnSprite?.Invoke();
                Debug.Log("ReturnSprite");
                right = true;
            }
        }
    }
}


public static class Actions
{
    public static Action<Vector2> MoveEvent;
    public static Action GrowCircle;
    public static Action StopGrowing; 
    public static Action ChangeSprite;
    public static Action ReturnSprite;
    public static Action TargetingCowBoy; 
    
}



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private const string GAMEINPUT_BINDINGS = "GameInputBindings";
    public event EventHandler OnInteraction;
    public event EventHandler OnOperateAction;
    public event EventHandler OnPauseAction;

    private GameControl gameControl;
    public enum BindingTypes
    {
        Up,
        Down,
        Left, 
        Right,
        Interact,
        Operate,
        Pause
    }
    private void Awake()
    {
        Instance = this;
        gameControl = new GameControl();
        if (PlayerPrefs.HasKey(GAMEINPUT_BINDINGS))
        {
            gameControl.LoadBindingOverridesFromJson(PlayerPrefs.GetString(GAMEINPUT_BINDINGS));
        }
        gameControl.Player.Enable();

        gameControl.Player.Interact.performed += Interact_Performed;
        gameControl.Player.Operate.performed += Operate_performed;
        gameControl.Player.Pause.performed += Pause_Performed;
    }
    public void ReBinding(BindingTypes bindingType, Action onComplete)
    {
        gameControl.Player.Disable();
        InputAction inputAction = null;
        int index = -1;
        switch (bindingType)
        {
            case BindingTypes.Up:
                index = 1;
                inputAction = gameControl.Player.Move;
                break;
            case BindingTypes.Down:
                index = 2;
                inputAction = gameControl.Player.Move;
                break;
            case BindingTypes.Left:
                index = 3;
                inputAction = gameControl.Player.Move;
                break;
            case BindingTypes.Right:
                index = 4;
                inputAction = gameControl.Player.Move;
                break;
            case BindingTypes.Interact:
                index = 0;
                inputAction = gameControl.Player.Interact;
                break;
            case BindingTypes.Operate:
                index = 0;
                inputAction = gameControl.Player.Operate;
                break;
            case BindingTypes.Pause:
                index = 0;
                inputAction = gameControl.Player.Pause;
                break;
            default:
                break;
        }
        inputAction.PerformInteractiveRebinding(index).OnComplete(callback =>
        {
            callback.Dispose();
            gameControl.Player.Enable();
            onComplete?.Invoke();

            PlayerPrefs.SetString(GAMEINPUT_BINDINGS,gameControl.SaveBindingOverridesAsJson());
            PlayerPrefs.Save();
        }).Start();
    }
    public string GetBingdingDisplayString(BindingTypes bindingType)
    {
        switch(bindingType)
        {
            case BindingTypes.Up:
                return gameControl.Player.Move.bindings[1].ToDisplayString();
            case BindingTypes.Down:
                return gameControl.Player.Move.bindings[2].ToDisplayString();
            case BindingTypes.Left:
                return gameControl.Player.Move.bindings[3].ToDisplayString();
            case BindingTypes.Right:
                return gameControl.Player.Move.bindings[4].ToDisplayString();
            case BindingTypes.Interact:
                return gameControl.Player.Interact.bindings[0].ToDisplayString();
            case BindingTypes.Operate:
                return gameControl.Player.Operate.bindings[0].ToDisplayString();
            case BindingTypes.Pause:
                return gameControl.Player.Pause.bindings[0].ToDisplayString();
            default:
                break;
        }
        return "";
    }
    
    //private void Start()
    //{
    //    print(gameControl.Player.Move.bindings[1].ToDisplayString());
    //    print(gameControl.Player.Move.bindings[2].ToDisplayString());
    //    print(gameControl.Player.Move.bindings[3].ToDisplayString());
    //    print(gameControl.Player.Move.bindings[4].ToDisplayString());

    //    print(gameControl.Player.Interact.bindings[0].ToDisplayString());

    //}
    private void OnDestroy()
    {
        gameControl.Player.Interact.performed -= Interact_Performed;
        gameControl.Player.Operate.performed -= Operate_performed;
        gameControl.Player.Pause.performed -= Pause_Performed;

        // 释放资源
        gameControl.Dispose();
    }
    private void Pause_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this,EventArgs.Empty);
    }
    private void Operate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOperateAction?.Invoke(this,EventArgs.Empty);
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteraction?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetMovementDirectionNormalized()
    {
        Vector2 inputVector2 =  gameControl.Player.Move.ReadValue<Vector2>();

        Vector3 direction = new Vector3(inputVector2.x, 0, inputVector2.y);

        direction = direction.normalized;// 单位化方向

        return direction;
    }
}

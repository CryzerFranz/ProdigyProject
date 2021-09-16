// GENERATED AUTOMATICALLY FROM 'Assets/Player/Controlls/TopDownPlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TopDownPlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TopDownPlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TopDownPlayerController"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""aacf29f4-101a-45eb-82d1-ec3185cada5d"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""64a4b826-a0df-4796-a02f-c0fd821e81b5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Execute"",
                    ""type"": ""Button"",
                    ""id"": ""b0db1480-ad88-42f6-984d-d1c7835804c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""8c43a121-4f04-48f7-9758-5a099792a9d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fb0f0d16-4f63-44c0-bdc2-a457430ea3cd"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42de8168-2408-4d07-8da3-6d3056109e4e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Execute"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1258f89c-f770-487a-b36c-47b868155837"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_MousePosition = m_Move.FindAction("MousePosition", throwIfNotFound: true);
        m_Move_Execute = m_Move.FindAction("Execute", throwIfNotFound: true);
        m_Move_Select = m_Move.FindAction("Select", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Move
    private readonly InputActionMap m_Move;
    private IMoveActions m_MoveActionsCallbackInterface;
    private readonly InputAction m_Move_MousePosition;
    private readonly InputAction m_Move_Execute;
    private readonly InputAction m_Move_Select;
    public struct MoveActions
    {
        private @TopDownPlayerController m_Wrapper;
        public MoveActions(@TopDownPlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Move_MousePosition;
        public InputAction @Execute => m_Wrapper.m_Move_Execute;
        public InputAction @Select => m_Wrapper.m_Move_Select;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void SetCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnMousePosition;
                @Execute.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnExecute;
                @Execute.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnExecute;
                @Execute.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnExecute;
                @Select.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_MoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Execute.started += instance.OnExecute;
                @Execute.performed += instance.OnExecute;
                @Execute.canceled += instance.OnExecute;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public MoveActions @Move => new MoveActions(this);
    public interface IMoveActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnExecute(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}

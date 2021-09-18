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
            ""name"": ""Movement"",
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
                    ""name"": ""Target"",
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
                    ""action"": ""Target"",
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
        },
        {
            ""name"": ""Combat"",
            ""id"": ""350ebd15-3fda-4bd3-a8d5-666385455a76"",
            ""actions"": [
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""4a68c889-d594-426e-b38f-00716d09aaf2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2a7ea6f6-7014-4367-8e17-876f3d951606"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_MousePosition = m_Movement.FindAction("MousePosition", throwIfNotFound: true);
        m_Movement_Target = m_Movement.FindAction("Target", throwIfNotFound: true);
        m_Movement_Select = m_Movement.FindAction("Select", throwIfNotFound: true);
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_Target = m_Combat.FindAction("Target", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_MousePosition;
    private readonly InputAction m_Movement_Target;
    private readonly InputAction m_Movement_Select;
    public struct MovementActions
    {
        private @TopDownPlayerController m_Wrapper;
        public MovementActions(@TopDownPlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Movement_MousePosition;
        public InputAction @Target => m_Wrapper.m_Movement_Target;
        public InputAction @Select => m_Wrapper.m_Movement_Select;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMousePosition;
                @Target.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnTarget;
                @Target.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnTarget;
                @Target.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnTarget;
                @Select.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Target.started += instance.OnTarget;
                @Target.performed += instance.OnTarget;
                @Target.canceled += instance.OnTarget;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Combat
    private readonly InputActionMap m_Combat;
    private ICombatActions m_CombatActionsCallbackInterface;
    private readonly InputAction m_Combat_Target;
    public struct CombatActions
    {
        private @TopDownPlayerController m_Wrapper;
        public CombatActions(@TopDownPlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Target => m_Wrapper.m_Combat_Target;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void SetCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterface != null)
            {
                @Target.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnTarget;
                @Target.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnTarget;
                @Target.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnTarget;
            }
            m_Wrapper.m_CombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Target.started += instance.OnTarget;
                @Target.performed += instance.OnTarget;
                @Target.canceled += instance.OnTarget;
            }
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    public interface IMovementActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnTarget(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface ICombatActions
    {
        void OnTarget(InputAction.CallbackContext context);
    }
}

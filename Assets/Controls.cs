// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""GSPlayer"",
            ""id"": ""9a8bdabd-62e7-486c-8dde-f1ba59540c1a"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""e6815a71-0ede-4de3-83c7-d55ffa560c97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""60ca5ad9-5730-4074-bbdd-6a5fd7654ca1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""f77fe549-4974-4c44-90f8-5b16dfe69b26"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""ba39b3d8-152a-4fb5-b6ab-18c836778ae9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""e7ed604d-f163-4c4a-b515-857b4db2e908"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d58e5b07-a9d9-43d5-974c-38587819d06e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5248769-96ee-4ac0-9740-cc64b3eb5e65"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76fd5bd8-a42d-4ca8-bdad-e8db6e458d27"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f603437e-7b1a-46d9-8183-1bf9fe7227c1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ac88852-16f4-450a-9977-2fddc2b7da6e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e40fd21-a96b-4978-9370-021e3611b647"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16fbded9-95eb-4e55-9f89-43e8a4e86c29"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b088fa4-b65a-4a2b-9ae9-a5b5c35cb942"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9842c1f-3fd4-4f1b-af2c-8bac4e50db4f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""325e363b-7d02-49cd-9fb5-27b164cb2ed4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ec09565-c216-408a-8fbd-84830e37ee4c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GSPlayer
        m_GSPlayer = asset.FindActionMap("GSPlayer", throwIfNotFound: true);
        m_GSPlayer_Shoot = m_GSPlayer.FindAction("Shoot", throwIfNotFound: true);
        m_GSPlayer_Left = m_GSPlayer.FindAction("Left", throwIfNotFound: true);
        m_GSPlayer_Right = m_GSPlayer.FindAction("Right", throwIfNotFound: true);
        m_GSPlayer_Down = m_GSPlayer.FindAction("Down", throwIfNotFound: true);
        m_GSPlayer_Up = m_GSPlayer.FindAction("Up", throwIfNotFound: true);
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

    // GSPlayer
    private readonly InputActionMap m_GSPlayer;
    private IGSPlayerActions m_GSPlayerActionsCallbackInterface;
    private readonly InputAction m_GSPlayer_Shoot;
    private readonly InputAction m_GSPlayer_Left;
    private readonly InputAction m_GSPlayer_Right;
    private readonly InputAction m_GSPlayer_Down;
    private readonly InputAction m_GSPlayer_Up;
    public struct GSPlayerActions
    {
        private @Controls m_Wrapper;
        public GSPlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_GSPlayer_Shoot;
        public InputAction @Left => m_Wrapper.m_GSPlayer_Left;
        public InputAction @Right => m_Wrapper.m_GSPlayer_Right;
        public InputAction @Down => m_Wrapper.m_GSPlayer_Down;
        public InputAction @Up => m_Wrapper.m_GSPlayer_Up;
        public InputActionMap Get() { return m_Wrapper.m_GSPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GSPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IGSPlayerActions instance)
        {
            if (m_Wrapper.m_GSPlayerActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnShoot;
                @Left.started -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnRight;
                @Down.started -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnDown;
                @Up.started -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_GSPlayerActionsCallbackInterface.OnUp;
            }
            m_Wrapper.m_GSPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
            }
        }
    }
    public GSPlayerActions @GSPlayer => new GSPlayerActions(this);
    public interface IGSPlayerActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
    }
}

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
                }
            ]
        },
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""317c5782-a4af-4a4d-8424-5e7191cacbc7"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""005da218-a6dd-4e8b-93eb-e302834344ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""773b71b1-f0db-4eb3-a92e-b6258f21f47e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""5bf28da0-5a0e-4230-aceb-0f373ecb04a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""d7a13058-66f0-4619-8a15-f72604666d59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e7d09b33-d057-443f-aee6-7b8d254383e6"",
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
                    ""id"": ""004fed99-025b-41f8-bd7b-829169f151e4"",
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
                    ""id"": ""1bc89ff3-07aa-41fb-86e6-5082b58229eb"",
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
                    ""id"": ""d90ae9c8-8e37-45c8-af49-9c160a67ea7e"",
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
                    ""id"": ""395db1a3-8dbe-4832-a0ca-23934ef845c0"",
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
                    ""id"": ""995b1788-2a1d-4752-ab1c-db682bffec02"",
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
                    ""id"": ""19bc992f-c653-437d-a204-005a072dd541"",
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
                    ""id"": ""9792db25-ea43-43b4-b9fc-ffa782a4823c"",
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
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Up = m_PlayerMovement.FindAction("Up", throwIfNotFound: true);
        m_PlayerMovement_Down = m_PlayerMovement.FindAction("Down", throwIfNotFound: true);
        m_PlayerMovement_Right = m_PlayerMovement.FindAction("Right", throwIfNotFound: true);
        m_PlayerMovement_Left = m_PlayerMovement.FindAction("Left", throwIfNotFound: true);
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
    public struct GSPlayerActions
    {
        private @Controls m_Wrapper;
        public GSPlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_GSPlayer_Shoot;
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
            }
            m_Wrapper.m_GSPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public GSPlayerActions @GSPlayer => new GSPlayerActions(this);

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Up;
    private readonly InputAction m_PlayerMovement_Down;
    private readonly InputAction m_PlayerMovement_Right;
    private readonly InputAction m_PlayerMovement_Left;
    public struct PlayerMovementActions
    {
        private @Controls m_Wrapper;
        public PlayerMovementActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_PlayerMovement_Up;
        public InputAction @Down => m_Wrapper.m_PlayerMovement_Down;
        public InputAction @Right => m_Wrapper.m_PlayerMovement_Right;
        public InputAction @Left => m_Wrapper.m_PlayerMovement_Left;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDown;
                @Right.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLeft;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);
    public interface IGSPlayerActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IPlayerMovementActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
    }
}

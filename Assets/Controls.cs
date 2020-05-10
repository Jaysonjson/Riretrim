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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GSPlayer
        m_GSPlayer = asset.FindActionMap("GSPlayer", throwIfNotFound: true);
        m_GSPlayer_Shoot = m_GSPlayer.FindAction("Shoot", throwIfNotFound: true);
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
    public interface IGSPlayerActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}

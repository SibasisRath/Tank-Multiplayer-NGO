//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerActionMap"",
            ""id"": ""66355b88-5b05-4298-b58b-db8112ebd1df"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9937af8b-060f-485b-bdd5-d33c7b65e21d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Primary Fire"",
                    ""type"": ""Button"",
                    ""id"": ""d93bf147-31ac-4a53-b369-e774f81d9eb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Value"",
                    ""id"": ""0574bc0e-0537-4af5-ad03-b67e1f4f1b9e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d01bc6ba-953c-4678-816a-721e84bdbbe7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Primary Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9279656d-2a10-4ec5-be56-eff9b10dab86"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Primary Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""15a857b5-66a0-431a-a2fb-60022aa6514c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""160e25dc-4163-4c47-a8a9-7401ecbcf11b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6c5b75cb-04b1-4800-9e21-276252741121"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f0050403-fa1a-47c3-a8a0-466918c98ca7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3638ab56-57b7-446b-89de-5c5986b50db7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""cf12e266-b7a9-4b9e-8bcd-43e3d8337afc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""882468c1-20f1-4732-9bae-01fe9c3bdd53"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f997a160-3f42-4775-85ab-6c2ef347c190"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""79ff4417-be68-4d7c-aa90-728c8d4b80a2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8fe9c11d-1b1e-45d5-a381-dfe68edc918c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""268f53ca-be8f-41f3-82e6-88e892a97d0b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and mouse"",
            ""bindingGroup"": ""Keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerActionMap
        m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
        m_PlayerActionMap_Move = m_PlayerActionMap.FindAction("Move", throwIfNotFound: true);
        m_PlayerActionMap_PrimaryFire = m_PlayerActionMap.FindAction("Primary Fire", throwIfNotFound: true);
        m_PlayerActionMap_Aiming = m_PlayerActionMap.FindAction("Aiming", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerActionMap
    private readonly InputActionMap m_PlayerActionMap;
    private List<IPlayerActionMapActions> m_PlayerActionMapActionsCallbackInterfaces = new List<IPlayerActionMapActions>();
    private readonly InputAction m_PlayerActionMap_Move;
    private readonly InputAction m_PlayerActionMap_PrimaryFire;
    private readonly InputAction m_PlayerActionMap_Aiming;
    public struct PlayerActionMapActions
    {
        private @Controls m_Wrapper;
        public PlayerActionMapActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerActionMap_Move;
        public InputAction @PrimaryFire => m_Wrapper.m_PlayerActionMap_PrimaryFire;
        public InputAction @Aiming => m_Wrapper.m_PlayerActionMap_Aiming;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @PrimaryFire.started += instance.OnPrimaryFire;
            @PrimaryFire.performed += instance.OnPrimaryFire;
            @PrimaryFire.canceled += instance.OnPrimaryFire;
            @Aiming.started += instance.OnAiming;
            @Aiming.performed += instance.OnAiming;
            @Aiming.canceled += instance.OnAiming;
        }

        private void UnregisterCallbacks(IPlayerActionMapActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @PrimaryFire.started -= instance.OnPrimaryFire;
            @PrimaryFire.performed -= instance.OnPrimaryFire;
            @PrimaryFire.canceled -= instance.OnPrimaryFire;
            @Aiming.started -= instance.OnAiming;
            @Aiming.performed -= instance.OnAiming;
            @Aiming.canceled -= instance.OnAiming;
        }

        public void RemoveCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActionMapActions @PlayerActionMap => new PlayerActionMapActions(this);
    private int m_KeyboardandmouseSchemeIndex = -1;
    public InputControlScheme KeyboardandmouseScheme
    {
        get
        {
            if (m_KeyboardandmouseSchemeIndex == -1) m_KeyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and mouse");
            return asset.controlSchemes[m_KeyboardandmouseSchemeIndex];
        }
    }
    public interface IPlayerActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPrimaryFire(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
    }
}

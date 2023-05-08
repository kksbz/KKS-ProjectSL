//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/KSM/PlayerInput.inputactions
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

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerCharacterInput"",
            ""id"": ""c01cd85b-a502-4d3d-bb53-51941eebf93b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f54f8b80-5bee-4d07-8b35-72d3c677a759"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""e36cd4a8-5b60-4622-8bbf-c2132d5fa1c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.5)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""c1701a09-fa87-4de0-ac75-e24e3048b20a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""ef9f9e2d-6ac1-497d-a193-b98a253a6e78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""bff61e09-510c-48fc-ad3b-6eeb9d643ced"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""40007d38-1b19-4773-a1bc-26a733c2746f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchArm"",
                    ""type"": ""Button"",
                    ""id"": ""2526e37b-3dcd-4a78-ab02-241ee4bae1a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseRecoveryItem"",
                    ""type"": ""Button"",
                    ""id"": ""964ac204-7a53-480b-aebb-08a2a5958fe2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5477230b-f714-4b20-aeb3-cc20b447f528"",
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
                    ""id"": ""fa05fa32-08ec-4ca3-8cbd-bb1b8056a27d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4fbfab75-3403-4e7b-bac7-c99e162508e1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""901685f1-adff-4c0f-ac56-be683ea92393"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""93d71626-af62-48cd-a5d9-16bec87b5f8d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""a74cc605-729f-4301-ace2-6ac34f46bf6a"",
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
                    ""id"": ""36284bb0-2d0c-4ca7-a705-8d29fcd77107"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5da10f76-06fb-4cc2-a290-3c513b751879"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ff917abb-7458-47e9-8b95-a2816a00abee"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9f56370d-22f7-4625-b81d-45c650bf4924"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""36559d6d-c8ef-41b8-b27e-4ab13973a1bc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""568cf64e-44ba-4f11-9687-ae11aa5da627"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""918ec703-7888-4f24-baac-9f1523f34025"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5e37f03-fc0f-4731-92c5-48b3fc76423c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc91e8f5-e4e5-4693-8ada-321c1c2e8957"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6503480-cfa4-45e9-8676-ed24a6d5485c"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""SwitchArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8a30235-a9f2-42b7-857e-55830ecc3f03"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""UseRecoveryItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UiInput"",
            ""id"": ""f5ad38c5-52aa-4631-8336-4615d7fc95c3"",
            ""actions"": [
                {
                    ""name"": ""ESC"",
                    ""type"": ""Button"",
                    ""id"": ""30cdc3f4-a4f3-4917-bbd8-526bfd0ef961"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NUM0"",
                    ""type"": ""Button"",
                    ""id"": ""05030b8b-c250-48a3-b1be-f2c06a46a1ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NUM1"",
                    ""type"": ""Button"",
                    ""id"": ""2fe214b3-c326-4b4c-986f-443e33603c13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f2c8beb9-361b-4e30-a781-60fe182499d5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ESC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""029946ea-61e2-4331-b091-a317432dd4ae"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NUM0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba9dd932-70c3-45ad-9d56-74d6e2957c58"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NUM1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
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
        // PlayerCharacterInput
        m_PlayerCharacterInput = asset.FindActionMap("PlayerCharacterInput", throwIfNotFound: true);
        m_PlayerCharacterInput_Move = m_PlayerCharacterInput.FindAction("Move", throwIfNotFound: true);
        m_PlayerCharacterInput_Run = m_PlayerCharacterInput.FindAction("Run", throwIfNotFound: true);
        m_PlayerCharacterInput_Walk = m_PlayerCharacterInput.FindAction("Walk", throwIfNotFound: true);
        m_PlayerCharacterInput_Attack = m_PlayerCharacterInput.FindAction("Attack", throwIfNotFound: true);
        m_PlayerCharacterInput_Guard = m_PlayerCharacterInput.FindAction("Guard", throwIfNotFound: true);
        m_PlayerCharacterInput_Dodge = m_PlayerCharacterInput.FindAction("Dodge", throwIfNotFound: true);
        m_PlayerCharacterInput_SwitchArm = m_PlayerCharacterInput.FindAction("SwitchArm", throwIfNotFound: true);
        m_PlayerCharacterInput_UseRecoveryItem = m_PlayerCharacterInput.FindAction("UseRecoveryItem", throwIfNotFound: true);
        // UiInput
        m_UiInput = asset.FindActionMap("UiInput", throwIfNotFound: true);
        m_UiInput_ESC = m_UiInput.FindAction("ESC", throwIfNotFound: true);
        m_UiInput_NUM0 = m_UiInput.FindAction("NUM0", throwIfNotFound: true);
        m_UiInput_NUM1 = m_UiInput.FindAction("NUM1", throwIfNotFound: true);
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

    // PlayerCharacterInput
    private readonly InputActionMap m_PlayerCharacterInput;
    private List<IPlayerCharacterInputActions> m_PlayerCharacterInputActionsCallbackInterfaces = new List<IPlayerCharacterInputActions>();
    private readonly InputAction m_PlayerCharacterInput_Move;
    private readonly InputAction m_PlayerCharacterInput_Run;
    private readonly InputAction m_PlayerCharacterInput_Walk;
    private readonly InputAction m_PlayerCharacterInput_Attack;
    private readonly InputAction m_PlayerCharacterInput_Guard;
    private readonly InputAction m_PlayerCharacterInput_Dodge;
    private readonly InputAction m_PlayerCharacterInput_SwitchArm;
    private readonly InputAction m_PlayerCharacterInput_UseRecoveryItem;
    public struct PlayerCharacterInputActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerCharacterInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerCharacterInput_Move;
        public InputAction @Run => m_Wrapper.m_PlayerCharacterInput_Run;
        public InputAction @Walk => m_Wrapper.m_PlayerCharacterInput_Walk;
        public InputAction @Attack => m_Wrapper.m_PlayerCharacterInput_Attack;
        public InputAction @Guard => m_Wrapper.m_PlayerCharacterInput_Guard;
        public InputAction @Dodge => m_Wrapper.m_PlayerCharacterInput_Dodge;
        public InputAction @SwitchArm => m_Wrapper.m_PlayerCharacterInput_SwitchArm;
        public InputAction @UseRecoveryItem => m_Wrapper.m_PlayerCharacterInput_UseRecoveryItem;
        public InputActionMap Get() { return m_Wrapper.m_PlayerCharacterInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerCharacterInputActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerCharacterInputActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerCharacterInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerCharacterInputActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
            @Walk.started += instance.OnWalk;
            @Walk.performed += instance.OnWalk;
            @Walk.canceled += instance.OnWalk;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Guard.started += instance.OnGuard;
            @Guard.performed += instance.OnGuard;
            @Guard.canceled += instance.OnGuard;
            @Dodge.started += instance.OnDodge;
            @Dodge.performed += instance.OnDodge;
            @Dodge.canceled += instance.OnDodge;
            @SwitchArm.started += instance.OnSwitchArm;
            @SwitchArm.performed += instance.OnSwitchArm;
            @SwitchArm.canceled += instance.OnSwitchArm;
            @UseRecoveryItem.started += instance.OnUseRecoveryItem;
            @UseRecoveryItem.performed += instance.OnUseRecoveryItem;
            @UseRecoveryItem.canceled += instance.OnUseRecoveryItem;
        }

        private void UnregisterCallbacks(IPlayerCharacterInputActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
            @Walk.started -= instance.OnWalk;
            @Walk.performed -= instance.OnWalk;
            @Walk.canceled -= instance.OnWalk;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Guard.started -= instance.OnGuard;
            @Guard.performed -= instance.OnGuard;
            @Guard.canceled -= instance.OnGuard;
            @Dodge.started -= instance.OnDodge;
            @Dodge.performed -= instance.OnDodge;
            @Dodge.canceled -= instance.OnDodge;
            @SwitchArm.started -= instance.OnSwitchArm;
            @SwitchArm.performed -= instance.OnSwitchArm;
            @SwitchArm.canceled -= instance.OnSwitchArm;
            @UseRecoveryItem.started -= instance.OnUseRecoveryItem;
            @UseRecoveryItem.performed -= instance.OnUseRecoveryItem;
            @UseRecoveryItem.canceled -= instance.OnUseRecoveryItem;
        }

        public void RemoveCallbacks(IPlayerCharacterInputActions instance)
        {
            if (m_Wrapper.m_PlayerCharacterInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerCharacterInputActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerCharacterInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerCharacterInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerCharacterInputActions @PlayerCharacterInput => new PlayerCharacterInputActions(this);

    // UiInput
    private readonly InputActionMap m_UiInput;
    private List<IUiInputActions> m_UiInputActionsCallbackInterfaces = new List<IUiInputActions>();
    private readonly InputAction m_UiInput_ESC;
    private readonly InputAction m_UiInput_NUM0;
    private readonly InputAction m_UiInput_NUM1;
    public struct UiInputActions
    {
        private @PlayerInput m_Wrapper;
        public UiInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ESC => m_Wrapper.m_UiInput_ESC;
        public InputAction @NUM0 => m_Wrapper.m_UiInput_NUM0;
        public InputAction @NUM1 => m_Wrapper.m_UiInput_NUM1;
        public InputActionMap Get() { return m_Wrapper.m_UiInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiInputActions set) { return set.Get(); }
        public void AddCallbacks(IUiInputActions instance)
        {
            if (instance == null || m_Wrapper.m_UiInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UiInputActionsCallbackInterfaces.Add(instance);
            @ESC.started += instance.OnESC;
            @ESC.performed += instance.OnESC;
            @ESC.canceled += instance.OnESC;
            @NUM0.started += instance.OnNUM0;
            @NUM0.performed += instance.OnNUM0;
            @NUM0.canceled += instance.OnNUM0;
            @NUM1.started += instance.OnNUM1;
            @NUM1.performed += instance.OnNUM1;
            @NUM1.canceled += instance.OnNUM1;
        }

        private void UnregisterCallbacks(IUiInputActions instance)
        {
            @ESC.started -= instance.OnESC;
            @ESC.performed -= instance.OnESC;
            @ESC.canceled -= instance.OnESC;
            @NUM0.started -= instance.OnNUM0;
            @NUM0.performed -= instance.OnNUM0;
            @NUM0.canceled -= instance.OnNUM0;
            @NUM1.started -= instance.OnNUM1;
            @NUM1.performed -= instance.OnNUM1;
            @NUM1.canceled -= instance.OnNUM1;
        }

        public void RemoveCallbacks(IUiInputActions instance)
        {
            if (m_Wrapper.m_UiInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUiInputActions instance)
        {
            foreach (var item in m_Wrapper.m_UiInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UiInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UiInputActions @UiInput => new UiInputActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IPlayerCharacterInputActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnGuard(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnSwitchArm(InputAction.CallbackContext context);
        void OnUseRecoveryItem(InputAction.CallbackContext context);
    }
    public interface IUiInputActions
    {
        void OnESC(InputAction.CallbackContext context);
        void OnNUM0(InputAction.CallbackContext context);
        void OnNUM1(InputAction.CallbackContext context);
    }
}

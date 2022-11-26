//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Player/Input/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Movements"",
            ""id"": ""36da15c7-a59b-4222-b0bf-244cf1df61b9"",
            ""actions"": [
                {
                    ""name"": ""Movements"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2d3d56d2-9243-495d-8bad-aaf6e2b33f24"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7fbedb87-c675-4c52-9646-1a35929b2565"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e93bd049-ad72-40b3-bf9b-165d6773ada9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""43688393-b379-4c42-9122-63c42d8279b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""IncrementAttackIndex"",
                    ""type"": ""Button"",
                    ""id"": ""95425e93-894e-4066-ba72-24f442100bb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""IncrementConstructionIndex"",
                    ""type"": ""Button"",
                    ""id"": ""6ed26440-6f3e-458b-984e-bc82b87967e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Construct"",
                    ""type"": ""Button"",
                    ""id"": ""117fc676-d59a-4b00-8757-bef604369d64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BlueprintAttack"",
                    ""type"": ""Button"",
                    ""id"": ""f1343aa1-04c7-478e-92e0-d5d1c05ebc45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ZQSD"",
                    ""id"": ""ef2202d0-9741-4b8a-b6ba-cac4268ea256"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""62bfae29-684f-46af-b5c7-e07fdadf7bc1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6fe67b55-0dcb-44cd-bfc3-47782e9a1adf"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b62c89e2-7d2e-41ce-899a-0737604500f7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5b550345-4c04-476e-b02a-9565fa6f586c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""5343489a-1476-4a59-85a3-ce36f52f1f0a"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""83c1d068-3c3c-4725-98a1-1608d32196cb"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ea69b47-7f12-412b-962e-bd8e4b54ce4b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b9b7c5bb-9585-4442-bab5-d6c6082de634"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e2c517ed-1642-4dbe-b0b8-a22fbd45791b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""19697326-5c9f-4fda-9c92-5d89e6eb2021"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""RightStick"",
                    ""id"": ""1966bac9-3bc9-41df-ac1c-fe2af54ca3a2"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fa6350c0-4554-4689-8615-e45e6a1e316e"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ef93b063-c702-48ea-9f74-31773d8ef84f"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ed8a3c55-acd4-49ad-be42-bbb9da13710f"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bfba6d12-31c3-4840-b75b-27386302b306"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9823cc5e-35f2-4650-bd32-bff00dd08a9a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32e6d2af-a0be-425b-bf83-e325d797300e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0784a48d-4d86-48ef-8725-aa851c6d8e90"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d1c5802-9d72-4ebf-ad06-4ffabdd6f1f5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""208c57da-74f0-4084-b3db-d138958b6029"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncrementAttackIndex"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ce40b19-f3f5-4a9c-a822-ee2307c6c509"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncrementAttackIndex"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2d7e8ec-3583-48c9-a778-a01498e3e1ca"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncrementConstructionIndex"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e235729-cbd5-4552-b2f8-fdee3fbc3a1d"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncrementConstructionIndex"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48b2ff15-0ddc-47d9-8214-cace0a51957b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Construct"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f0434ba-6ae6-47b1-bfca-f3bca554510b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Construct"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb2538e4-e8dd-4c97-9a8b-f559730eee36"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BlueprintAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movements
        m_PlayerMovements = asset.FindActionMap("Player Movements", throwIfNotFound: true);
        m_PlayerMovements_Movements = m_PlayerMovements.FindAction("Movements", throwIfNotFound: true);
        m_PlayerMovements_Camera = m_PlayerMovements.FindAction("Camera", throwIfNotFound: true);
        m_PlayerMovements_Jump = m_PlayerMovements.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovements_Attack = m_PlayerMovements.FindAction("Attack", throwIfNotFound: true);
        m_PlayerMovements_IncrementAttackIndex = m_PlayerMovements.FindAction("IncrementAttackIndex", throwIfNotFound: true);
        m_PlayerMovements_IncrementConstructionIndex = m_PlayerMovements.FindAction("IncrementConstructionIndex", throwIfNotFound: true);
        m_PlayerMovements_Construct = m_PlayerMovements.FindAction("Construct", throwIfNotFound: true);
        m_PlayerMovements_BlueprintAttack = m_PlayerMovements.FindAction("BlueprintAttack", throwIfNotFound: true);
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

    // Player Movements
    private readonly InputActionMap m_PlayerMovements;
    private IPlayerMovementsActions m_PlayerMovementsActionsCallbackInterface;
    private readonly InputAction m_PlayerMovements_Movements;
    private readonly InputAction m_PlayerMovements_Camera;
    private readonly InputAction m_PlayerMovements_Jump;
    private readonly InputAction m_PlayerMovements_Attack;
    private readonly InputAction m_PlayerMovements_IncrementAttackIndex;
    private readonly InputAction m_PlayerMovements_IncrementConstructionIndex;
    private readonly InputAction m_PlayerMovements_Construct;
    private readonly InputAction m_PlayerMovements_BlueprintAttack;
    public struct PlayerMovementsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movements => m_Wrapper.m_PlayerMovements_Movements;
        public InputAction @Camera => m_Wrapper.m_PlayerMovements_Camera;
        public InputAction @Jump => m_Wrapper.m_PlayerMovements_Jump;
        public InputAction @Attack => m_Wrapper.m_PlayerMovements_Attack;
        public InputAction @IncrementAttackIndex => m_Wrapper.m_PlayerMovements_IncrementAttackIndex;
        public InputAction @IncrementConstructionIndex => m_Wrapper.m_PlayerMovements_IncrementConstructionIndex;
        public InputAction @Construct => m_Wrapper.m_PlayerMovements_Construct;
        public InputAction @BlueprintAttack => m_Wrapper.m_PlayerMovements_BlueprintAttack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovements; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementsActions instance)
        {
            if (m_Wrapper.m_PlayerMovementsActionsCallbackInterface != null)
            {
                @Movements.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnMovements;
                @Movements.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnMovements;
                @Movements.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnMovements;
                @Camera.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnCamera;
                @Jump.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnAttack;
                @IncrementAttackIndex.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnIncrementAttackIndex;
                @IncrementAttackIndex.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnIncrementAttackIndex;
                @IncrementAttackIndex.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnIncrementAttackIndex;
                @IncrementConstructionIndex.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnIncrementConstructionIndex;
                @IncrementConstructionIndex.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnIncrementConstructionIndex;
                @IncrementConstructionIndex.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnIncrementConstructionIndex;
                @Construct.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnConstruct;
                @Construct.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnConstruct;
                @Construct.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnConstruct;
                @BlueprintAttack.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnBlueprintAttack;
                @BlueprintAttack.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnBlueprintAttack;
                @BlueprintAttack.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnBlueprintAttack;
            }
            m_Wrapper.m_PlayerMovementsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movements.started += instance.OnMovements;
                @Movements.performed += instance.OnMovements;
                @Movements.canceled += instance.OnMovements;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @IncrementAttackIndex.started += instance.OnIncrementAttackIndex;
                @IncrementAttackIndex.performed += instance.OnIncrementAttackIndex;
                @IncrementAttackIndex.canceled += instance.OnIncrementAttackIndex;
                @IncrementConstructionIndex.started += instance.OnIncrementConstructionIndex;
                @IncrementConstructionIndex.performed += instance.OnIncrementConstructionIndex;
                @IncrementConstructionIndex.canceled += instance.OnIncrementConstructionIndex;
                @Construct.started += instance.OnConstruct;
                @Construct.performed += instance.OnConstruct;
                @Construct.canceled += instance.OnConstruct;
                @BlueprintAttack.started += instance.OnBlueprintAttack;
                @BlueprintAttack.performed += instance.OnBlueprintAttack;
                @BlueprintAttack.canceled += instance.OnBlueprintAttack;
            }
        }
    }
    public PlayerMovementsActions @PlayerMovements => new PlayerMovementsActions(this);
    public interface IPlayerMovementsActions
    {
        void OnMovements(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnIncrementAttackIndex(InputAction.CallbackContext context);
        void OnIncrementConstructionIndex(InputAction.CallbackContext context);
        void OnConstruct(InputAction.CallbackContext context);
        void OnBlueprintAttack(InputAction.CallbackContext context);
    }
}

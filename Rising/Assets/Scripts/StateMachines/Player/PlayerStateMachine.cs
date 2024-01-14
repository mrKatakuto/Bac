using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // jeder kann es lesen aber es kann nicht gesetzt werden von �berall
    [field: SerializeField] public InputReader InputReader { get; private set; }

    [field: SerializeField] public CharacterController Controller { get; private set; }

    [field: SerializeField] public Animator Animator { get; private set; }

    [field: SerializeField] public Targeter  Targeter { get; private set; }

    [field: SerializeField] public ForceReceiver ForceReceiver {get;private set;}

    [field: SerializeField] public WeaponDamage Weapon {get;private set;}

    [field: SerializeField] public Health Health {get;private set;}

    [field: SerializeField] public Ragdoll Ragdoll {get;private set;}

    [field: SerializeField] public LedgeDetector LedgeDetector {get;private set;}

    [field: SerializeField] public float  FreeLookMovementSpeed { get; private set; }
    
    [field: SerializeField] public float  TargetingMovementSpeed { get; private set; }

    [field: SerializeField] public float  RotationDamping { get; private set; }

    [field: SerializeField] public float  DodgeDuration { get; private set; }

    [field: SerializeField] public float  DodgeLength { get; private set; }

    [field: SerializeField] public float  JumpForce { get; private set; }

    [field: SerializeField] public Attack[] Attacks { get; private set; }

    public Transform MainCameraTransform { get; private set; } 

    // Um den ersten dodge cooldown zu garantieren (Mathf.)
    public float PreviousDodgeTime {get; private set; } = Mathf.NegativeInfinity;

    void Start()
    {
        // Für cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerFreeLookState(this));
    }

        private void OnEnable() 
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    private void OnTakeDamage() 
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage() 
    {
        SwitchState(new PlayerImpactState(this));
    }

        private void HandleDie() 
    {
        SwitchState(new PlayerDeadState(this));
    }
}

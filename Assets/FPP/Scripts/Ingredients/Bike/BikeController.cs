using UnityEngine;
using FPP.Scripts.Enums;
using System.Collections;
using FPP.Scripts.Cameras;
using FPP.Scripts.Patterns;
using FPP.Scripts.Interfaces;
using FPP.Scripts.Controllers;
using System.Collections.Generic;
using FPP.Scripts.Ingredients.Bike.Engine;
using FPP.Scripts.Ingredients.Bike.Elements;

namespace FPP.Scripts.Ingredients.Bike
{
    public class BikeController : Subject, IBikeElement, IDamageable, IDestructible
    {
        public bool isTurboOn;
        public int currentRail;
        public int currentSpeed;
        private int _currentRail = 1;
        public BikeConfiguration bike;
        
        public BikeSensor BikeSensor { get; private set; }
        public BikeShield BikeShield { get; private set; }
        public BikeWeapon BikeWeapon { get; private set; }
        public BikeEngine BikeEngine { get; private set; }
        public FollowCamera FollowCamera { get; private set; }
        public TrackController TrackController { get; private set; }

        private GameObject _hud;
        private Animator _animator;
        private HUDController _hudController;
        private BikeStateContext _bikeStateContext;
        private readonly List<IBikeElement> _elements = new ();
        private IBikeState _turboState, _destroyState; // TODO: Deprecated state classes, to be removed
        
        void Awake()
        {
            InitBikeComponents();
            
            // TODO: The following states are deprecated, to remove
            _bikeStateContext = new BikeStateContext(this);
            _turboState = gameObject.AddComponent<TurboState>();
            _destroyState = gameObject.AddComponent<DestroyState>();
        }
        
        void OnEnable()
        {
            if (FollowCamera) Attach(FollowCamera);
            if (_hudController) Attach(_hudController);
            if (TrackController) Attach(TrackController);

            RaceEventBus.Subscribe(RaceEventType.FINISH, Brake);
            RaceEventBus.Subscribe(RaceEventType.START, StartBike);
            RaceEventBus.Subscribe(RaceEventType.RESTART, StopBike);
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StopBike);
        }

        void OnDisable()
        {
            if (FollowCamera) Detach(FollowCamera);
            if (_hudController) Detach(_hudController);
            if (TrackController) Detach(TrackController);

            RaceEventBus.Unsubscribe(RaceEventType.FINISH, Brake);
            RaceEventBus.Unsubscribe(RaceEventType.START, StartBike);
            RaceEventBus.Unsubscribe(RaceEventType.RESTART, StopBike);
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StopBike);
        }
        
        public void TakeDamage(float amount, DamageType type)
        {
            // TODO: Implement a damage state class and encapsulate the following code:
            if (type == DamageType.Laser)
                if (FollowCamera) 
                    FollowCamera.Distort();

            if (BikeShield) 
                if (BikeShield.Damage((int) type) <= 0)
                    Destruct();
            
            Notify();
        }
        
        public void Destruct()
        {
            _bikeStateContext.Transition(_destroyState);
        }

        private void InitBikeComponents()
        {
            BikeEngine = (BikeEngine) FindObjectOfType(typeof(BikeEngine));
            BikeShield = (BikeShield) FindObjectOfType(typeof(BikeShield));
            BikeWeapon = (BikeWeapon) FindObjectOfType(typeof(BikeWeapon));
            BikeSensor = (BikeSensor) FindObjectOfType(typeof(BikeSensor));
            FollowCamera = (FollowCamera) FindObjectOfType(typeof(FollowCamera));
            TrackController = (TrackController) FindObjectOfType(typeof(TrackController));
            
            _hud = Instantiate(Resources.Load("HUD", typeof(GameObject))) as GameObject;
            
            if (_hud) 
                _hudController = _hud.GetComponent<HUDController>();
            
            _elements.Add(BikeShield);
            _animator = gameObject.GetComponent<Animator>();
        }

        public void StartBike()
        {
            _animator.SetBool("isMoving", true);
        }

        public void StopBike()
        {
            _animator.SetBool("isMoving", false);
        }

        public void Brake()
        {
            _animator.SetTrigger("Brake");
        }

        public void ToggleTurbo()
        {
            _bikeStateContext.Transition(_turboState); // TODO: Deprecated state class, to be removed
        }

        public void Turn(BikeDirection direction)
        {
            if (direction == BikeDirection.Left)
            {
                if (_currentRail != 1) // TODO: Ask the TrackController for the minTrack
                {
                    _currentRail -= 1;
                    _animator.SetTrigger("TurnLeft");
                }
            }

            if (direction == BikeDirection.Right)
            {
                if (_currentRail != 4) // TODO: Ask the TrackController for the maxTrack
                {
                    _currentRail += 1;
                    _animator.SetTrigger("TurnRight");
                }
            }
        }
        
        public void Fire()
        {
            BikeWeapon.Fire();
            Notify();
        }
        
        public IEnumerator Turn(float duration, BikeDirection direction)
        {
            // TODO: The following transformation should be removed and handled by the animation system
            
            float time = 0;
            Vector3 startPosition = transform.position;
            Vector3 endPosition = new Vector3(startPosition.x + 1.5f * (int)direction, startPosition.y, startPosition.z);

            while (time < duration)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            
            transform.position = endPosition;
        }

        private void OnDestroy()
        {
            Destroy(_hud);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (IBikeElement element in _elements)
            {
                element.Accept(visitor);
            }
            
            Notify();
        }
    }
}
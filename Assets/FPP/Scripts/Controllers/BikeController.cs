using UnityEngine;
using FPP.Scripts.Enums;
using System.Collections;
using FPP.Scripts.Cameras;
using FPP.Scripts.Patterns;
using System.Collections.Generic;
using FPP.Scripts.Ingredients.Bike;
using FPP.Scripts.Ingredients.Bike.Engine;
using FPP.Scripts.Ingredients.Bike.Elements;

namespace FPP.Scripts.Controllers
{
    public class BikeController : Subject, IBikeElement
    {
        public bool isTurboOn;
        public int currentRail;
        public int currentSpeed;
        private int _currentRail = 1;
        public BikeConfiguration bike;
        
        public BikeSensor bikeSensor { get; private set; }
        public BikeShield bikeShield { get; private set; }
        public BikeWeapon bikeWeapon { get; private set; }
        public BikeEngine bikeEngine { get; private set; }

        public FollowCamera followCamera { get; private set; }
        public TrackController trackController { get; private set; }

        private GameObject _hud;
        private HUDController _hudController;
        private BikeStateContext _bikeStateContext;
        private readonly List<IBikeElement> _elements = new ();

        private Animator _animator;

        private IBikeState _brakeState, _stopState, _turboState, _destroyState;
        
        void Awake()
        {
            InitBikeComponents();
            
            _bikeStateContext = new BikeStateContext(this);
            
            _brakeState = gameObject.AddComponent<BrakeState>();
            _turboState = gameObject.AddComponent<TurboState>();
            _destroyState = gameObject.AddComponent<DestroyState>();
        }
        
        void OnEnable()
        {
            if (followCamera) Attach(followCamera);
            if (_hudController) Attach(_hudController);
            if (trackController) Attach(trackController);

            RaceEventBus.Subscribe(RaceEventType.FINISH, Brake);
            RaceEventBus.Subscribe(RaceEventType.START, StartBike);
            RaceEventBus.Subscribe(RaceEventType.RESTART, StopBike);
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StopBike);
        }

        void OnDisable()
        {
            if (followCamera) Detach(followCamera);
            if (_hudController) Detach(_hudController);
            if (trackController) Detach(trackController);

            RaceEventBus.Unsubscribe(RaceEventType.FINISH, Brake);
            RaceEventBus.Unsubscribe(RaceEventType.START, StartBike);
            RaceEventBus.Unsubscribe(RaceEventType.RESTART, StopBike);
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StopBike);
        }
        
        public void Damage(float amount, DamageType type) // TODO: Implement a DamageState
        {
            if (type == DamageType.Laser)
                if (followCamera) 
                    followCamera.Distort();

            if (bikeShield) 
                if (bikeShield.Damage((int) type) <= 0) 
                    _bikeStateContext.Transition(_destroyState);

            Notify();
        }

        private void InitBikeComponents()
        {
            bikeEngine = (BikeEngine) FindObjectOfType(typeof(BikeEngine));
            bikeShield = (BikeShield) FindObjectOfType(typeof(BikeShield));
            bikeWeapon = (BikeWeapon) FindObjectOfType(typeof(BikeWeapon));
            bikeSensor = (BikeSensor) FindObjectOfType(typeof(BikeSensor));
            followCamera = (FollowCamera) FindObjectOfType(typeof(FollowCamera));
            trackController = (TrackController) FindObjectOfType(typeof(TrackController));
            
            _hud = Instantiate(Resources.Load("HUD", typeof(GameObject))) as GameObject;
            
            if (_hud) 
                _hudController = _hud.GetComponent<HUDController>();
            
            _elements.Add(bikeShield);
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
            _bikeStateContext.Transition(_brakeState);
            _animator.SetBool("isMoving", false);
        }

        public void ToggleTurbo()
        {
            _bikeStateContext.Transition(_turboState);
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
            bikeWeapon.Fire();
            Notify();
        }
        
        public IEnumerator Turn(float duration, BikeDirection direction)
        {
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
using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.UI.HUD;
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
        public int currentRail; // TODO: Duplicate properties, to be removed

        private int _currentRail = 1; // TODO: The track controller should manage and return which track is active
        
        public BikeBlueprint bikeBlueprint;
        
        public int SpeedPenalty { private get; set; }
        public BikeSensor BikeSensor { get; private set; }
        public BikeShield BikeShield { get; private set; }
        public BikeWeapon BikeWeapon { get; private set; }
        public BikeEngine BikeEngine { get; private set; }
        public FollowCamera FollowCamera { get; private set; }
        public TrackController TrackController { get; private set; }
        
        public int CurrentSpeed {
            get
            {
                if (SpeedPenalty > 0 && SpeedPenalty < BikeEngine.CurrentSpeed)
                {
                    return BikeEngine.CurrentSpeed - SpeedPenalty;
                }
                else
                {
                    return BikeEngine.CurrentSpeed;
                }
            }
        }

        private GameObject _hud;
        private Animator _animator;
        private HUDController _hudController;
        private readonly List<IBikeElement> _elements = new ();

        void Awake()
        {
            InitBikeComponents();
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
        
        public void TakeDamage(float amount, DamageType type) // TODO: Implement a damage state class and encapsulate the following code:
        {
            SpeedPenalty = Mathf.RoundToInt(amount); // For this iteration, speed penalty is equal to the damage taken
            
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
            // TODO: Add destroy state
        }

        private void InitBikeComponents()
        {
            BikeEngine = (BikeEngine) FindObjectOfType(typeof(BikeEngine));
            
            if (BikeEngine)
                BikeEngine.BikeController = this; // TODO: To decouple
            
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
        
        public void ToggleTurbo()
        {
            _animator.SetTrigger("Turbo");
        }
        
        public void Brake()
        {
            _animator.SetTrigger("Brake");
        }


        public void Turn(BikeDirection direction) // TODO: The bike controller should ask the track controller for the next available track based on the direction it's moving, refactor this entire method
        {
            if (direction == BikeDirection.Left) 
            {
                if (_currentRail != 1) 
                {
                    _currentRail -= 1;
                    _animator.SetTrigger("TurnLeft");
                }
            }

            if (direction == BikeDirection.Right)
            {
                if (_currentRail != 4) 
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
        
        public IEnumerator Turn(float duration, BikeDirection direction) // TODO: The following transformation should be removed and handled by the animation system
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
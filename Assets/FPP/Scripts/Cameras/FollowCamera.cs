using UnityEngine;
using FPP.Scripts.Enums;
using System.Collections;
using FPP.Scripts.Patterns;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Cameras
{
    public class FollowCamera : Observer
    {
        private bool _isRotation;
        private int _currentDirection;
        
        [SerializeField] private CameraLaserHit cameraLaserHit;
        [SerializeField] private CameraTurboBlur cameraTurboBlur;
        
        private void ToggleTurboMode(bool isOn)
        {
            cameraTurboBlur.enabled = isOn;
        }

        public void Distort()
        {
            StartCoroutine(DistortCamera());
        }
        
        IEnumerator DistortCamera()
        {
            cameraLaserHit.enabled = true;
            yield return new WaitForSeconds(0.1f);
            cameraLaserHit.enabled = false;
        }

        public override void Notify(Subject subject)
        {
            BikeController controller = subject.GetComponent<BikeController>();
            if (controller)
                ToggleTurboMode(controller.BikeEngine.IsTurboOn);
        }
        
        public IEnumerator Turn(float duration, BikeDirection direction)
        {
            float time = 0;
            
            // Rotation
            Quaternion startRotation = transform.rotation;
            Vector3 targetRotation = new Vector3(0, 20.0f * (int)direction, 0);
            Quaternion endRotation = Quaternion.Euler(targetRotation);

            if (_currentDirection != (int) direction)
                _isRotation = true;
            else
                _isRotation = false;
            
            _currentDirection = (int)direction;
            
            // Position
            Vector3 startPosition = transform.position;

            Vector3 endPosition;
            
            if (_isRotation)
                endPosition = new Vector3(startPosition.x + 1.5f * -_currentDirection, startPosition.y, startPosition.z);
            else
                endPosition = new Vector3(startPosition.x + 1.5f * _currentDirection, startPosition.y, startPosition.z);
            
            while (time < duration)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, time / duration);
                
                if (_isRotation)
                {
                    transform.rotation = Quaternion.Lerp(startRotation, endRotation, time / duration);
                }

                time += Time.deltaTime;
                yield return null;
            }
            
            transform.position = endPosition;
        }
    }
}
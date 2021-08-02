using UnityEngine;
using System.Collections;
using FPP.Scripts.Controllers;

public class TurboState : MonoBehaviour, IBikeState
{
    private BikeController _bikeController;
    
    public void Handle(BikeController bikeController)
    {
        _bikeController = bikeController;
        _bikeController.isTurboOn = true;
        _bikeController.currentSpeed = _bikeController.currentSpeed + (_bikeController.currentSpeed * _bikeController.bike.turboBoost / 100);
        _bikeController.Notify();
        
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        int duration = _bikeController.bike.turboDuration;
        while (duration > 0)
        {
            yield return new WaitForSeconds(1.0f);
            duration--;
        }
        
        _bikeController.currentSpeed = _bikeController.bike.defaultSpeed;
        _bikeController.isTurboOn = false;
        _bikeController.Notify();
    }
}
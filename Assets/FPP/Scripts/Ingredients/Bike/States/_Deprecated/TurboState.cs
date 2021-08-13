using UnityEngine;
using System.Collections;
using FPP.Scripts.Ingredients.Bike;

public class TurboState : MonoBehaviour, IBikeState
{
    private BikeController _bikeController;
    
    public void Handle(BikeController bikeController)
    {
        _bikeController = bikeController;
        _bikeController.isTurboOn = true;
        _bikeController.currentSpeed = _bikeController.currentSpeed + (_bikeController.currentSpeed * _bikeController.bikeBlueprint.turboBoost / 100);
        _bikeController.Notify();
        
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        int duration = _bikeController.bikeBlueprint.turboDuration;
        while (duration > 0)
        {
            yield return new WaitForSeconds(1.0f);
            duration--;
        }
        
        _bikeController.currentSpeed = _bikeController.bikeBlueprint.defaultSpeed;
        _bikeController.isTurboOn = false;
        _bikeController.Notify();
    }
}
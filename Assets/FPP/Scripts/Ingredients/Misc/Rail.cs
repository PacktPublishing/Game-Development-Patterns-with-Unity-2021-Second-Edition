using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

public class Rail : MonoBehaviour
{
    [SerializeField] 
    private int railNumber;
    
    void OnTriggerEnter(Collider other)
    {

        if(other.GetComponent<BikeController>())
            other.GetComponent<BikeController>().currentRail = railNumber;
    } 
}

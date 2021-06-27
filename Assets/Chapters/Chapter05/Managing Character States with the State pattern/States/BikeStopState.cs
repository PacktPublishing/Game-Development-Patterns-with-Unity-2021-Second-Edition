using UnityEngine;

namespace Chapter.State
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController; 
        
        public void Handle(BikeController bikeController)
        {
            if (!_bikeController)
                _bikeController = bikeController;

            _bikeController.CurrentSpeed = 0;
        }
    }
}
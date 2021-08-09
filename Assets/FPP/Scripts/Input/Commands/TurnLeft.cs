using FPP.Scripts.Enums;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Input.Commands
{
    public class TurnLeft : Command
    {
        private BikeController _controller;

        public TurnLeft(BikeController controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            Command(_controller);
        }

        public override void Replay(BikeController controller)
        {
            Command(controller);
        }

        private void Command(BikeController controller)
        {
            controller.Turn(BikeDirection.Left);
        }
    }
}
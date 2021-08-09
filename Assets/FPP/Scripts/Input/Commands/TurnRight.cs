using FPP.Scripts.Enums;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Input.Commands
{
    public class TurnRight : Command
    {
        private BikeController _controller;

        public TurnRight(BikeController controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            _controller.Turn(BikeDirection.Right);
        }

        public override void Replay(BikeController controller)
        {
            controller.Turn(BikeDirection.Right);
        }

        private void Command(BikeController controller)
        {
            controller.Turn(BikeDirection.Right);
        }
    }
}
using FPP.Scripts.Controllers;

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
            _controller.Turn(BikeController.Direction.Right);
        }

        public override void Replay(BikeController controller)
        {
            controller.Turn(BikeController.Direction.Right);
        }

        private void Command(BikeController controller)
        {
            controller.Turn(BikeController.Direction.Right);
        }
    }
}
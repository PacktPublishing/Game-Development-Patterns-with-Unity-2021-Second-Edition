using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Input.Commands
{
    public class Fire : Command
    {
        private readonly BikeController _controller;

        public Fire(BikeController controller)
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
            controller.Fire();
        }
    }
}
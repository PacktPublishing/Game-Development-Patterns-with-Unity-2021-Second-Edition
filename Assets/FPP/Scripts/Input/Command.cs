using FPP.Scripts.Controllers;

namespace FPP.Scripts.Input
{
    public abstract class Command
    {
        public abstract void Execute();

        public abstract void Replay(BikeController controller);
    }
}
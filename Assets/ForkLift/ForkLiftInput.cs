namespace Virsign
{
    public class ForkLiftInput
    {
        public EventField<bool> IsIgnitionPressed = new();
        public EventField<float> Gas = new();
        public EventField<float> Steering = new();
        public EventField<bool> ForkUp = new();
        public EventField<bool> ForkDown = new();
    }
}
namespace Virsign
{
    public class ForkLiftInput
    {
        public EventField<bool> IsIgnitionPressed = new();
        public EventField<float> Gas = new();
        public EventField<float> Reverse = new();
        public EventField<float> Brake = new();
        public EventField<float> Steering = new();
        public EventField<float> ForkHeightDelta = new();

        public void Clear()
        {
            IsIgnitionPressed.SetValue(false);
            Gas.SetValue(0);
            Reverse.SetValue(0);
            Brake.SetValue(0);
            Steering.SetValue(0);
            ForkHeightDelta.SetValue(0);
        }
    }
}
namespace Virsign
{
    public class EngineInput
    {
        public EventField<bool> Start = new();
        public EventField<bool> TurnOff = new();
        public EventField<float> GasRatio = new();
    }
}
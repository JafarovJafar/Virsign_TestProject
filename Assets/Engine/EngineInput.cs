namespace Virsign
{
    public class EngineInput
    {
        public EventField<bool> IsRunning = new();
        public EventField<float> GasRatio = new();
    }
}
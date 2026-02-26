namespace Virsign
{
    internal class EngineContext
    {
        public EngineInput Input;
        public EngineStats Stats;
        public EventField<bool> IsRunning;
        public EventField<float> CurrentRpm;
    }
}
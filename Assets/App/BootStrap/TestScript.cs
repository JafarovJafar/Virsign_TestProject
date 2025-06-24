using UnityEngine;
using Virsign;

public class TestScript : MonoBehaviour
{
    [SerializeField] private ForkLift forkLift;
    [SerializeField] private ForkLiftKeyboardInputAdapter adapter;

    private void Start()
    {
        forkLift.Initialize();

        adapter.SetForkLift(forkLift);
        adapter.Activate();
    }
}
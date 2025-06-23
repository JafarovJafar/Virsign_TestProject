using UnityEngine;
using Virsign;

public class TestScript : MonoBehaviour
{
    [SerializeField] private ForkLift forkLift;

    private void Start()
    {
        forkLift.Initialize();
    }

    private void Update()
    {
        var input = forkLift.Input;

        input.IsIgnitionPressed.SetValue(Input.GetKey(KeyCode.T));

        #region Gas

        var gas = 0f;
        if (Input.GetKey(KeyCode.W))
            gas = 1f;
        else if (Input.GetKey(KeyCode.S))
            gas = -1f;

        input.Gas.SetValue(gas);

        #endregion

        #region Steering

        var steering = 0f;
        if (Input.GetKey(KeyCode.A))
            steering = -1f;
        else if (Input.GetKey(KeyCode.D))
            steering = 1f;

        input.Steering.SetValue(steering);

        #endregion

        #region Fork

        if (Input.GetKey(KeyCode.Q))
            forkLift.Input.ForkDown.SetValue(true);
        else
            forkLift.Input.ForkDown.SetValue(false);

        if (Input.GetKey(KeyCode.E))
            forkLift.Input.ForkUp.SetValue(true);
        else
            forkLift.Input.ForkUp.SetValue(false);

        #endregion
    }
}
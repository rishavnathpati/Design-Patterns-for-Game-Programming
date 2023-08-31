using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameObject activePlayer;
    private Animator _animator;
    private Command _keyJ, _keyP, _keyN, _keyK;

    private void Start()
    {
        _keyJ = new PerformJump();
        _keyP = new PerformPunch();
        _keyN = new DoNothing();
        _keyK = new PerformKick();
        _animator = activePlayer.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) _keyJ.Execute(_animator);
        else if (Input.GetKeyDown(KeyCode.W)) _keyP.Execute(_animator);
        else if (Input.GetKeyDown(KeyCode.E)) _keyN.Execute(_animator);
        else if (Input.GetKeyDown(KeyCode.R)) _keyK.Execute(_animator);
    }
}
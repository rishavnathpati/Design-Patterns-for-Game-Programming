using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject actor;
    private readonly List<Command> _oldCommandsList = new();
    private Animator _anim;
    private bool _isReplaying;
    private Command _keyQ, _keyW, _keyE, _upArrow;

    private Coroutine _replayCoroutine;
    private bool _shouldStartReplay;

    // Start is called before the first frame update
    private void Start()
    {
        _keyQ = new PerformJump();
        _keyW = new PerformKick();
        _keyE = new PerformPunch();
        _upArrow = new MoveForward();
        _anim = actor.GetComponent<Animator>();
        if (Camera.main != null) Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_isReplaying)
            HandleInput();
        StartReplay();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _keyQ.Execute(_anim, true);
            _oldCommandsList.Add(_keyQ);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _keyW.Execute(_anim, true);
            _oldCommandsList.Add(_keyW);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _keyE.Execute(_anim, true);
            _oldCommandsList.Add(_keyE);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _upArrow.Execute(_anim, true);
            _oldCommandsList.Add(_upArrow);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            _shouldStartReplay = true;

        if (Input.GetKeyDown(KeyCode.Z))
            UndoLastCommand();
    }

    private void UndoLastCommand()
    {
        if (_oldCommandsList.Count > 0)
        {
            var c = _oldCommandsList[^1];
            c.Execute(_anim, false);
            _oldCommandsList.RemoveAt(_oldCommandsList.Count - 1);
        }
    }

    private void StartReplay()
    {
        if (_shouldStartReplay && _oldCommandsList.Count > 0)
        {
            _shouldStartReplay = false;
            if (_replayCoroutine != null) StopCoroutine(_replayCoroutine);
            _replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    private IEnumerator ReplayCommands()
    {
        _isReplaying = true;

        foreach (var command in _oldCommandsList)
        {
            command.Execute(_anim, true);
            yield return new WaitForSeconds(1f);
        }

        _isReplaying = false;
    }
}
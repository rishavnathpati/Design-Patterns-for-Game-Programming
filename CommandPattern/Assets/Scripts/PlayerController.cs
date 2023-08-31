using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float RotationSpeed = 100.0f;
    private const float Speed = 2.0f;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsPunching = Animator.StringToHash("isPunching");
    private static readonly int IsKicking = Animator.StringToHash("isKicking");
    private Animator _anim;

    // Start is called before the first frame update
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        var translation = Input.GetAxis("Vertical") * Speed;
        var rotation = Input.GetAxis("Horizontal") * RotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            _anim.SetBool(IsWalking, false);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            _anim.SetBool(IsWalking, true);
            transform.Translate(0, 0, translation);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            _anim.SetBool(IsWalking, true);
            transform.Rotate(0, rotation, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            _anim.SetTrigger(IsJumping);
        else if (Input.GetKeyDown(KeyCode.P))
            _anim.SetTrigger(IsPunching);
        else if (Input.GetKeyDown(KeyCode.K))
            _anim.SetTrigger(IsKicking);
    }
}
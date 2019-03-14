using UnityEngine;

//The input management, character control and other simple behaviour are gathered in one class.
//Normally you would seperate this class into smaller components of e.g. MovementController, InputManager & WeaponSystem
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private int _playerNumber;

    public int PlayerNumber
    {
        get { return _playerNumber; }
    }

    public bool Ducking { get; private set; }
    public bool FacingRight { get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxJumps; //Actual amount of jumps is maxJumps + 1 atm
    [SerializeField] private float _sprintFactor;

    //These 4 are needed for ground checking
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private LayerMask _whatIsGround;
    private Transform _groundChecker;
    private bool _grounded;

    private Rigidbody2D _rb;
    private float _move;
    private bool _jump;
    private int _jumps;
    private bool _sprinting;
    private Animator _anim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        _groundChecker = transform.GetChild(1);
        //Check if the character is facing left
        FacingRight = transform.localScale.x != -1;
    }

    private void Update()
    {
        //Listening for input. Using player numbers to avoid creating individual scripts for each player.
        _move = Input.GetAxis("L_XAxis_" + _playerNumber);
        _jump = Input.GetButtonDown("A_" + _playerNumber);

        //Set ducking to true if player presses duck and we are on the ground
        Ducking = Input.GetAxisRaw("L_YAxis_" + _playerNumber) > 0 && _grounded ? true : false;
        if (Ducking) _move = 0;

        //Change value of movement if sprint key is pressed
        _move = Input.GetAxisRaw("TriggersR_" + _playerNumber) < 0 ? _move * _sprintFactor : _move;

        //Flipping the player depending on the direction of motion
        if (_move > 0 && !FacingRight) Flip();
        else if (_move < 0 && FacingRight) Flip();

        //Tell the animator if we are walking or ducking
        _anim.SetFloat("movement", Mathf.Abs(_move));
        _anim.SetBool("ducking", Ducking);

        //It's okay to jump in Update (change velocity) without deltaTime, because we are not adding force continiously.
        Jump();

        //Tell the animator if we are grounded
        _anim.SetBool("grounded", _grounded);

        //resets numbers of jumps when we are grounded
        if (_grounded) _jumps = _maxJumps;
    }

    private void FixedUpdate()
    {
        //One way to check if the characters are grounded. The layer mask decides what layers count as ground.
        _grounded = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);

        //move left or right
        _rb.velocity = new Vector2(_move * _speed, _rb.velocity.y);
    }

    private void Flip()
    {
        //Flipping the character by inverting the x-scale.
        FacingRight = !FacingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private void Jump()
    {
        //Check if jump is pressed and we if we have any jumps left
        if (!_jump || _jumps <= 0) return;
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        _jumps -= 1;
    }
}
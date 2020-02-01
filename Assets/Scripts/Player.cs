using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    Left, Right, Top, Bottom
}

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMovable
{
    public Vector2 lastVelocity;
    public Sprite DownSprite;
    public Sprite SideSprite;

    public Sprite UpSprite;

    public Buttons _buttons { get; set; }

    [SerializeField]
    private float _speed;
    public float Speed { get { return _speed; } set { _speed = value; } }

    public int ScrapCount { get; private set; } = 0;

    private new Rigidbody2D rigidbody;
    private Animator animator;

    public float magnetDistance = 3f;
    public float magnetStrength = 2f;

    public List<GameObject> scraps = new List<GameObject>();

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0f;
        //_healthManager = GetComponent<HealthManager>();
        _buttons = GameObject.Find("Engine").GetComponent<Buttons>();
        animator = gameObject.GetComponent<Animator>();
        animator.speed = 2;
        animator.Play("PlayerIdle");
        // TODO: animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseItems();
        }
    }

    public void UseItems()
    {
        var holes = GameObject.FindGameObjectsWithTag("Hole1");

        foreach (GameObject hole in holes) 
        {
            if (hole.GetComponent<Hole>().isPlayerStanding)
            {
                ScrapCount--;
                Debug.Log(ScrapCount);
                var scrap = scraps.First();
                scrap.GetComponent<Scrap>().StopRotating();
                scrap.transform.position = hole.transform.position;
                scrap.transform.parent = null;
                hole.GetComponent<Hole>().FillMyself(scrap);
                hole.GetComponent<Hole>().DealDamage();
                scraps.Remove(scrap);
            }
        }
    }

    public void Move()
    {
        var verticalSpeed = _buttons.VerticalAxis;
        var horizontalSpeed = _buttons.HorizontalAxis;

        animator.SetBool("IsMovingUp", false);
        animator.SetBool("IsMovingDown", false);
        animator.SetBool("IsMovingToSides", false);
    

        if (Math.Abs(horizontalSpeed) > Math.Abs(verticalSpeed) && horizontalSpeed > 0)
        {
            GetComponent<SpriteRenderer>().sprite = SideSprite;
            animator.SetBool("IsMovingToSides", true);
            FlipRight();
        }

        if (Math.Abs(horizontalSpeed) > Math.Abs(verticalSpeed) && horizontalSpeed < 0)
        {
            GetComponent<SpriteRenderer>().sprite = SideSprite;
            animator.SetBool("IsMovingToSides", true);
            FlipLeft();
        }

        if (Math.Abs(horizontalSpeed) < Math.Abs(verticalSpeed) && verticalSpeed > 0)
        {
            FlipTop();
            animator.SetBool("IsMovingUp", true);
        }

        if (Math.Abs(horizontalSpeed) < Math.Abs(verticalSpeed) && verticalSpeed < 0)
        {
            FlipBottom();
            animator.SetBool("IsMovingDown", true);
        }

        if (horizontalSpeed == 0 && verticalSpeed == 0)
        {
            var footsteps = gameObject.transform.Find("Footsteps").GetComponent<AudioSource>();
            if (footsteps.isPlaying)
            {
                footsteps.GetComponent<AudioSource>().Stop();
            }
        }
        else
        {
            var footsteps = gameObject.transform.Find("Footsteps").GetComponent<AudioSource>();
            if (!footsteps.isPlaying)
            {
                footsteps.GetComponent<AudioSource>().Play();
            }
        }
        if ((horizontalSpeed > 0.1 || horizontalSpeed < -0.1) && (verticalSpeed > 0.1 || verticalSpeed < -0.1))
        {
            lastVelocity = new Vector2(horizontalSpeed, verticalSpeed);
        }
        rigidbody.velocity = new Vector2(horizontalSpeed * Speed, verticalSpeed * Speed);
    }

    private void FlipLeft()
    {
        GetComponent<SpriteRenderer>().flipY = false;
        GetComponent<SpriteRenderer>().flipX = true;
    }

    private void FlipRight()
    {
        GetComponent<SpriteRenderer>().flipX = false;
        GetComponent<SpriteRenderer>().flipY = false;
    }

    private void FlipTop()
    {
        GetComponent<SpriteRenderer>().sprite = UpSprite;
        GetComponent<SpriteRenderer>().flipY = false;
    }

    private void FlipBottom()
    {
        GetComponent<SpriteRenderer>().sprite = DownSprite;
        GetComponent<SpriteRenderer>().flipY = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Scrap" && other.transform.parent != transform)
        {
            scraps.Add(other.gameObject);
            other.transform.parent = transform;
            var scrap = other.transform.GetComponent<Scrap>();
            scrap?.StopFollowing();
            scrap?.StartRotatingAroundPlayer();
            ScrapCount++;
            Debug.Log(ScrapCount);
        }
    }
}


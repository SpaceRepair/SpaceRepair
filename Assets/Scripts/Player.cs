using System.Collections;
using System;

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
    public GameObject PowerUp;
    public GameObject SkillPrefab;
    public Sprite DownSprite;
    public Sprite SideSprite;

    public Sprite UpSprite;

    public Buttons _buttons { get; set; }

    [SerializeField]
    private float _speed;
    public float Speed { get { return _speed; } set { _speed = value; } }


    private new Rigidbody2D rigidbody;
    private Animator animator;

    public GameObject Mama = null;

    public bool canShoot = true;
    public float activeTime = 0.025f;

    public void Shoot()
    {
        // if (SkillPrefab != null && canShoot)
        // {

        //     GameObject actualProjectile = Instantiate(SkillPrefab, transform.position, transform.rotation);
        //     Skill skillScript = actualProjectile.GetComponent<Skill>();
        //     skillScript.direction = lastVelocity;

        //     RemoveActive();
        //     canShoot = false;
        //     StartCoroutine(ActivateAgain());
        // }
    }

    public void RemoveActiveSkill()
    {
        SkillPrefab = null;
        var powerImage = GameObject.Find("Power1Button").GetComponent<Image>();
        var tempColor = powerImage.color;
        tempColor.a = 0;
        powerImage.color = tempColor;
    }

    public IEnumerator ActivateAgain()
    {
        yield return new WaitForSeconds(activeTime);
        canShoot = true;
    }


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0f;
        //_healthManager = GetComponent<HealthManager>();
        _buttons = GameObject.Find("Engine").GetComponent<Buttons>();
        // TODO: animator = GetComponent<Animator>();
    }


    private void Update()
    {
        Move();
        CheckForShooting();
    }

    private void CheckForShooting()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("x"))
        {
            Shoot();
        }
    }

    public void Move()
    {
        var verticalSpeed = _buttons.VerticalAxis;
        var horizontalSpeed = _buttons.HorizontalAxis;

        if (verticalSpeed == 0)
        {
            // TODO: animator.SetBool("Walking", false);
        }

        if (Math.Abs(horizontalSpeed) > Math.Abs(verticalSpeed) && horizontalSpeed > 0)
        {
            GetComponent<SpriteRenderer>().sprite = SideSprite;
            // TODO: animator.SetBool("Walking", true);
            FlipRight();
        }

        if (Math.Abs(horizontalSpeed) > Math.Abs(verticalSpeed) && horizontalSpeed < 0)
        {
            GetComponent<SpriteRenderer>().sprite = SideSprite;
            // TODO: animator.SetBool("Walking", true);
            FlipLeft();
        }

        if (Math.Abs(horizontalSpeed) < Math.Abs(verticalSpeed) && verticalSpeed > 0)
        {
            FlipTop();
            // TODO: animator.SetBool("Walking", true);
        }

        if (Math.Abs(horizontalSpeed) < Math.Abs(verticalSpeed) && verticalSpeed < 0)
        {
            FlipBottom();
            // TODO: animator.SetBool("Walking", true);
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
        if (other.gameObject.tag == "Mama")
        {
            // TODO: Animation/sound
            Destroy(other.gameObject);
            //GameObject.Find("Engine").GetComponent<Darkness>().StartDarkening();
            //DecreaseHP();
        }
    }

    public void DecreaseHP()
    {
        // TODO: _healthManager.DealDamage(HealthObjectType.Health, 1);
    }

    public void IncreaseHP(int count)
    {
        // TODO: _healthManager.AddHealth(HealthObjectType.Health, 1);
    }


    public void GiveSkill(GameObject newSkill)
    {
        // gameObject.GetComponent<AudioSource>().Play();
        // SkillPrefab = newSkill;
        // var powerImage = GameObject.Find("Power1Button").GetComponent<Image>();
        // powerImage.sprite = newSkill.GetComponent<Skill>().UISprite;
        // var tempColor = powerImage.color;
        // tempColor.a = 1;
        // powerImage.color = tempColor;

    }

    public bool HasSkill()
    {
        return SkillPrefab != null;
    }
}


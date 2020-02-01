using System;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    private bool shouldFollowPlayer = true;
    public float minDistance = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFollowPlayer)
        {
            HoverToPlayer();
        }
        else
        {
            transform.RotateAround(transform.parent.position, Vector3.forward, 30 * Time.deltaTime);
        }
    }

    public void StopFollowing()
    {
        shouldFollowPlayer = false;
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<Collider2D>());
        //GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void HoverToPlayer()
    {
        // Calculate player distance
        var player = GameObject.Find("Player").GetComponent<Player>();
        var playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
        var scrapCollider = gameObject.GetComponent<Collider2D>();
        float distance = Vector2.Distance(playerCollider.transform.position, scrapCollider.transform.position);
        //Debug.Log($"Distance: {distance}");

        var scrapRigidbody = GetComponent<Rigidbody2D>();
        // Compare player.magnetStrength to distance
        // if distance smaller 
        if (distance < player.magnetDistance)
        {
            var xDistance = playerCollider.transform.position.x  - scrapCollider.transform.position.x;
            if (xDistance > player.magnetDistance) xDistance = player.magnetDistance;
            var xDirection = player.magnetDistance / xDistance;
            if (Math.Abs(xDistance) < minDistance) xDirection = 0f;
            // Debug.Log($"xDistance: {xDistance}");
            // Debug.Log($"xDirection: {xDirection}");

            var yDistance = playerCollider.transform.position.y  - scrapCollider.transform.position.y;
            if (yDistance > player.magnetDistance) yDistance = player.magnetDistance;
            var yDirection = player.magnetDistance / yDistance;
            if (Math.Abs(yDistance) < minDistance) yDirection = 0f;
            // Debug.Log($"yDistance: {yDistance}");
            // Debug.Log($"yDirection: {yDirection}");
            //  set velocity
            scrapRigidbody.velocity =
                new Vector2(player.magnetStrength * xDirection, player.magnetStrength * yDistance);
        }
        else 
        {
            // if distance bigger velocity 0
            //scrapRigidbody.velocity = new Vector2(0, 0);
        }
        if (distance < minDistance)
        {
            scrapRigidbody.velocity = new Vector2(0, 0);
        }
    }
}

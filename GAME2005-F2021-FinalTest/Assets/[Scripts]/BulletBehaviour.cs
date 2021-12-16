using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float range;
    public Vector3 max;
    public Vector3 min;
    public bool debug;
    public bool isColliding;
    public Vector3 collisionNormal;
    public float penetration;
    public Bounds bounds;


    public BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        isColliding = false;
        max = Vector3.Scale(bounds.max, transform.localScale) + transform.position;
        min = Vector3.Scale(bounds.min, transform.localScale) + transform.position;

        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > range)
        {
            bulletManager.ReturnBullet(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = Color.magenta;

            Gizmos.DrawWireCube(transform.position, max);
        }
    }
}

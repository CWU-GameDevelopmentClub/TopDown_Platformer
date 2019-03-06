using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public float damage;
    public float knockBackForce;
    public float attackTime;
    public KeyCode attack;
    private BoxCollider attackBox;
    Vector3 direction;

    public Color attackColor;
    private Color defaultColor;

    public SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        attackBox = GetComponent<BoxCollider>();
        defaultColor = sr.color;
    }

    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attack))
        {
            attackBox.enabled = true;
        }

        if (attackBox.enabled)
        {
            timer += Time.deltaTime;
            sr.color = attackColor;
            if (timer > attackTime)
            {
                attackBox.enabled = false;
                timer = 0;
                sr.color = defaultColor;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Health hp = collision.GetComponent<Health>();
        if (hp == null)
            return;
        else
        {
            hp.TakeDamage(damage);
        }

        Rigidbody rb = collision.GetComponent<Rigidbody>();
        if (rb == null)
            return;
        else
        {
            direction = (collision.transform.position - this.transform.position).normalized;
            rb.AddForce(new Vector3(direction.x, direction.y, direction.z) * knockBackForce, ForceMode.Impulse);
        }

    }

    public void DoAttack()
    {
        attackBox.enabled = true;
    }
}
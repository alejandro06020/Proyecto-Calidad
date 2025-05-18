using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] public float eSpeed = 6.0f;
    Rigidbody2D rigidbody2D;
    public bool vertical;
    public float changeTime = 2.0f;
    float timer;
    int direction = 1;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }


    void Update()
    {
        timer  -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
     
        if (vertical)
        {
           position.y = position.y + eSpeed * direction * Time.deltaTime;
        }
        else
        {
           position.x = position.x + eSpeed * direction * Time.deltaTime;
        }


        rigidbody2D.MovePosition(position);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if(player!=null){
            player.changeLife(-1);
        }
    }
}

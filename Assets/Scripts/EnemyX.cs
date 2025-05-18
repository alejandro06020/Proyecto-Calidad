using UnityEngine;

public class EnemyX : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] float speed=3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position + (speed*Time.deltaTime*new Vector2(-1,0));
        if(rigidbody2D.position.x<-15){
            Destroy(gameObject);
        }else{
            rigidbody2D.MovePosition(position);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if(controller!=null){
            Debug.Log("El enemigo toco al jugador");
            controller.changeLife(-1);
            Destroy(gameObject);
        }
    }
}

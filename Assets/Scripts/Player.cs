using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rd;


    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPos.x < 0)
            {
                rd.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rd.AddForce(Vector2.right * moveSpeed);
            }

        }
        else
        {
            rd.linearVelocity = Vector2.zero;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

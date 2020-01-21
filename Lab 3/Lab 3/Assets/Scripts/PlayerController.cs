using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horInput;
    private float verInput;
    public float speed = 10f;
    private Rigidbody rb;
    public float zBound = 7.5f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        ConstrainPlayer();
    }

    void MovePlayer()
    {
        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horInput, 0, verInput) * Time.deltaTime * speed);
        //rb.AddForce(Vector3.forward * speed * verInput);
        //rb.AddForce(Vector3.right * speed * horInput);
    }

    void ConstrainPlayer()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }
}

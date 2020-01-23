using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private GameObject focalPoint;
    public float speed = 5f;
    public bool hasPowerup = false;
    public float powerUpStrength = 15f;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
        focalPoint = GameObject.Find ("Focal Point");
    }

    // Update is called once per frame
    void Update () {
        float forwardInput = Input.GetAxis ("Vertical");
        //rb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        rb.velocity = focalPoint.transform.forward * forwardInput * speed;
        powerUpIndicator.transform.position = transform.position + new Vector3 (0, -0.5f, 0);
    }

    private void OnTriggerEnter (Collider other) {
        if (other.CompareTag ("Powerup")) {
            powerUpIndicator.gameObject.SetActive (true);
            hasPowerup = true;
            Destroy (other.gameObject);
            StartCoroutine (PowerupCoutdownRoutine ());
        }
    }

    IEnumerator PowerupCoutdownRoutine () {
        yield return new WaitForSeconds (5);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive (false);
    }

    private void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.CompareTag ("Enemy") && hasPowerup) {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody> ();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce (awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log ("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
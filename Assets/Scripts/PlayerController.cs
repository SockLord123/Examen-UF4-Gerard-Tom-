using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public string name;
    public float speed;
    public float rotationSpeed;
    public float life;  
    public int Score;
    public float impulse;
    public float time;
    public float maxLife;
    public Text scoreText;
    public Text timeText;
    public Image barraDeVida;

    public AudioSource CoinSource;
    
    public GameObject door;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola " + name);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        scoreText.text = "Score: " + Score; // Update score display
        int timeRounded = Mathf.RoundToInt(time); // Corrected line
        timeText.text = "Time: " + timeRounded.ToString(); // Update time display

        barraDeVida.fillAmount = life / maxLife;

        float barraVida = life / maxLife;
        if (barraVida > 0.5f)
        {
            barraDeVida.color = Color.green;
        }
        else if (barraVida > 0.2f) // Corrected line
        {
            barraDeVida.color = Color.yellow;
        }
        else 
        {
            barraDeVida.color = Color.red;
        }

        time -= Time.deltaTime;

        if (life <= 0 || time <= 0)
        {
            SceneManager.LoadScene("Test");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 40.2f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 40.2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f) 
        {
            rb.velocity = new Vector3(0, impulse, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ENEMY"))
        {
            life -= 3f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("COIN"))
        {
            Score++;
            CoinSource.Play();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("POTION"))
        {
            life++;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("DEATHPLATAFORM"))
        {
            SceneManager.LoadScene("Test");
        }
        if (other.CompareTag("Key"))
        {
            Destroy(door); // Ensure 'door' is assigned in the Inspector
        }
    }
}
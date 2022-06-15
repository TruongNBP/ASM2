using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class diChuyen : MonoBehaviour
{
    public Animator ani;
    public GameObject gameOverText;
    public GameObject gameOverButton;
    public bool isPause = false;
    public AudioSource soundDie;
    public AudioSource soundMain;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        soundMain.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ani.SetBool("isRunning", true);
            ani.Play("Running");
            transform.Translate(Time.deltaTime * 5, 0, 0);
            transform.localScale = new Vector3(1F, 1F, 1F);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            ani.SetBool("isRunning", true);
            ani.Play("Running");
            transform.Translate(-Time.deltaTime * 5, 0, 0);
            transform.localScale = new Vector3(-1F, 1F, 1F);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, Time.deltaTime * 11, 0);
        }
        else
        {
            ani.SetBool("isRunning", false);
        }
        if(Input.GetKey(KeyCode.P))
        {
            isPause = !isPause;
            if (isPause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "quaMan")
        {
            SceneManager.LoadScene("zfinish");
        }
        if(collision.gameObject.tag == "roiXuong")
        {
            gameOverButton.SetActive(true);
            gameOverText.SetActive(true);
            Time.timeScale = 0;
            Destroy(GameObject.Find("1x_0"));
            soundDie.Play();
            soundMain.Stop();
        }
    }
}

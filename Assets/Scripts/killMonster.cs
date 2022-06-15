using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killMonster : MonoBehaviour
{
    // Start is called before the first frame update
    public static int diemTong = 0;
    public GameObject diemText;
    void Start()
    {
        congDiem(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void congDiem(int diemCong)
    {
        diemTong += diemCong;
        diemText.GetComponent<Text>().text = diemTong.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "benTrai")
        {
            Destroy(GameObject.Find("1x_0"));
        }
        string nameCoin = collision.attachedRigidbody.gameObject.name;
        if (collision.gameObject.tag == "coinne")
        {
            Destroy(GameObject.Find(nameCoin));
            congDiem(1);
        }
    }
}

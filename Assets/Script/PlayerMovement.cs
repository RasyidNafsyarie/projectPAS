using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [Header("config")]
    [SerializeField] private float movespeed = 200f;

    Rigidbody _rigidbody;

    public Text hitungText;
    public Text WinText;
    private int hitung;

     void Start()
    {
        hitung = 0;
        SetHitungText();
        WinText.text = "";
    }


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(hAxis, 0f, vAxis);
        if (_rigidbody)
            _rigidbody.AddForce((moveDir * movespeed) * Time.deltaTime);
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            hitung = hitung + 1;


            SetHitungText();
        }
    }

    void SetHitungText()
    {
        hitungText.text = "Jumlah Kubus: " + hitung.ToString();
        if(hitung >= 13)
        {
            WinText.text = "Kamu Menang!";
        }
    }
}

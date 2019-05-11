using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rd2;
    public String _type;
    private String[] _types;
    //public GameObject[] _friendsPlayer;
    private int _currentPlayer;
    public bool isGround;
    public float speedSpace;
    public float speedMove;
    public CameraController cameraController;
    public float minSpeedX;
    public float maxSpeedX;
    public bool winPosition;
    public GameObject exitObject;
    private Vector2 temp;
    
    
    void Start()
    {
        _types = new String[3];
        _types[0] = "Claire";
        _types[1] = "Thomas";
        _types[2] = "John";
        _currentPlayer = 0;
        isGround = true;
        winPosition = false;
        _rd2 = GetComponent<Rigidbody2D>();
        temp = Vector2.zero;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            InputPerson();
        }
        if (transform.position.x + 0.09f >= exitObject.transform.position.x && transform.position.x - 0.09f <= exitObject.transform.position.x &&
            transform.position.y + 0.09f >= exitObject.transform.position.y && transform.position.y - 0.09f <= exitObject.transform.position.y)
        {
            winPosition = true;
        }
        else
        {
            winPosition = false;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = _rd2.velocity.y == 0.0f;
        if (_types[_currentPlayer].Equals(_type))
        {
            if (_rd2.bodyType == RigidbodyType2D.Static)
            {
                _rd2.bodyType = RigidbodyType2D.Dynamic;
            }
            if (Mathf.Abs(_rd2.velocity.x) <= minSpeedX)
            {
                temp = _rd2.velocity;
                temp.x = 0;
                _rd2.velocity = temp;
            }
            if (Input.GetKey(KeyCode.Space) && isGround)
            {

                isGround = false;
                _rd2.AddForce(new Vector2(_rd2.velocity.x, Time.fixedDeltaTime * speedSpace), ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.D))
            {
                _rd2.AddForce(new Vector2(speedMove * Time.fixedDeltaTime, 0), ForceMode2D.Force);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _rd2.AddForce(new Vector2(-speedMove * Time.fixedDeltaTime, 0), ForceMode2D.Force);
            }
            if (Mathf.Abs(_rd2.velocity.x) >= maxSpeedX)
            {
                temp = _rd2.velocity;
                temp.x = (_rd2.velocity.x > 0)? maxSpeedX : -maxSpeedX;
                _rd2.velocity = temp;
            }
        }
        else
        {
            if (isGround && _rd2.bodyType == RigidbodyType2D.Dynamic)
            {
                _rd2.bodyType = RigidbodyType2D.Static;
            }

            if (isGround && _rd2.bodyType == RigidbodyType2D.Static)
            {
                
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("StaticPlayer")  && other.gameObject.transform.position.y > transform.position.y)
        {
            GameObject g = GameObject.Find(other.gameObject.name);
            Rigidbody2D rd = g.GetComponent<Rigidbody2D>();
            rd.bodyType = RigidbodyType2D.Dynamic;
            rd.velocity = new Vector2(0, -0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.transform.position.y > transform.position.y && _rd2.bodyType != RigidbodyType2D.Static)
        {
            _rd2.velocity = new Vector2(0, -0.01f);
        }
    }

    void InputPerson()
    {
        if (Input.GetKey("1"))
        {
            _currentPlayer = 0;
            cameraController.currentPlayer = 0;
        }
        else if (Input.GetKey("2"))
        {
            cameraController.currentPlayer = 1;
            _currentPlayer = 1;
        }
        else if (Input.GetKey("3"))
        {
            _currentPlayer = 2;
            cameraController.currentPlayer = 2;
        }
        if (_types[_currentPlayer].Equals(_type))
        {
            gameObject.tag = "Player";
        }
        else
        {
            gameObject.tag = "StaticPlayer";
        }
    }
}

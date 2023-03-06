using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public int maxPoints = 2;
    public Image uiPlayer;
    public string playerName;


    [Header("Key Setup")]
    public KeyCode KeyCodeUp = KeyCode.UpArrow;
    public KeyCode KeyCodeDown = KeyCode.DownArrow;

    public Rigidbody2D myRigidBody2D;

    [Header("Points")]
    public int currentpoints;
    public TextMeshProUGUI UiTextPoints;
    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playerName = s;
    }
    public void ResetPlayer()
    {
        currentpoints = 0;
        UiUpdate();
    }

    void Update()
    {
        if (Input.GetKey(KeyCodeUp))
           myRigidBody2D.MovePosition(transform.position + transform.up * speed);
        else if (Input.GetKey(KeyCodeDown))
           myRigidBody2D.MovePosition(transform.position + transform.up * -speed);


    }

    public void AddPoint()
    {
        currentpoints++;
        UiUpdate();
        CheckMaxPoints();
        Debug.Log(currentpoints);
    }
    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }
    private void UiUpdate()
    {
        UiTextPoints.text = currentpoints.ToString();

    }

    private void CheckMaxPoints()
    {
        if (currentpoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighscoreManager.Instance.SavePlayerWin(this);
        }

    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    #region veriables
    public float moveSpeed = 5f;               
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float xInput;
    private int count;
    private int pickUpCount;
    private float zInput;
    public CharacterController playerController;
    private Vector3 moveDirection;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        pickUpCount = 0;
        playerController = GetComponent<CharacterController>();
        count = 0;
        FindObjectOfType<GameManager>().setCountText(pickUpCount);

        setCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(xInput, 0, zInput);
        playerController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 11)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            FindObjectOfType<GameManager>().setCountText(pickUpCount); //Tell the Game Manager to update the score text

            setCountText();
        }
      
    }
}
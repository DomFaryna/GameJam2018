using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls: MonoBehaviour
{

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text up, down, right, left, attack, ability, transmit, pause;

    private GameObject currentKey;

    private Color32 normal = new Color32(255,255,255,15);
    private Color32 slected = new Color32(0,255,33,255);

    // Use this for initialization
    void Start()
    {
        keys.Add("Up", KeyCode.W);
        keys.Add("Down", KeyCode.S);
        keys.Add("Right", KeyCode.D);
        keys.Add("Left", KeyCode.A);
        keys.Add("Attack", KeyCode.Space);
        keys.Add("Ability", KeyCode.LeftShift);
        keys.Add("Transmit", KeyCode.LeftControl);
        keys.Add("Pause", KeyCode.P);

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        right.text = keys["Right"].ToString();
        left.text = keys["Left"].ToString();
        attack.text = keys["Attack"].ToString();
        ability.text = keys["Ability"].ToString();
        transmit.text = keys["Transmit"].ToString();
        pause.text = keys["Pause"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys["Up"]))
            Debug.Log("Up");

        if (Input.GetKeyDown(keys["Down"]))
            Debug.Log("Down");

        if (Input.GetKeyDown(keys["Right"]))
            Debug.Log("Right");

        if (Input.GetKeyDown(keys["Left"]))
            Debug.Log("Left");

        if (Input.GetKeyDown(keys["Attack"]))
            Debug.Log("Attack");

        if (Input.GetKeyDown(keys["Ability"]))
            Debug.Log("Ability");

        if (Input.GetKeyDown(keys["Transmit"]))
            Debug.Log("Transmit");

        if (Input.GetKeyDown(keys["Pause"]))
            Debug.Log("Pause");
    }

    private void OnGUI()
    {
     if (currentKey != null)
        {
            Event currentEvent = Event.current;
            if (currentEvent.isKey)
            {
                keys[currentKey.name] = currentEvent.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = currentEvent.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = slected;
    }
}

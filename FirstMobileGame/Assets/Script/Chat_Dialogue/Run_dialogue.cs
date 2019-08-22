using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run_dialogue : MonoBehaviour {

    public Dialogue chat_dialogue;
    public int s_list = 0;

    public Text dialogue_text;

    void Start()
    {
        dialogue_text.text = chat_dialogue.sentence[s_list];
        s_list++;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (s_list != chat_dialogue.sentence.Length)
            {
                dialogue_text.text = chat_dialogue.sentence[s_list];
                s_list++;
            }
            else
            {
                dialogue_text.text = "";
            }
            //StartCoroutine(Delay_Sentence());
        }
	}

    IEnumerator Delay_Sentence()
    {
        yield return new WaitForSeconds(1.00f);
    }
}

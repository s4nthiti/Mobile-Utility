using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class itc_01 : MonoBehaviour {

    [SerializeField]
    public string SceneName = "";

    public CanvasGroup intro_msg;
    public CanvasGroup touch_msg;
    public CanvasGroup fade_img_cg;

    private float Fade_time = 2.00f;

    private bool credit_title = true;
    private bool game_title = true;

    public GameObject[] group_1;
    public GameObject[] group_2;

    public Text[] tamagotchi_text;

    RectTransform m_Rect_Tran;

    public AudioSource pop_sound;
    public AudioSource game_title_sound;

    public GameObject touch_text;
    public GameObject fade_img;

    private bool delay_text_bool = true;
    private bool touch = false;
    private bool touch_text_fade = true;
    private bool load_game_bool = true;

	// Use this for initialization
	void Start () {

        Screen.orientation = ScreenOrientation.LandscapeRight;
        Application.targetFrameRate = 60;
        m_Rect_Tran = GetComponent<RectTransform>();
        pop_sound = pop_sound.GetComponent<AudioSource>();
        touch_text.SetActive(false);
        fade_img.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
		if(Fade_time > 0.0f)
        {
            if(credit_title)
            {
                credit_title = false;
                for (int i = 0; i < group_2.Length; i++)
                {
                    group_2[i].SetActive(false);
                }
            }
            intro_msg.alpha -= Time.deltaTime / 2;
            Fade_time -= Time.deltaTime;
        }
        else
        {
            if(game_title)
            {
                for(int i = 0; i < group_1.Length; i++)
                {
                    group_1[i].SetActive(false);
                }
                if(delay_text_bool)
                    delay_text();
            }
            else
            {
                if(!touch)
                {
                    if (Input.GetMouseButton(0))
                    {
                        touch = true;
                    }
                    if(touch_msg.alpha == 1)
                    {
                        touch_text_fade = true;
                    }
                    if (touch_msg.alpha == 0)
                    {
                        touch_text_fade = false;
                    }

                    if(touch_text_fade)
                    {
                        touch_msg.alpha -= Time.deltaTime / 2;
                    }
                    if(!touch_text_fade)
                    {
                        touch_msg.alpha += Time.deltaTime / 2;
                    }
                }
                else if(load_game_bool)
                {
                    StartCoroutine(load_game_scene());
                }
            }
        }
	}

    public void delay_text()
    {
        StartCoroutine(wait_for_sec(1));
        StartCoroutine(delay_tamagotchi());
    }

    IEnumerator delay_tamagotchi()
    {
        delay_text_bool = false;
        yield return new WaitForSeconds(0.5f);
        group_2[0].SetActive(true);
        pop_sound.Play();
        yield return new WaitForSeconds(0.5f);
        group_2[1].SetActive(true);
        pop_sound.Play();
        yield return new WaitForSeconds(0.5f);
        group_2[2].SetActive(true);
        pop_sound.Play();
        yield return new WaitForSeconds(0.5f);
        group_2[3].SetActive(true);
        pop_sound.Play();
        game_title_sound.Play();

        yield return new WaitForSeconds(0.2f);
        group_2[0].SetActive(false);
        yield return new WaitForSeconds(0.2f);
        group_2[0].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        group_2[1].SetActive(false);
        yield return new WaitForSeconds(0.2f);
        group_2[1].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        group_2[2].SetActive(false);
        yield return new WaitForSeconds(0.2f);
        group_2[2].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        group_2[3].SetActive(false);
        yield return new WaitForSeconds(0.2f);
        group_2[3].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < tamagotchi_text.Length; i++)
        {
            tamagotchi_text[i].fontSize = 100;
            m_Rect_Tran.sizeDelta = new Vector2(tamagotchi_text[i].fontSize * 10, 100);
        }
        yield return new WaitForSeconds(0.5f);
        touch_text.SetActive(true);
        game_title = false;
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator load_game_scene()
    {
        load_game_bool = false;
        yield return new WaitForSeconds(0.2f);
        fade_img_cg.alpha = 0;
        fade_img.SetActive(true);
        while(fade_img_cg.alpha < 1)
        {
            fade_img_cg.alpha += Time.deltaTime / 2;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneName);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator wait_for_sec(float time)
    {
        yield return new WaitForSeconds(time);
    }
}

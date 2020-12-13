using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text clockText;

    public float minut, second;

    public GameObject popUp;

    public float speedDirection;

    public GameObject popUpPage;

    public GameObject restartButton;

    Vector3 startPosPopUp;

    Vector3 endPosPopUp;

    Vector3 startPosRestartButton;

    Vector3 endPosRestartButton;

    float timeOfTravel = 5f;

    float currentTime = 0f;

    float normalizedValue;

    void Start()
    {
        startPosPopUp = popUpPage.GetComponent<RectTransform>().anchoredPosition;

        endPosPopUp = new Vector3(0f, 146f);

        startPosRestartButton = restartButton.GetComponent<RectTransform>().anchoredPosition;

        endPosRestartButton = new Vector3(0f, 376f);

        popUp.SetActive(false);

        clockText = GetComponent<Text>();

        minut = 5f;
        second = 0f;
    }


    void Update()
    {
        second -= 1f * Time.deltaTime;

        if (second < 1f)
        {
            minut -= 1f;
            second = 60f;
        }

        clockText.text = minut.ToString("F0") + ":" + second.ToString("F0");

        if (minut < 0f)
        {
            clockText.text = "0:00";
            popUp.SetActive(true);

            StartCoroutine(CameraScaler());

            StartCoroutine(MenuLerp());

            PathMover.Singleton.play = false;
        }
    }

    IEnumerator CameraScaler()
    {
        yield return new WaitForSeconds(1f);

        FollowCamera.Singleton.offset = new Vector3(5f, 13f, -15f);

        yield return null;
    }

    IEnumerator MenuLerp()
    {
        yield return new WaitForSeconds(1f);

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            popUpPage.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPosPopUp, endPosPopUp, normalizedValue);

            restartButton.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPosRestartButton, endPosRestartButton, normalizedValue);

            yield return null;
        }       
    }
}

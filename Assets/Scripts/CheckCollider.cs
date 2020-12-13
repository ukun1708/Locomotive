using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollider : MonoBehaviour
{
    public GameObject CollectCargoButton;

    public Text cargoCount;

    public Text winCargoCount;

    int count = 0;

    public bool trainInStation = false;

    private void Start()
    {
        CollectCargoButton.SetActive(false);
    }

    private void Update()
    {
        if (trainInStation == true)
        {
            if (PathMover.Singleton.speed <= 0.1f)
            {
                CollectCargoButton.SetActive(true);

                trainInStation = false;

                PathMover.Singleton.play = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cargo")
        {
            trainInStation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cargo")
        {
            trainInStation = false;
        }
    }

    public void CollectCargo()
    {
        StartCoroutine(PlusCount());
    }

    IEnumerator PlusCount()
    {
        count += 1;
        cargoCount.text = count.ToString();
        winCargoCount.text = count.ToString();

        CollectCargoButton.SetActive(false);

        PathMover.Singleton.play = true;

        yield return null;
    }
}

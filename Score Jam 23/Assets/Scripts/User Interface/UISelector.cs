using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelector : MonoBehaviour
{
    [SerializeField] GameObject selectorIcon;
    Vector3 originalSelectorPosition;
    [SerializeField] GameObject[] interactableUI;

    int currentlySelectedUI = 0;

    private void Awake()
    {
        originalSelectorPosition = selectorIcon.transform.position;
    }

    private void Update()
    {
        Vector3 currentUIPos = interactableUI[currentlySelectedUI].transform.position;
        selectorIcon.transform.position = new Vector3(originalSelectorPosition.x, currentUIPos.y, currentUIPos.z);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            SelectAtPosition();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
        {
            if (currentlySelectedUI + 1 < interactableUI.Length)
            {
                currentlySelectedUI += 1;
            }
           
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
        {
            if(currentlySelectedUI - 1 >= 0)
            {
                currentlySelectedUI -= 1;
            }
        }
    }

    public void SelectAtPosition()
    {
        interactableUI[currentlySelectedUI].GetComponent<UnityEvent>().InvokeUnityEvent();
    }
}

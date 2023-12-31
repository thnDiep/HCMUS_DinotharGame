using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialBook : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float pageSpeed = 0.4f;
    [SerializeField] List<Transform> pages;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject backBtn;
    [SerializeField] GameObject forwardBtn;

    [SerializeField] private AudioSource turnPage;

    private void Start()
    {
        initialState();
    }

    public void initialState()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].transform.rotation = Quaternion.identity;
        }
        pages[0].SetAsLastSibling();
        backBtn.SetActive(false);
    }

    public void RotateForward()
    {
        if (rotate == true) { return; }
        index++;
        if(GameManager.Instance != null && GameManager.Instance.isSoundStatus())
        {
            turnPage.Play();
        }
        float angle = 180;
        forwardButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));

    }

    public void forwardButtonActions()
    {
        if (backBtn.activeInHierarchy == false)
        {
            backBtn.SetActive(true);
        }

        if (index == pages.Count - 1)
        {
            forwardBtn.SetActive(false);
        }

    }

    public void RotateBack()
    {
        if (rotate == true) { return; }
        float angle = 0;
        if (GameManager.Instance != null && GameManager.Instance.isSoundStatus())
        {
            turnPage.Play();
        }
        backButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, false));

    }

    public void backButtonActions()
    {
        if (forwardBtn.activeInHierarchy == false)
        {
            forwardBtn.SetActive(true);
        }

        if (index - 1 == -1)
        {
            backBtn.SetActive(false);
        }

    }

    public bool isRotating()
    {
        return rotate;
    }

    //public void OnDisable()
    //{
    //    rotate = false;
    //}

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation);
            if (angle1 < 0.1f)
            {
                if (forward == false)
                {
                    index--;
                }
                rotate = false;
                break;
            }
            yield return null;
        }
    }



}

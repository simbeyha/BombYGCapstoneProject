using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayTV : MonoBehaviour
{

    private IActiveState ActiveState { get; set; }

    public OVRInput.Controller controller;

    private VideoPlayer videoPlayer;
    [SerializeField]
    private GameObject newsPlayer;

    private bool videoPrepared = false;

    void Start()
    {
        // IActiveState를 구현한 오브젝트를 찾아서 ActiveState에 할당합니다.
        ActiveState = FindObjectOfType<InteractorActiveState>();

        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.prepareCompleted += VideoPrepared;

        Debug.Log("PlayVideoOnCanvas script started.");

        // VideoPlayer의 준비가 완료될 때까지 기다립니다.
        // 준비가 완료되면 비디오가 재생됩니다.
        if (videoPrepared)
        {
            videoPlayer.Play();
            Debug.Log("Video prepared. Playing...");
        }
    }
    void Update()
    {
        ToggleNewsPlayer();
    }

    void VideoPrepared(VideoPlayer vp)
    {
        videoPrepared = true;
    }

    void ToggleNewsPlayer()
    {

        bool isActive = ActiveState.Active;
        if(isActive == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two, controller))
            {
                if (newsPlayer.transform.GetChild(0).gameObject.activeSelf)
                {
                    newsPlayer.transform.GetChild(0).gameObject.SetActive(false);
                }
                else
                {
                    newsPlayer.transform.GetChild(0).gameObject.SetActive(true);
                }

            }
        }

    }

}

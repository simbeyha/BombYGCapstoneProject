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
        // IActiveState�� ������ ������Ʈ�� ã�Ƽ� ActiveState�� �Ҵ��մϴ�.
        ActiveState = FindObjectOfType<InteractorActiveState>();

        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.prepareCompleted += VideoPrepared;

        Debug.Log("PlayVideoOnCanvas script started.");

        // VideoPlayer�� �غ� �Ϸ�� ������ ��ٸ��ϴ�.
        // �غ� �Ϸ�Ǹ� ������ ����˴ϴ�.
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

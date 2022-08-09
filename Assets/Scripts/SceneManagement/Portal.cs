using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    public static bool isLoading = false;
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] int amountOfPointsToGo = -1;
    Animator fader;
    public void OnTrigger(PlayerController player)
    {
        if (amountOfPointsToGo <= PlayerStats.Instance.ECTS)
            if (!isLoading)
            {
                isLoading = true;
                StartCoroutine(SwitchScene(player));
            }
            else Debug.Log("Not enough ECTS");
    }


    IEnumerator SwitchScene(PlayerController player)
    {
        DontDestroyOnLoad(gameObject);
        fader = GameObject.Find("LevelChanger").GetComponent<Animator>();
        fader.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        var destination  = FindObjectsOfType<Portal>().First(x=>x!=this);
        player.transform.position = destination.spawnPoint.position;
        fader.ResetTrigger("FadeOut");
        
        isLoading = false;
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
        Destroy(gameObject);
    }
}

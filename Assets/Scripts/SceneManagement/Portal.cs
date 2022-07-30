using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, IPlayerTriggerable
{

    [SerializeField] int sceneToLoad = -1;
    [SerializeField] Transform spawnPoint;
    public void OnTrigger(PlayerController player)
    {
        StartCoroutine(SwitchScene(player));
    }


    IEnumerator SwitchScene(PlayerController player)
    {
        DontDestroyOnLoad(gameObject);
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
        var destination  = FindObjectsOfType<Portal>().First(x=>x!=this);

        player.transform.position = destination.spawnPoint.position;

        Destroy(gameObject);
    }
}

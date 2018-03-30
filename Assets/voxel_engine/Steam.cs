using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Steam : MonoBehaviour {

    public GameObject drainSteam;
    private static List<GameObject> drainList = new List<GameObject> ();
    private static int count = 0;
    private static int maxDrains = 10;
    private static bool created = false;
    private ParticleSystem ps;

    void Awake () {
        for (int i = 0; i < maxDrains; i++) {
            GameObject g = (GameObject)Instantiate (drainSteam, new Vector3 (0, 0, 0), Quaternion.identity);
            ps = drainSteam.GetComponent<ParticleSystem>();
            var drainSteamMain = ps.main;
            drainSteamMain.loop = true;
            drainSteam.GetComponent<ParticleSystem> ().Stop ();
            drainList.Add (g);
        }
    }

    public static void Create(Vector3 pos) {
        if(count < maxDrains) {
            drainList [count++].transform.position = pos;
            drainList [count - 1].GetComponent<ParticleSystem> ().Play ();
            created = true;
        }
    }

    void Update () {
        foreach(GameObject g in drainList) {
            if(g.GetComponent<ParticleSystem>().isPlaying && !created) {
                g.GetComponent<ParticleSystem> ().Stop ();
            }
        }
    }
}

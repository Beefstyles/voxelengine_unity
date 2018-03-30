using UnityEngine;
using System.Collections;

public class ChunkCollision : MonoBehaviour {

    public Chunk chunk;


    void OnCollisionEnter(Collision c) {
		if (c.gameObject.name == "bullet") {
			chunk.CollisionExplode ();
		} else {
			// Bounce, remove some blocks only.
			chunk.CollisionBounce();
		}
    }

    void Update () {
        if(chunk.obj.transform.position.y < -30) {
            GameObject.Destroy (chunk.obj);
        }

    }
}

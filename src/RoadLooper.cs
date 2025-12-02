using UnityEngine;

public class RoadLooper : MonoBehaviour
{
    public Transform player;
    public Transform[] chunks;    // RoadChunk_A/B/C
    public float chunkLength = 50f;
    public float recycleOffset = 10f; // ab wann ein Chunk als "hinter dem Spieler" gilt

    void Update()
    {
        if (!player) return;

        foreach (var t in chunks)
        {
            // Liegt dieser Chunk deutlich hinter dem Player?
            if (player.position.z - t.position.z > recycleOffset + chunkLength)
            {
                // ans Ende schieben: finde aktuelles maximal-Z
                float maxZ = float.MinValue;
                foreach (var c in chunks)
                    if (c.position.z > maxZ) maxZ = c.position.z;

                t.position = new Vector3(t.position.x, t.position.y, maxZ + chunkLength);
            }
        }
    }
}

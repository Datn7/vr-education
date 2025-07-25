using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class AlembicControl : MonoBehaviour
{
    private AlembicStreamPlayer player;

    void Start()
    {
        player = GetComponent<AlembicStreamPlayer>();
        Debug.Log("Type = " + player.GetType().FullName);

        // try this instead of .Speed
        // player.StreamDescriptor.Settings.PlaybackSettings.Speed = 1f;
    }

    public void Rewind()
    {// Try SyncTimelineToScene() if this fails
    }
}

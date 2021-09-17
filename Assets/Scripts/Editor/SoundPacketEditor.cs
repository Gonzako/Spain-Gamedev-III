using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoundPacket))]
public class SoundPacketEditor : Editor
{
    GameObject soundPlayer;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Preview"))
        {
            if (soundPlayer == null)
            {
                soundPlayer = new GameObject();
                soundPlayer.hideFlags = HideFlags.HideAndDontSave;
            }

            var aud = soundPlayer.AddComponent<AudioSource>();

            var target = serializedObject.targetObject as SoundPacket;
            target.PlaySound(aud);
        }
    }

    private void OnDestroy()
    {
        DestroyImmediate(soundPlayer);
    }

}

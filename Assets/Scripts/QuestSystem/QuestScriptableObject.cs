using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable] public enum QuestType { fetch, locate, resource };

[CreateAssetMenu(menuName = "ScriptableObjects/QuestScriptableObject")] 

public class QuestScriptableObject : ScriptableObject
{
	public int id;
	public string displayName; //put private after testing
	public QuestType type;
	public int typeCount;
	public int questNPCId;
	[SerializeField] private int nextQuestId;
	//[SerializeField] private int typeParam;

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class data8 : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public string word;
		public string pinyin;
		public string meaning;
		public string option1;
		public string option2;
		public string option3;
		public string option4;
	}
}


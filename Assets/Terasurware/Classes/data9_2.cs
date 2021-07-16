using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class data9_2 : ScriptableObject
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
		
		public string a;
		public string b;
		public string c;
		public string d;
		public string e;
		public string f;
		public string g;
		public string h;
		public string i;
		public string j;
		public string k;
	}
}


using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class data8_2_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/data8_2.xlsx";
	private static readonly string exportPath = "Assets/data8_2.asset";
	private static readonly string[] sheetNames = { "Sheet1", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			datas8_2 data = (datas8_2)AssetDatabase.LoadAssetAtPath (exportPath, typeof(datas8_2));
			if (data == null) {
				data = ScriptableObject.CreateInstance<datas8_2> ();
				AssetDatabase.CreateAsset ((ScriptableObject)data, exportPath);
				data.hideFlags = HideFlags.NotEditable;
			}
			
			data.sheets.Clear ();
			using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
				IWorkbook book = null;
				if (Path.GetExtension (filePath) == ".xls") {
					book = new HSSFWorkbook(stream);
				} else {
					book = new XSSFWorkbook(stream);
				}
				
				foreach(string sheetName in sheetNames) {
					ISheet sheet = book.GetSheet(sheetName);
					if( sheet == null ) {
						Debug.LogError("[QuestData] sheet not found:" + sheetName);
						continue;
					}

					datas8_2.Sheet s = new datas8_2.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						datas8_2.Param p = new datas8_2.Param ();
						
					cell = row.GetCell(0); p.a = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.b = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.c = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(3); p.d = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(4); p.e = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(5); p.f = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(6); p.g = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(7); p.h = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(8); p.i = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(9); p.j = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(10); p.k = (cell == null ? "" : cell.StringCellValue);
						s.list.Add (p);
					}
					data.sheets.Add(s);
				}
			}

			ScriptableObject obj = AssetDatabase.LoadAssetAtPath (exportPath, typeof(ScriptableObject)) as ScriptableObject;
			EditorUtility.SetDirty (obj);
		}
	}
}

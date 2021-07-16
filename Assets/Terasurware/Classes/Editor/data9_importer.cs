using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class data9_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/data9.xlsx";
	private static readonly string exportPath = "Assets/data9.asset";
	private static readonly string[] sheetNames = { "Sheet1", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			data9 data = (data9)AssetDatabase.LoadAssetAtPath (exportPath, typeof(data9));
			if (data == null) {
				data = ScriptableObject.CreateInstance<data9> ();
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

					data9.Sheet s = new data9.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						data9.Param p = new data9.Param ();
						
					cell = row.GetCell(0); p.word = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.pinyin = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.meaning = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(3); p.option1 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(4); p.option2 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(5); p.option3 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(6); p.option4 = (cell == null ? "" : cell.StringCellValue);
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

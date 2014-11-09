using UnityEngine;
using System.Collections;

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager {
	static DataManager m_instance;
	public static DataManager Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = new DataManager();
			}
			return m_instance;
		}
	}

	// 将对象序列化成字节数组
	public static string ToBytes(object obj)
	{
		if (obj == null) return null;
		using (MemoryStream s = new MemoryStream())
		{
			IFormatter f = new BinaryFormatter();
			f.Serialize(s, obj);
			return ToHexString(s.GetBuffer());
		}
	}
	
	// 将字节数组反序列化成对象
	public static object ToObject(string strData)
	{
		int discarded = 0;
		byte[] Bytes = GetBytes(strData, out discarded);
		if (discarded != 0)
		{
			Debug.Log("discarded:" + discarded);
		}
		using (MemoryStream s = new MemoryStream(Bytes))
		{
			IFormatter f = new BinaryFormatter();
			return f.Deserialize(s);
		}
	}

	public void GetConfigData<T>(string sectionName, string key, ref T data)
	{
		string strData = PlayerPrefs.GetString(sectionName + "_" + key);
		//Debug.Log ("Get config:" + strData);

		try{
			if (strData.Length != 0)
			{
				data = (T)ToObject(strData);
			}
		}
		catch(Exception ex)
		{
			Debug.LogError(ex.ToString());
		}
		//Debug.Log ("Deserialize:" + data.ToString());
	}

	public void SetConfigData<T>(string sectionName, string key, T data)
	{
		//Debug.Log ("Set data:" + data.ToString());
		string strData = "";
		try
		{
			strData = ToBytes(data);
		}
		catch(Exception ex)
		{
			Debug.LogError(ex.ToString());
		}
		//Debug.Log ("Set config:" + strData);
		PlayerPrefs.SetString(sectionName + "_" + key, strData);
	}

	public static string ToHexString ( byte[] bytes ) // 0xae00cf => "AE00CF "
	{
		string hexString = string.Empty;
		if ( bytes != null )
		{
			System.Text.StringBuilder strB = new System.Text.StringBuilder ();
			
			for ( int i = 0; i < bytes.Length; i++ )
			{
				strB.Append ( bytes[i].ToString ( "X2" ) );
			}
			hexString = strB.ToString ();
		}
		return hexString;
	}

	public static byte[] GetBytes(string hexString, out int discarded)
	{
		discarded = 0;
		string newString = "";
		char c;
		// remove all none A-F, 0-9, characters
		for (int i=0; i<hexString.Length; i++)
		{
			c = hexString[i];
			if (System.Uri.IsHexDigit(c))
				newString += c;
			else
				discarded++;
		}
		// if odd number of characters, discard last character
		if (newString.Length % 2 != 0)
		{
			discarded++;
			newString = newString.Substring(0, newString.Length-1);
		}
		
		int byteLength = newString.Length / 2;
		byte[] bytes = new byte[byteLength];
		string hex;
		int j = 0;
		for (int i=0; i<bytes.Length; i++)
		{
			hex = new String(new Char[] {newString[j], newString[j+1]});
			bytes[i] = HexToByte(hex);
			j = j+2;
		}
		return bytes;
	}
	
	private static byte HexToByte(string hex)
	{
		byte tt = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
		return tt;
	}
}

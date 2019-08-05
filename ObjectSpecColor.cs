using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class ObjectSpecColor : NetworkBehaviour {
	//public PaintScript pS;
	//float newSpecular;

	Renderer rend;
	public PaintScript PS;
	int ValReciever;
	public bool rims;
	public string ColPref;

	[SyncVar]
	public string TheColor;
	//public bool SpecularEditor;


void Awake()
{
	Renderer renderer = GetComponent<Renderer>();
	Material mt = renderer.sharedMaterial;
	renderer.sharedMaterial = mt;
	Color currentColor;
currentColor = renderer.sharedMaterial.GetColor("_Color");

	TheColor = PlayerPrefs.GetString(ColPref, currentColor.ToString());
	ColorGO();
}

	void OnSetColor(Color color)
	{
			PlayerPrefs.SetString(ColPref, color.ToString()); // saves the color to the varuiable colpref
			ColorGO();
	}



void ColorGO() {
	Renderer renderer = GetComponent<Renderer>();
	Material mt = renderer.sharedMaterial;
	//mt.color = color;
	renderer.sharedMaterial = mt;

	Color currentColor;
currentColor = renderer.sharedMaterial.GetColor("_Color");

	TheColor = PlayerPrefs.GetString(ColPref, currentColor.ToString());
         //Remove the header and brackets
         TheColor = TheColor.Replace("RGBA(", "");
         TheColor = TheColor.Replace(")", "");

         //Get the individual values (red green blue and alpha)
         var strings = TheColor.Split(","[0] );

         Color outputcolor;
         outputcolor = Color.black;
         for (var i = 0; i < 4; i++) {
             outputcolor[i] = System.Single.Parse(strings[i]);

						 renderer.sharedMaterial.SetColor("_Color", outputcolor);
						 PlayerPrefs.SetString(ColPref, outputcolor.ToString());

         }

     }

		

	void OnGetColor(ColorPicker picker)
	{
		ColorGO();
		picker.NotifyColor(GetComponent<Renderer>().sharedMaterial.color);
	}
}

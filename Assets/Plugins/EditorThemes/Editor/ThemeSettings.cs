using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using ThemesPlugins;
using UnityEditorInternal;
//to do TextColor
//EditorStyles.label.normal.textColor 

namespace ThemesPlugins
{

    public class ThemeSettings : EditorWindow
    {
        public List<string> AllThemes = new List<string>();


        [MenuItem("Themes/Select Themes")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<ThemeSettings>("Theme Settings");
        }


        string currentTheme;

        [SerializeField] enum ThemeType { Smart, Custom };

        public string ThemeName;

        Vector2 scrollPosition;




        public static ThemeSettings i;
        private void Awake()
        {
            i = this;
        }

        private void OnEnable()
        {
            i = this;
        }



        private void OnGUI()
        {

            //window code

            GUILayout.Label("Create & Select Themes", EditorStyles.boldLabel);
            GUILayout.Label("Currently Selected: " + currentTheme, EditorStyles.boldLabel);



            if (GUILayout.Button("Create new Theme"))
            {
                
                CreateThemeWindow window = (CreateThemeWindow)EditorWindow.GetWindow(typeof(CreateThemeWindow), false, "Create Theme");
                window.Show();
            }
            GUILayout.Label("or Select:", EditorStyles.boldLabel);


            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            
            
            EditorGUILayout.LabelField("");
            EditorGUILayout.LabelField("Dark & Light Themes:");
            foreach (string s in Directory.GetFiles(Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/CustomThemes/", "*.json"))
            {
                CustomTheme ct = JsonUtility.FromJson<CustomTheme>(File.ReadAllText(s));

                if (ct.unityTheme == CustomTheme.UnityTheme.Both)
                {
                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button(Path.GetFileNameWithoutExtension(s)))
                    {

                        LoadUssFileForCustom(Path.GetFileNameWithoutExtension(s));
                    }

                    if (!ct.IsUnEditable && GUILayout.Button("Edit", GUILayout.Width(70)))
                    {

                        EditThemeWindow.ct = ct;
                        EditThemeWindow window = (EditThemeWindow)EditorWindow.GetWindow(typeof(EditThemeWindow), false, "Edit Theme");
                        
                        window.Show();

                    }
                    if (!ct.IsUnDeletable && GUILayout.Button("Delete", GUILayout.Width(70)))
                    {

                        if (File.Exists(s))
                        {
                            File.Delete(s);
                            File.Delete(s + ".meta");
                        }
                        if (!File.Exists(Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/CustomThemes/" + currentTheme + ".json"))
                        {
                            LoadUssFileForCustom(".deafault");
                        }

                    }

                    EditorGUILayout.EndHorizontal();
                }

            }

            EditorGUILayout.LabelField("");
            EditorGUILayout.LabelField("Dark Themes:");
            foreach (string s in Directory.GetFiles(Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/CustomThemes/", "*.json"))
            {
                CustomTheme ct = JsonUtility.FromJson<CustomTheme>(File.ReadAllText(s));

                if (ct.unityTheme == CustomTheme.UnityTheme.Dark)
                {
                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button(Path.GetFileNameWithoutExtension(s)))
                    {
                    
                        LoadUssFileForCustom(Path.GetFileNameWithoutExtension(s));
                    }

                    if (!ct.IsUnEditable &&GUILayout.Button("Edit", GUILayout.Width(70)))
                    {

                        EditThemeWindow.ct = ct;
                        EditThemeWindow window = (EditThemeWindow)EditorWindow.GetWindow(typeof(EditThemeWindow), false, "Edit Theme");
                        
                        window.Show();

                    }
                    if (!ct.IsUnDeletable &&GUILayout.Button("Delete", GUILayout.Width(70)))
                    {

                        if (File.Exists(s))
                        {
                            File.Delete(s);
                            File.Delete(s + ".meta");
                        }
                        if (!File.Exists(Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/CustomThemes/" + currentTheme + ".json"))
                        {
                            LoadUssFileForCustom("_deafault");
                        }

                    }

                    EditorGUILayout.EndHorizontal();
                }

            }

            EditorGUILayout.LabelField("");
            EditorGUILayout.LabelField("Light Themes:");
            foreach (string s in Directory.GetFiles(Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/CustomThemes/", "*.json"))
            {
                CustomTheme ct = JsonUtility.FromJson<CustomTheme>(File.ReadAllText(s));

                if (ct.unityTheme == CustomTheme.UnityTheme.Light)
                {
                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button(Path.GetFileNameWithoutExtension(s)))
                    {

                        LoadUssFileForCustom(Path.GetFileNameWithoutExtension(s));
                    }

                    if (!ct.IsUnEditable && GUILayout.Button("Edit", GUILayout.Width(70)))
                    {

                        EditThemeWindow.ct = ct;
                        EditThemeWindow window = (EditThemeWindow)EditorWindow.GetWindow(typeof(EditThemeWindow), false, "Edit Theme");
                        window.Show();

                    }
                    if (!ct.IsUnDeletable && GUILayout.Button("Delete", GUILayout.Width(70)))
                    {

                        if (File.Exists(s))
                        {
                            File.Delete(s);
                            File.Delete(s + ".meta");
                        }
                        if (!File.Exists(Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/CustomThemes/" + currentTheme + ".json"))
                        {
                            LoadUssFileForCustom("_deafault");
                        }

                    }

                    EditorGUILayout.EndHorizontal();
                }

            }


           

            EditorGUILayout.EndScrollView();

               

        }




        string BackgroundColor(string Name, Color Color)
        {
            Color32 color32 = Color;
            //Debug.Log(color32);
            string a = Color.a + "";
            a = a.Replace(",", ".");

            string Colors = "rgba(" + color32.r + ", " + color32.g + ", " + color32.b + ", " + a + ")";// Generate colors for later

            string s = "\n" + "\n";//add two empty lines

            s += "." + Name + "\n";//add name
            s += "{" + "\n" + "\t" + "background-color: " + Colors + ";" + "\n" + "}";//add color

            return s;
        }

        void LoadUssFileForCustom(string Name)
        {
            
            string json = File.ReadAllText(Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/CustomThemes/" + Name + ".json");
            CustomTheme t = JsonUtility.FromJson<CustomTheme>(json);

            if ((EditorGUIUtility.isProSkin && t.unityTheme == CustomTheme.UnityTheme.Light) || (!EditorGUIUtility.isProSkin && t.unityTheme == CustomTheme.UnityTheme.Dark))
            {
                
                
                
                InternalEditorUtility.SwitchSkinAndRepaintAllViews();
               
                //WrongUnityTheme.Init();
                
            }
            

            
            currentTheme = Name;
            string ussText = "\n";
            ussText += "/* ========== Editor Themes Plugin ==========*/";
            ussText += "\n";
            ussText += "/*            Auto Generated Code            */";
            ussText += "\n";
            ussText += "/*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*/";

            foreach (CustomTheme.UIItem I in t.Items)
            {
                ussText += BackgroundColor(I.Name, I.Color);
            }

            WriteUss(ussText);
            



        }



        void WriteUss(string ussText)
        {
            string Path = Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/dark.uss";
            File.Delete(Path);
            File.Delete(Path + ".meta");

            File.WriteAllText(Path, ussText);


            string Path2 = Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/light.uss";
            File.Delete(Path2);
            File.Delete(Path2 + ".meta");
            
            File.WriteAllText(Path2, ussText);


            AssetDatabase.Refresh();

        }


        public void SaveJsonFileForCustom(CustomTheme t)
        {


            string NewJson = JsonUtility.ToJson(t);


            string Path = Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/CustomThemes/" + t.Name + ".json";
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }

            File.WriteAllText(Path, NewJson);
            LoadUssFileForCustom(t.Name);

        }


        public List<string> GetColorListByInt(int i)
        {
            List<string> colorList = new List<string>();


            switch (i)
            {
                case 0://base
                    colorList.Add("TabWindowBackground");
                    colorList.Add("ScrollViewAlt");
                    colorList.Add("label");
                    colorList.Add("ProjectBrowserTopBarBg");
                    colorList.Add("ProjectBrowserBottomBarBg");
                    break;
                case 1://accent
                    colorList.Add("dockHeader");
                    colorList.Add("TV LineBold");
                    
                    break;
                case 2://secondery
                    colorList.Add("ToolbarDropDownToogleRight");
                    colorList.Add("ToolbarPopupLeft");
                    colorList.Add("ToolbarPopup");
                    colorList.Add("toolbarbutton");
                    colorList.Add("PreToolbar");
                    colorList.Add("AppToolbar");
                    colorList.Add("GameViewBackground");
                    colorList.Add("CN EntryInfoSmall");
                    colorList.Add("Toolbar");
                    colorList.Add("toolbarbutton");
                    colorList.Add("toolbarbuttonRight");
                    
                    colorList.Add("ProjectBrowserIconAreaBg");

                    //colorList.Add("dragTab");//this is the currently clicked tab  has to be a diffrent color than the other tabs
                    break;
                case 3://Tab
                    //colorList.Add("dragtab first");
                    colorList.Add("dragtab-label");//changing this color has overriten dragTab and dragtab first so removed
                    break;
                case 4://button

                    colorList.Add("AppCommandLeft");
                    colorList.Add("AppCommandMid");
                    colorList.Add("AppCommand");
                    colorList.Add("AppToolbarButtonLeft");
                    colorList.Add("AppToolbarButtonRight");
                    colorList.Add("DropDown");
                    break;
                case 5:
                    colorList.Add("SceneTopBarBg");
                    colorList.Add("MiniPopup");
                    colorList.Add("TV Selection");
                    colorList.Add("ExposablePopupMenu");
                    colorList.Add("minibutton");
                    colorList.Add(" ToolbarSearchTextField");
                    break;


            }
            return colorList;

        }




    }
}
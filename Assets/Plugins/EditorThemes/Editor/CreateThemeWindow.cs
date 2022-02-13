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
    public class CreateThemeWindow : EditorWindow
    {
        enum UnityTheme { Dark, Light }
        UnityTheme unityTheme;


        [MenuItem("Themes/Create Theme")]
        public static void ShowWindow()
        {
            ThemeSettings.ShowWindow();
            EditorWindow.GetWindow<CreateThemeWindow>("Theme Settings");




        }



        string Name = "EnterName";
        private void OnGUI()
        {
            EditorGUILayout.LabelField("");


            Name = EditorGUILayout.TextField(Name, GUILayout.Width(200));


            EditorGUILayout.LabelField("");

            unityTheme = (UnityTheme)EditorGUILayout.EnumPopup(unityTheme, GUILayout.Width(100));

            EditorGUILayout.LabelField("");

            bool create = false;
            
            Event e = Event.current;
            if (e.type == EventType.KeyDown)
            {
                if (e.keyCode == KeyCode.Return)
                {
                    create = true;
                }
            }
            if(GUILayout.Button("Create Custom Theme", GUILayout.Width(200)))
            {
                create = true;
            }


            if (create)
            {
                string Path = Application.dataPath + "/EditorThemes/Editor/StyleSheets/Extensions/CustomThemes/" + Name + ".json";
                if (File.Exists(Path))
                {
                    if( EditorUtility.DisplayDialog("This Theme already exsists", "Do you want to overide the old Theme", "Yes",  "Cancel")   == false)
                    {
                        return;
                    }
                }

                    CustomTheme t = new CustomTheme();
                t.Items = new List<CustomTheme.UIItem>();
              

                if(unityTheme == UnityTheme.Dark)
                {
                    t.unityTheme = CustomTheme.UnityTheme.Dark;
                }
                else
                {
                    t.unityTheme = CustomTheme.UnityTheme.Light;
                }

                //fetch all ColorObjects
                for(int i = 0; i < 6; i++)
                {
                    Color DefaultColor = Color.black;
                    if(unityTheme == UnityTheme.Dark)
                    {
                        switch (i)
                        {
                            case 0:
                                DefaultColor = HtmlToRgb("#383838");
                                break;
                                case 1:
                                DefaultColor = HtmlToRgb("#282828");
                                break;
                            case 2:
                                DefaultColor = HtmlToRgb("#3C3C3C");
                                break ;
                                case 3:
                                DefaultColor= HtmlToRgb("#2D2D2D");
                                break;
                            case 4:
                                DefaultColor = HtmlToRgb("#383838");
                                break;    
                            case 5:
                                DefaultColor = HtmlToRgb("#585858");
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                DefaultColor = HtmlToRgb("#C8C8C8");
                                break;
                            case 1:
                                DefaultColor = HtmlToRgb("#A5A5A5");
                                break;
                            case 2:
                                DefaultColor = HtmlToRgb("#A5A5A5");
                                break;
                            case 3:
                                DefaultColor = HtmlToRgb("#CBCBCB");
                                break;
                            case 4:
                                DefaultColor = HtmlToRgb("#C8C8C8");
                                break;
                            case 5:
                                DefaultColor = HtmlToRgb("#DFDFDF");
                                break;
                        }
                    }
                    
                    
                    foreach(string s in ThemeSettings.i.GetColorListByInt(i))
                    {
                        CustomTheme.UIItem uiItem = new CustomTheme.UIItem();
                        uiItem.Name = s;
                        if(s != "AppToolbar")
                        {
                            uiItem.Color = DefaultColor;
                        }
                        else
                        {
                            if(unityTheme == UnityTheme.Dark)
                            {
                                uiItem.Color = HtmlToRgb("#191919");
                            }
                            else
                            {
                                uiItem.Color = HtmlToRgb("#8A8A8A");
                            }
                        }
                        
                        t.Items.Add(uiItem);
                    }
                }

               


                




                t.Name = Name;


                ThemeSettings.i.SaveJsonFileForCustom(t);

                EditThemeWindow.ct = t;
                EditThemeWindow window = (EditThemeWindow)EditorWindow.GetWindow(typeof(EditThemeWindow), false, "Edit Theme");
                window.Show();

                this.Close();
            }

           

        }

        Color HtmlToRgb(string s)
        {
            Color c = Color.black;
            ColorUtility.TryParseHtmlString(s,out c);
            return c;
        }
    }
    
}

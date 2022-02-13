using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace ThemesPlugins
{   
    [System.Serializable]
    public class CustomTheme
    {
    
    
    
        public string Name;
        public List<UIItem> Items;
    
        public enum UnityTheme { Dark,Light,Both}
        public UnityTheme unityTheme;
        public bool IsUnDeletable;
        public bool IsUnEditable;

        [System.Serializable]
        public class UIItem
        {
            public string Name;
            public Color Color;
        
        }
    }
}



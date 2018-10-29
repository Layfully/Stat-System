using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    public partial class StatDatabaseType<D, T, Z> where Z:StatObject where D : ScriptableObjectDatabase<T> where T : Data<Z, T>, new()
    {
        public void StatDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            if (_showDetails)
            {
                _temporaryStat.OnGUI();
            }

            GUILayout.EndVertical();
            GUILayout.Space(50);
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            DisplayButtons();
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }

        private void DisplayButtons()
        {
            if (_showDetails)
            {
                SaveButton();
                if (_selectedIndex != -1)
                {
                    DeleteButton();
                }

                CancelButton();
            }
            else
            {
                CreateStatButton();
            }
        }

        private void CreateStatButton()
        {
            if (GUILayout.Button("Create " + _statTypeName))
            {
                _temporaryStat = new T();
                _showDetails = true;
            }
        }

        private void SaveButton()
        {
            if (GUILayout.Button("Save"))
            {
                if (_selectedIndex == -1)
                {
                    Add(_temporaryStat);
                }
                else
                {
                    Replace(_selectedIndex, _temporaryStat);
                }

                _temporaryStat = null;
                _showDetails = false;
                _selectedIndex = -1;
                GUI.FocusControl(null);
            }
        }

        private void CancelButton()
        {
            if (GUILayout.Button("Cancel"))
            {
                _temporaryStat = null;
                _showDetails = false;
                GUI.FocusControl(null);
            }
        }

        private void DeleteButton()
        {
            if (GUILayout.Button("Delete"))
            {
                if (EditorUtility.DisplayDialog("Delete " + _statTypeName,
                    "Are you sure that you want to delete " + _temporaryStat.Stat.Name,
                    "Delete", "Cancel"))
                {
                    Remove(_selectedIndex);

                    _temporaryStat = null;
                    _showDetails = false;
                    _selectedIndex = -1;
                    GUI.FocusControl(null);
                }
            }
        }
    }
}
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    public partial class StatDatabaseType<D, T, Z> where Z:StatObject where D : ScriptableObjectDatabase<T> where T : Data<Z, T>, new()
    {
        private void LoadDatabase()
        {
            string databaseFullPath = @"Assets/" + _databasePath + "/" + _databaseName;

            _database = AssetDatabase.LoadAssetAtPath<D>(databaseFullPath);

            if (_database == null)
            {
                CreateDatabase(databaseFullPath);
            }
        }

        private void CreateDatabase(string databaseFullPath)
        {
            if (!AssetDatabase.IsValidFolder("Assets/" + _databasePath))
            {
                AssetDatabase.CreateFolder("Assets", _databasePath);
            }

            _database = ScriptableObject.CreateInstance<D>();
            AssetDatabase.CreateAsset(_database, databaseFullPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public void Add(T stat)
        {
            _database.Items.Add(stat);
            EditorUtility.SetDirty(_database);
        }

        public void Insert(int index, T stat)
        {
            _database.Items.Insert(index, stat);
            EditorUtility.SetDirty(_database);
        }

        public void Remove(T stat)
        {
            _database.Items.Remove(stat);
            EditorUtility.SetDirty(_database);
        }

        public void Remove(int stat)
        {
            _database.Items.RemoveAt(stat);
            EditorUtility.SetDirty(_database);
        }

        public void Replace(int index, T stat)
        {
            _database.Items[index] = stat;
            EditorUtility.SetDirty(_database);
        }
        
        public int Count
        {
            get { return _database.Items.Count; }
        }
        public int GetIndex(string stat)
        {
            return _database.Items.FindIndex(a => a.Stat.Name == stat);
        }
        public T Get(int index)
        {
            return _database.Items[index];
        }
        public static U GetDatabase<U>(string databasePath, string databaseName) where U : ScriptableObject
        {
            string databaseFullPath = @"Assets/" + databasePath + "/" + databaseName;

            U database = AssetDatabase.LoadAssetAtPath<U>(databaseFullPath);

            if (database == null)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + databasePath))
                {
                    AssetDatabase.CreateFolder("Assets", databasePath);
                }

                database = ScriptableObject.CreateInstance<U>();
                AssetDatabase.CreateAsset(database, databaseFullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            return database;
        }
    }
}
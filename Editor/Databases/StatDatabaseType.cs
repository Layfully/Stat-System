using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    public partial class StatDatabaseType<D, T, Z> where Z:StatObject where D : ScriptableObjectDatabase<T> where T : Data<Z, T>, new()
    {
        [SerializeField] private D _database;
        [SerializeField] private string _databaseName;
        [SerializeField] private string _databasePath = @"Database";
        [SerializeField] private string _statTypeName = "Stat";

        public StatDatabaseType(string name)
        {
            _databaseName = name;
        }

        public void OnEnable(string typeName)
        {
            _statTypeName = typeName;

            if (_database == null)
            {
                LoadDatabase();
            }
        }

        public void OnGUI(Vector2 buttonSize, int width)
        {
            ListView(buttonSize, width);
            StatDetails();
        }
    }
}


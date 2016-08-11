
using System.Collections.Generic;
using System.Linq;

namespace AndroidApp.Resources.Class
{
    class Database<T> where T : new()
    {
        string folder;
        SQLiteConnection db;

        public Database (string pathName)
        {
            folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            db = new SQLiteConnection(System.IO.Path.Combine(folder, pathName));
            db.CreateTable<T>();
        }

        public void Inserer(T objet)
        {
            db.Insert(objet);
        }

        public void Modifier(T objet)
        {
            db.Update(objet);
        }

        public void Supprimer(int identifiant)
        {
            db.Delete<T>(identifiant);
        }

        public T RecupererParId(int identifiant)
        {
            return db.Get<T>(identifiant);
        }

        public List<T> Recuperer()
        {
            return (from i in db.Table<T>() select i).ToList();
        }

    }
}
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public static class MongoExample
    {
        static string DBName = "UnitsBase";
        static string collectionName = "Units";
        static MongoClient client;
        static IMongoDatabase database;
        static IMongoCollection<Unit> collection;

        static MongoExample()
        {
            client = new MongoClient();
            database = client.GetDatabase(DBName);
            collection = database.GetCollection<Unit>(collectionName);
        }

        public static void AddToDB(Unit unit)
        {
            collection.InsertOne(unit);
        }

        public static List<Unit> FindAll()
        {
            return collection.Find(x => true).ToList();
        }

        public static void ReplaceUnit(string name, Unit unit)
        {
            collection.ReplaceOne(x => x.Name == name, unit);
        }

        public static Unit Find(string name)
        {
            return collection.Find(x => x.Name == name).FirstOrDefault();
        }
    }
}

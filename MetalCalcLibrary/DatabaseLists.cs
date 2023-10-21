using System;
using System.Collections.Generic;
using System.Data;

namespace MetalCalcLibrary
{
    public class DatabaseLists
    {
        private readonly Database dataBase;

        public List<Sort> Sorts { get; private set; }
        public List<Element> Elements { get; private set; }

        public DatabaseLists(Database database)
        {
            dataBase = database;
        }

        public void Load()
        {
            Sorts = LoadSorts();
            Elements = LoadElements();
        }

        private List<Sort> LoadSorts()
        {
            var sorts = new List<Sort>();
            var dataTable = dataBase.ExecuteQuery("SELECT * FROM Sorts");
            foreach (DataRow row in dataTable.Rows)
            {
                sorts.Add(new Sort
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = row["Name"].ToString(),
                    Gost = row["Gost"].ToString()
                });
            }
            return sorts;
        }

        private List<Element> LoadElements()
        {
            var elements = new List<Element>();
            var dataTable = dataBase.ExecuteQuery("SELECT * FROM Elements");
            foreach (DataRow row in dataTable.Rows)
            {
                elements.Add(new Element
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = row["Name"].ToString(),
                    AreaPerTon = Convert.ToDouble(row["AreaPerTon"]),
                    MassOneMeter = Convert.ToDouble(row["MassOneMeter"]),
                    SortID = Convert.ToInt32(row["SortID"])
                });
            }
            return elements;
        }
    }
}



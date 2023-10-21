using System;


namespace MetalCalcLibrary
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public double Tonnage { get; set; }
        public double Area { get; set; }
        public int UserID { get; set; }


        // Конструктор с параметрами
        public Project(int id, string name, DateTime creationDate, double tonnage, double area, int userId)
        {
            ID = id;
            Name = name;
            CreationDate = creationDate;
            Tonnage = tonnage;
            Area = area;
            UserID = userId;
        }
    }
}
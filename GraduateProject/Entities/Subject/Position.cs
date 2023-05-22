﻿namespace GraduateProject.Entities.Subject
{
    public class Position
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<EmployeePosition> EmployeePositions { get; set; }
    }
} 

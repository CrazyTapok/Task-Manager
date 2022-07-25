using System;
using System.Collections.Generic;

namespace TaskManager.DAL.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}

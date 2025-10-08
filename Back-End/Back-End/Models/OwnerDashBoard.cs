using System;
using System.Collections.Generic;

namespace Back_End.Models;

public partial class OwnerDashBoard
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public string Department { get; set; } = null!;

    public decimal Salary { get; set; }
}

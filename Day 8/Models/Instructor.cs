using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day_8.Models;

public partial class Instructor
{
    public int InsId { get; set; }
    [StringLength(50,MinimumLength =3)]

    public string? InsName { get; set; }

	[StringLength(50, MinimumLength = 3)]
	public string? InsDegree { get; set; }

    public int? DeptId { get; set; }

	public int? Salary { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}

﻿namespace EntityFrameworkWebApiExample.Repositories.Models
{
    public class ExampleModel
    {
        public int ExampleID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public int? Age { get; set; }
    }
}

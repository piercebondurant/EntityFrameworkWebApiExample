namespace EntityFrameworkWebApiExample.Examples.Commands
{
    public class CreateExampleCommand
    {
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; } = string.Empty;

        public int? Age { get; set; }
    }
}

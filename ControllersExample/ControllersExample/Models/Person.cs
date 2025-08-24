namespace ControllersExample.Models;

public class Person
{
    // used for json controller
    public Guid Id { get; set; }
    // Can accept null values in first and last-name
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
}
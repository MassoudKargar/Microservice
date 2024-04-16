namespace Ms.Core.Domain;

public class Person
{
    private Person()
    {
        
    }
    public Person(string firsName, string lastName, List<PhoneNumber> phoneNumbers)
    {
        FirsName = firsName ?? throw new ArgumentNullException(nameof(firsName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        PhoneNumbers = phoneNumbers ?? throw new ArgumentNullException(nameof(phoneNumbers));
    }
    public int Id { get; set; }
    public string FirsName { get; set; }
    public string LastName { get; set; }
    public List<PhoneNumber> PhoneNumbers { get; set; } = new();
}
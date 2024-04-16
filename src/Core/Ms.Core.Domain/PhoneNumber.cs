namespace Ms.Core.Domain;

public class PhoneNumber
{
    public PhoneNumber(string number)
    {
        Number = number ?? throw new ArgumentNullException(nameof(number));
    }
    public int Id { get; set; }
    public string Number { get; set; }
}
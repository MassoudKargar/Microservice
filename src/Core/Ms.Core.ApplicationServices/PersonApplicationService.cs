using Ms.Core.Domain;

namespace Ms.Core.ApplicationServices;

public class PersonApplicationService(IPersonRepository personRepository)
{
    private IPersonRepository PersonRepository { get; } = personRepository;

    public void AddPerson(CreatePersonInputDto createPersonInputDto)
    {
        PhoneNumber phoneNumber = new(createPersonInputDto.PhoneNumber);
        Person person = new(createPersonInputDto.FirstName, createPersonInputDto.LastName, phoneNumber);
        PersonRepository.Add(person);
    }

    public void AddNumberToPerson()
    {

    }
}

public interface IPersonRepository
{
    void Add(Person person);
}
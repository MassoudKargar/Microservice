﻿using Ms.Core.Domain;

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

    public void AddNumberToPerson(AddNumberToPersonInputDto inputDto)
    {
        var person = PersonRepository.Get(inputDto.PersonId);
        if (person == null)
        {
            throw new ApplicationException($"There is no person with id={inputDto.PersonId}");
        }

        PhoneNumber phoneNumber = new(inputDto.Number);
        person.AddPhoneNumber(phoneNumber);
        PersonRepository.Update(person);
    }
}
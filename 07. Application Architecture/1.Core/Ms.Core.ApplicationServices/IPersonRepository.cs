using Ms.Core.Domain;

namespace Ms.Core.ApplicationServices;

public interface IPersonRepository
{
    void Add(Person person);
    Person? Get(int id);
    void Update(Person person);
}
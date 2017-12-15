# Easy Specification Validator

#### Examples

There are some simple example Specifications and Validators within the EasySpecificationValidators.Tests project.

##### Sample Entity:

```CSharp
 public class Person
 {
    public int Age { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
 }
```

##### Sample Specifications/Rules:

```CSharp
public class MustBeAtLeast18Async : GenericSpecificationAsync<Person>
{
    public override Func<Person, Task<bool>> Rule => person =>
    {
        Task.Delay(2000); //Pretend async delay.
        return Task.FromResult(person.Age >= 18);
    };
}

public class MustNotBeBornInSeptember : GenericSpecificationAsync<Person>
{
    public override Fucn<Person, Task<bool>> Rule => person => 
    {
        Task.Deplay(2000); //Pretend async delay.
        return Task.FromResult(person.BirthDate.Month != 9);
    }
}
```


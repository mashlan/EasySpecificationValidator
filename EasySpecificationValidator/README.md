# Easy Specification Validator

#### Examples

There are some simple example Specifications and Validators within the EasySpecificationValidators.Tests project.
They are under the folder called Samples. This is as basic as you can get. If you want to do things like logging of which errors
and how it happened you would need to inherit from the interface `ISpecification`, `ISpecificationAsync`, `GenericSpecification`
or `GenericSpecifcationAsync` interfaces/classes and add your custom logic.

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

public class MustNotBeBornInSeptemberAsync : GenericSpecificationAsync<Entities.Person>
{
    public override Func<Entities.Person, Task<bool>> Rule => person =>
    {
        Task.Delay(2000); //Pretend async delay.
        return Task.FromResult(person.BirthDate.Month != 9);
    };
}
```

##### Sample Validation

```CSharp
public class PersonValidatorAsync : IValidatorAsync<Person>
{
    #region Implementation of IValidatorAsync<in Person>

    public async Task<bool> IsValidAsync(Person entity)
    {
        var mustBeAtLeast18 = new MustBeAtLeast18Async();
        var mustNotBeBornInSeptember = new MustNotBeBornInSeptemberAsync();

        return await mustBeAtLeast18.AndAsync(mustNotBeBornInSeptember).IsSatisfiedByAsync(entity);
    }

    #endregion
}
```

##### Usage in form of Test:
```CSharp
[TestClass]
public class SampleInUse
{
    private readonly PersonValidatorAsync validator;

    public SampleInUse()
    {
        validator = new PersonValidatorAsync();
    }

    [TestMethod]
    [Description("This person is under the age of 18, so validation fails.")]
    public async Task IsUnder18Fail()
    {
        var under18Person = new Person { Age = 17, BirthDate = DateTime.Now.AddYears(-17) };

        var isValid = await validator.IsValidAsync(under18Person);
        isValid.Should().BeFalse();
    }

    [TestMethod]
    [Description("This person is over the age of 18 but is born in September.")]
    public async Task IsBornInSeptemberFail()
    {
        var personBornInSept = new Person { Age = 35, BirthDate = new DateTime(1982, 9, 1) };

        var isValid = await validator.IsValidAsync(personBornInSept);
        isValid.Should().BeFalse();
    }

    [TestMethod]
    [Description("This person is over the age of 18 and is not born in September.")]
    public async Task ValidPerson()
    {
        var validPerson = new Person { Age = 35, BirthDate = new DateTime(1982, 11, 11) };

        var isValid = await validator.IsValidAsync(validPerson);
        isValid.Should().BeTrue();
    }
}
```


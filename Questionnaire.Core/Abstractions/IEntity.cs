namespace Questionnaire.Core.Abstractions
{
    interface IEntity<T>
    {
        T Id { get; set; }
    }
}

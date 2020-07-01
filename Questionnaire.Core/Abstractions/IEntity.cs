namespace Questionnaire.Core.Abstractions
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}

using BankAccount.Domain.Model.Entity;
using MediatR;
using System.Linq.Expressions;

public class QueryRequest<T> : IRequest<QueryResponse<T>>
{
    public IQueryable<T>? Items { get; set; }
    public IReadOnlyList<string>? Keys { get; set; }
    public T? Item { get; set; }
    public Expression<Func<T, bool>>? FilterExpression { get; set; }
    public EnumQueryReturnObjectType ReturnType { get; set; }
}

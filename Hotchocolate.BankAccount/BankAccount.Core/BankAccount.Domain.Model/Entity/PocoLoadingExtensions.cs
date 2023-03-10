using System.Runtime.CompilerServices;

namespace BankAccount.Domain.Model.Entity;

public static class PocoLoadingExtensions
{
    public static TRelated Load<TRelated>(this Action<object, string> loader, object entity, ref TRelated navigationField, [CallerMemberName] string? navigationName = null) where TRelated : class
    {
        if (navigationName != null) loader?.Invoke(entity, navigationName);

        return navigationField;
    }
}
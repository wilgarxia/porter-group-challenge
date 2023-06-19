namespace PorterGroup.Challenge;

public static class ListExtensions
{
    public static IList<T> RemoveDuplicates<T>(this IList<T> itens)
    {
        HashSet<T> hashSet = new(itens);
        List<T> distinctList = new(hashSet);

        return distinctList;
    }
}


public static class StackHelper
{
    public static Stack<T> Reverse<T>(this IStack<T> stack)
    {
        var other = new Stack<T>();
        while (!stack.IsEmpty())
        {
            other.Push(stack.Pop());
        }
        return other;
    }
}

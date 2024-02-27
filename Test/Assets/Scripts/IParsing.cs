public interface IParsing<out TOut, in TIn>
{
    public TOut Parse(TIn t);
}

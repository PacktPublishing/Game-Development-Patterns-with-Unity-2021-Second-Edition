namespace Pattern.Visitor
{
    public interface IVisitable
    { 
        void Accept(IVisitor visitor);
    }
}
namespace Tree.Entities;

public class Node
{
    public Guid Id { get; set; }

    public Guid? ParentId { get; set; }

    public Guid TreeId { get; set; }

    public string Name { get; set; }

    public virtual Tree Tree { get; set; }

}
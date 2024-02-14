namespace Tree.Entities;

public class Tree
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Node>? Nodes { get; set; }
}

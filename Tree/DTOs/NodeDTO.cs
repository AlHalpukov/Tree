namespace Tree.DTOs;

public class NodeDTO
{
    public Guid Id { get; set; }

    public string NodeName { get; set; }

    public List<NodeDTO>? Children { get; set; }
}

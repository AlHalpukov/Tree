﻿namespace Tree.DTOs;

public class TreeDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<NodeDTO>? Children { get; set; }
}

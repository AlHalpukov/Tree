using Tree.DTOs;

namespace Tree.Interfaces;

public interface ITreeRepository 
{
    Task<TreeDTO> GetOrCreateTree(string name);
}

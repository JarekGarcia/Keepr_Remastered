



namespace Keepr_Remastered.Services;

public class KeepsService
{
    public readonly KeepsRepository _repository;

    public KeepsService(KeepsRepository repository)
    {
        _repository = repository;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        Keep keep = _repository.CreateKeep(keepData);
        return keep;
    }

    internal string DeleteKeep(int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId);
        if (keep.CreatorId != userId)
        {
            throw new Exception($"{keep.Name} is not your keep to delete!");
        }
        _repository.DeleteKeep(keepId);
        return $"{keep.Name} has been deleted!";
    }

    internal Keep EditKeep(int keepId, string userId, Keep keepData)
    {
        Keep oldKeep = GetKeepById(keepId);
        if (oldKeep.CreatorId != userId)
        {
            throw new Exception($"{oldKeep.Name} is not your keep to edit!");
        }
        oldKeep.Name = keepData.Name ?? oldKeep.Name;
        oldKeep.Description = keepData.Description ?? oldKeep.Description;
        oldKeep.Img = keepData.Img ?? oldKeep.Img;

        Keep keep = _repository.EditKeep(oldKeep);
        return keep;
    }

    internal Keep GetKeepById(int keepId)
    {
        Keep keep = _repository.GetKeepById(keepId);
        return keep;
    }

    internal Keep GetKeepByIdAndIncrement(int keepId)
    {
        Keep keep = GetKeepById(keepId);
        keep.Views++;
        _repository.EditKeep(keep);
        return keep;
    }

    internal List<Keep> GetKeeps()
    {
        List<Keep> keeps = _repository.GetKeeps();
        return keeps;
    }
}
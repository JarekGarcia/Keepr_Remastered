
namespace Keepr_Remastered.Repositories;

public class KeepsRepository
{
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        string sql = @"
        INSERT INTO
        keeps (name, description, img, creatorId, views, kept)
        VALUES (@Name, @Description, @Img, @CreatorId, @Views, @Kept);

        SELECT 
        keeps.*,
        acc.*
        FROM keeps
        JOIN accounts acc ON acc.id = keeps.creatorId
        WHERE keeps.id = LAST_INSERT_ID()
        ;";

        Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
        {
            keep.Creator = profile;
            return keep;
        }, keepData).FirstOrDefault();
        return keep;
    }
}
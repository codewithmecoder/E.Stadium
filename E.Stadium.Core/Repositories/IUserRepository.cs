using E.Stadium.Abstraction.Data;
using E.Stadium.Core.Entities.Users;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Core.Repositories;

public interface IUserRepository : IRepository<UserEntity>
{
    Task AddAsync(UserEntity entity);
    Task UpdateAsync(UserEntity entity);
    Task<UserEntity?> GetAsync(Guid id);
    Task<PagedResult<UserEntity>> GetUsersAsync(bool isActive, int page, int result);
    Task RemoveAsync(Guid id);
    Task UpdateUserToStadiumRentalAsync(Guid id);
    Task<bool> ExistPhoneAsync(string phone);
    Task<UserEntity?> GetByPhoneAsync(string phone);
    Task SetResetPasswordTokenByUserId(Guid id, string token);
    Task SetResetPasswordTokenByPhone(string phone, string token);
    Task SetResetPasswordTokenByResetToken(string resetToken, string token);
    Task<UserEntity?> GetByResetTokenAsync(string token);
}

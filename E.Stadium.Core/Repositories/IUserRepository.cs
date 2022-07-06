using E.Stadium.Abstraction.Data;
using E.Stadium.Core.Entities.Users;

namespace E.Stadium.Core.Repositories;

public interface IUserRepository : IRepository<UserEntity>
{
    Task AddAsync(UserEntity entity);
    Task UpdateAsync(UserEntity entity);
    Task<UserEntity?> GetAsync(Guid id);
    Task RemoveAsync(Guid id);
    Task<bool> ExistPhoneAsync(string phone);
    Task<UserEntity?> GetByPhoneAsync(string phone);
    Task SetResetPasswordTokenByUserId(Guid id, string token);
    Task SetResetPasswordTokenByPhone(string phone, string token);
    Task SetResetPasswordTokenByResetToken(string resetToken, string token);
    Task<UserEntity?> GetByResetTokenAsync(string token);
}

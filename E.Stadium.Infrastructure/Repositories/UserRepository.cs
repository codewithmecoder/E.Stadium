using E.Stadium.Core.Entities.Users;
using E.Stadium.Core.Exceptions.User;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres;
using E.Stadium.Infrastructure.Postgres.User;
using E.Stadium.Shared.Postgres.Paginations;
using Microsoft.EntityFrameworkCore;

namespace Mip.Farm.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresRepository<UserTable> _repository;

    public UserRepository(IPostgresRepository<UserTable> repository)
    {
        _repository = repository;
    }
    public Task AddAsync(UserEntity entity)
        => _repository.AddAsync(entity.AsTable());

    public Task<bool> ExistPhoneAsync(string phone)
    {
        return _repository.ExistsAsync(x => x.Phone == phone);
    }

    public async Task<UserEntity?> GetAsync(Guid id)
    {
        var tb = await _repository.FirstOrDefaultAsync(id);
        return tb?.AsEntity();
    }

    public async Task<UserEntity?> GetByPhoneAsync(string phone)
    {
        var tb = await _repository.WhereAsync(x => x.Phone == phone);
        return tb.FirstOrDefault()?.AsEntity();
    }

    public async Task RemoveAsync(Guid id)
    {
        var tb = await _repository.FirstOrDefaultAsync(id);
        if (tb is null)
            throw new UserNotFoundException(id.ToString());
        tb.IsActive = false;
        await _repository.UpdateAsync(tb);
    }

    public async Task UpdateUserToStadiumRentalAsync(Guid id)
    {
        var tb = await _repository.FirstOrDefaultAsync(id);
        if (tb is null)
            throw new UserNotFoundException(id.ToString());
        if((tb.IsStadiumRental?? false) == false)
        {
            tb.IsStadiumRental = true;
            await _repository.UpdateAsync(tb);
        }
    }

    public Task SetResetPasswordTokenByUserId(Guid id, string token)
    {
        FormattableString sql = @$"UPDATE users SET reset_token = {token} where id = {id}";
        return _repository.Context.Database.ExecuteSqlInterpolatedAsync(sql);
    }

    public Task SetResetPasswordTokenByPhone(string phone, string token)
    {
        FormattableString sql = @$"UPDATE users SET reset_token = {token} where phone = {phone}";
        return _repository.Context.Database.ExecuteSqlInterpolatedAsync(sql);
    }

    public Task UpdateAsync(UserEntity entity)
        => _repository.UpdateAsync(entity.AsTable());

    public Task SetResetPasswordTokenByResetToken(string resetToken, string token)
    {
        FormattableString sql = @$"UPDATE users SET reset_token = {token} where reset_token = {resetToken}";
        return _repository.Context.Database.ExecuteSqlInterpolatedAsync(sql);
    }

    public async Task<UserEntity?> GetByResetTokenAsync(string token)
    {
        var tb = await _repository.WhereAsync(x => x.ResetToken == token);
        return tb.FirstOrDefault()?.AsEntity();
    }

    public async Task<PagedResult<UserEntity>> GetUsersAsync(bool isActive, int page, int result)
    {
        var data = await _repository.BrowseAsync(i => i.IsActive == isActive, new PagedQueryBase { Page = page, Limit = result });
        return data.Map(i => i.AsEntity());
    }

}

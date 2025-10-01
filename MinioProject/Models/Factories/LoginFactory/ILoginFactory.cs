namespace Models.Factories
{
    public interface ILoginFactory
    {
        Task<LoginResultDto> CreateLoginAsync(LoginDto loginDto);
    }
}
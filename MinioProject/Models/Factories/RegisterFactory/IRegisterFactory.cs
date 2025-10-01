namespace Models.Factories
{
    public interface IRegisterFactory
    {
        Task<AuthResultDto> RegisterAsync(RegisterDto registerDto);
    }
}
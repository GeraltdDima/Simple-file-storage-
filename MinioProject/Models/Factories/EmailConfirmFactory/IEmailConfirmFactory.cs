namespace Models.Factories
{
    public interface IEmailConfirmFactory
    {
        Task<EmailConfirmDto> CreateEmailConfirmAsync(User user);
    }
}
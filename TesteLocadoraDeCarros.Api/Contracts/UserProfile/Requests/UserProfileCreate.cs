namespace TesteLocadoraDeCarros.Api.Contracts.UserProfile.Requests
{
    public record UserProfileCreate
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
    }
}

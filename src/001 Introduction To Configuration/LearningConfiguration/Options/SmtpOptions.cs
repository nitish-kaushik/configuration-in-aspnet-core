namespace LearningConfiguration.Options;

public class SmtpOptions
{
    public int Port { get; set; }
    public string SenderEmail { get; set; } = null!;
}

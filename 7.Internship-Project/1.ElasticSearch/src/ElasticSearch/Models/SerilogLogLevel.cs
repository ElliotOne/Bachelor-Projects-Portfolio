namespace ElasticSearch.Models
{
    /// <summary>
    /// Log level defined by ElasticSearch , default ASP.Net Core log level are not completely compatible.
    /// </summary>
    public enum SerilogLogLevel
    {
        Information,
        Warning,
        Error,
        Critical,
        None,
    }
}
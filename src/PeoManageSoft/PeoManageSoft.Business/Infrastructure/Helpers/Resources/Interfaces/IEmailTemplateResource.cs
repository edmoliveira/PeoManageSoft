using System.Text;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces
{
    /// <summary>
    /// Email template data
    /// </summary>
    internal interface IEmailTemplateResource
    {
        #region Properties

        /// <summary>
        /// Files directory
        /// </summary>
        string Directory { get; }
        /// <summary>
        /// Html file name
        /// </summary>
        string HtmlFileName { get; }
        /// <summary>
        ///  Subject file name
        /// </summary>
        string SubjectFileName { get; }

        #endregion

        #region Methods public

        /// <summary>
        /// Reads the html file context.
        /// </summary>
        /// <param name="language">Specifies the language of the file.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>File context</returns>
        string ReadHtmlFile(ApplicationLanguage language, Encoding encoding = null);

        /// <summary>
        /// Reads the subject file context.
        /// </summary>
        /// <param name="language">Specifies the language of the file.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>File context</returns>
        string ReadSubjectFile(ApplicationLanguage language, Encoding encoding = null);

        #endregion
    }
}

using PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces;
using System.Text;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Resources
{
    /// <summary>
    /// Email template data
    /// </summary>
    public sealed class EmailTemplateResource: IEmailTemplateResource
    {
        #region Properties

        /// <summary>
        /// Files directory
        /// </summary>
        public string Directory { get; set; }
        /// <summary>
        /// Html file name
        /// </summary>
        public string HtmlFileName { get; set; }
        /// <summary>
        ///  Subject file name
        /// </summary>
        public string SubjectFileName { get; set; }

        #endregion

        #region Methods public

        /// <summary>
        /// Reads the html file context.
        /// </summary>
        /// <param name="language">Specifies the language of the file.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>File context</returns>
        public string ReadHtmlFile(ApplicationLanguage language, Encoding encoding = null)
        {
            string fileFullName = Path.Combine(Directory, HtmlFileName.Replace("{language}", language.ToString()));

            return encoding != null ? File.ReadAllText(fileFullName, encoding) : File.ReadAllText(fileFullName);
        }

        /// <summary>
        /// Reads the subject file context.
        /// </summary>
        /// <param name="language">Specifies the language of the file.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>File context</returns>
        public string ReadSubjectFile(ApplicationLanguage language, Encoding encoding = null)
        {
            string fileFullName = Path.Combine(SubjectFileName, HtmlFileName.Replace("{language}", language.ToString()));

            return encoding != null ? File.ReadAllText(fileFullName, encoding) : File.ReadAllText(fileFullName);
        }

        #endregion
    }
}

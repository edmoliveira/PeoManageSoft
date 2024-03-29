﻿using System.ComponentModel;

namespace PeoManageSoft.Business.Infrastructure
{
    #region Enumerators

    /// <summary>
    /// Specifies the language of the application.
    /// </summary>
    public enum ApplicationLanguage
    {
        /// <summary>
        /// English
        /// </summary>
        [Description("English")]
        English,
        /// <summary>
        /// Portuguese
        /// </summary>
        [Description("Portuguese")]
        Portuguese,
    }

    /// <summary>
    /// Resource message key.
    /// </summary>
    public enum ResourceMessageKey
    {
        /// <summary>
        /// Required
        /// </summary>
        [Description("Required")]
        Required,
        /// <summary>
        /// Invalid email
        /// </summary>
        [Description("Invalid email")]
        InvalidEmail,
        /// <summary>
        /// Invalid Uri
        /// </summary>
        [Description("Invalid Uri")]
        InvalidUri,
        /// <summary>
        /// The values do not match!
        /// </summary>
        [Description("Not Match")]
        NotMatch,
        /// <summary>
        /// Minimum Length
        /// </summary>
        [Description("Minimum Length")]
        MinimumLength,
        /// <summary>
        /// Already Exists
        /// </summary>
        [Description("Already Exists")]
        AlreadyExists,
        /// <summary>
        /// No Exists
        /// </summary>
        [Description("No Exists")]
        NoExists,
        /// <summary>
        /// Password length error message
        /// </summary>
        [Description("Password length error message")]
        PasswordLength,
        /// <summary>
        /// Password uppercase letter error message
        /// </summary>
        [Description("Password uppercase letter error message")]
        PasswordUppercaseLetter,
        /// <summary>
        /// Password lowercase letter error message
        /// </summary>
        [Description("Password lowercase letter error message")]
        PasswordLowercaseLetter,
        /// <summary>
        /// Password digit error message
        /// </summary>
        [Description("Password digit error message")]
        PasswordDigit,
        /// <summary>
        /// Password special character error message
        /// </summary>
        [Description("Password special character error message")]
        PasswordSpecialCharacter,
        /// <summary>
        /// Unauthorized
        /// </summary>
        [Description("Unauthorized")]
        Unauthorized,
        /// <summary>
        /// Expired Token
        /// </summary>
        [Description("Expired Token")]
        ExpiredToken,
        /// <summary>
        /// Not Found
        /// </summary>
        [Description("Not Found")]
        NotFound,
        /// <summary>
        /// Greater Than
        /// </summary>
        [Description("Greater Than")]
        GreaterThan,
    }

    /// <summary>
    /// Relational Database Type
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// Sql Server
        /// </summary>
        [Description("SqlServer")]
        SqlServer = 0,
        /// <summary>
        /// PostgreSQL 
        /// </summary>
        [Description("PostgreSQL")]
        PostgreSQL = 1,
        /// <summary>
        /// MySql 
        /// </summary>
        [Description("MySql")]
        MySql = 2,
    }

    /// <summary>
    /// Transaction status
    /// </summary>ype
    public enum TransactionStatus
    {
        /// <summary>
        /// Indicates that the transaction was not initialized.
        /// </summary>
        [Description("None")]
        None = 0,
        /// <summary>
        /// Indicates that the transaction was initialized.
        /// </summary>
        [Description("Initialized")]
        Initialized = 1,
        /// <summary>
        /// Indicates that the transaction was committed. 
        /// </summary>
        [Description("Committed")]
        Committed = 2,
        /// <summary>
        /// Indicates that the transaction was rolled back. 
        /// </summary>
        [Description("Committed")]
        RolledBack = 3,
    }

    /// <summary>
    /// Operator of the sql.
    /// </summary>
    public enum SqlOperator
    {
        /// <summary>
        /// And
        /// </summary>
        [Description("And")]
        And = 0,
        /// <summary>
        /// Or 
        /// </summary>
        [Description("Or")]
        Or = 1,
        /// <summary>
        /// Not 
        /// </summary>
        [Description("Not")]
        Not = 2,
    }

    /// <summary>
    /// Comparison operator of SQL
    /// </summary>
    public enum SqlComparisonOperator
    {
        /// <summary>
        /// = 
        /// </summary>
        [Description("EqualTo")]
        EqualTo = 0,
        /// <summary>
        /// > 
        /// </summary>
        [Description("GreaterThan")]
        GreaterThan = 1,
        /// <summary>
        /// < 
        /// </summary>
        [Description("LessThan")]
        LessThan = 2,
        /// <summary>
        /// >=	 
        /// </summary>
        [Description("GreaterThanOrEqualTo")]
        GreaterThanOrEqualTo = 3,
        /// <summary>
        /// <=	 
        /// </summary>
        [Description("LessThanOrEqualTo")]
        LessThanOrEqualTo = 4,
        /// <summary>
        /// <> 
        /// </summary>
        [Description("NotEqualTo")]
        NotEqualTo = 5,
        /// <summary>
        /// In 
        /// </summary>
        [Description("In")]
        In = 6,
        /// <summary>
        /// Like 
        /// </summary>
        [Description("Like")]
        Like = 7,
    }

    /// <summary>
    /// Specifies the priority of a System.Net.Mail.MailMessage.
    /// </summary>
    public enum EmailPriority
    {
        /// <summary>
        /// The email has normal priority.
        /// </summary>
        [Description("Normal")]
        Normal = 0,
        /// <summary>
        /// The email has low priority.
        /// </summary>
        [Description("Low")]
        Low = 1,
        /// <summary>
        /// The email has high priority.
        /// </summary>
        [Description("High")]
        High = 2
    }

    /// <summary>
    /// Specifies the Content-Transfer-Encoding header information for an email message attachment.
    /// </summary> 
    public enum TransferEncoding
    {
        /// <summary>
        /// Indicates that the transfer encoding is unknown.
        /// </summary>   
        [Description("Unknown")]
        Unknown = -1,
        /// <summary>
        /// Encodes data that consists of 
        /// set. See RFC 2406 Section 6.7.
        /// </summary>  
        [Description("QuotedPrintable")]
        QuotedPrintable = 0,
        /// <summary>
        /// Encodes stream-based data. See RFC 2406 Section 6.8.
        /// </summary>  
        [Description("Base64")]
        Base64 = 1,
        /// <summary>
        /// Used for data that is not encoded. The data is in 7-bit US-ASCII characters with
        /// a total line length of no longer than 1000 characters. See RFC2406 Section 2.7.
        /// </summary>  
        [Description("SevenBit")]
        SevenBit = 2,
        /// <summary>
        /// The data is in 8-bit characters that may represent international characters with
        /// a total line length of no longer than 1000 8-bit characters. For more information
        /// about this 8-bit MIME transport extension, see IETF RFC 6152.
        /// </summary>   
        [Description("EightBit")]
        EightBit = 3
    }

    /// <summary>
    /// Describes the delivery notification options for email.
    /// </summary> 
    public enum DeliveryNotificationOptions
    {
        /// <summary>
        /// No notification information will be sent. The mail server will utilize its configured
        /// behavior to determine whether it should generate a delivery notification.
        /// </summary> 
        [Description("None")]
        None = 0,
        /// <summary>
        /// Notify if the delivery is successful.
        /// </summary>
        [Description("OnSuccess")]
        OnSuccess = 1,
        /// <summary>
        /// Notify if the delivery is unsuccessful.
        /// </summary>
        [Description("OnFailure")]
        OnFailure = 2,
        /// <summary>
        ///  Notify if the delivery is delayed.
        /// </summary>
        [Description("Delay")]
        Delay = 4,
        /// <summary>
        /// A notification should not be generated under any circumstances.
        /// </summary>
        [Description("Never")]
        Never = 134217728
    }

    #endregion
}

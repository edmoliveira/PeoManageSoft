using Microsoft.Extensions.Caching.Distributed;
using PeoManageSoft.Business.Infrastructure.Tokens;
using System.Text;

namespace PeoManageSoft.Business.Infrastructure.Helpers
{
    /// <summary>
    /// Token Cache
    /// </summary>
    internal sealed class TokenCache : ITokenCache
    {
        #region Fields

        /// <summary>
        /// Represents a distributed cache of serialized values.
        /// </summary>
        private readonly IDistributedCache _distributedCache;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distributedCache">Represents a distributed cache of serialized values.</param>
        public TokenCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Checks if the token exists  in the cache.
        /// </summary>
        /// <param name="tokenKey">Token Key</param>
        /// <returns>If the token exists  in the cache, it returns true.</returns>
        public async Task<bool> CheckHasTokenAsync(string tokenKey)
        {
            byte[] value = await _distributedCache.GetAsync(tokenKey).ConfigureAwait(false);

            return value?.Length > 0;
        }

        /// <summary>
        /// Gets the token in the cache.
        /// </summary>
        /// <param name="tokenKey">Token Key</param>
        /// <returns>Security token</returns>
        public async Task<string> GetTokenAsync(string tokenKey)
        {
            byte[] value = await _distributedCache.GetAsync(tokenKey).ConfigureAwait(false);

            return value?.Length > 0 ? ConvertBytesToString(value) : null;
        }

        /// <summary>
        /// Saves the token in the cache.
        /// </summary>
        /// <param name="tokenKey">Token Key</param>
        /// <param name="securityToken">Security token</param>
        /// <param name="expires">The value of the 'expiration' claim.</param>
        public async Task SetTokenAsync(string tokenKey, string securityToken, DateTime expires)
        {
            await _distributedCache.SetAsync(tokenKey, ConvertStringToBytes(securityToken), new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromTicks(expires.Ticks)
            }).ConfigureAwait(false);
        }

        #endregion

        #region private

        /// <summary>
        /// Convert a string to a byte array containing the results of encoding the specified set of characters
        /// </summary>
        /// <param name="value">The string containing the characters to encode.</param>
        /// <returns>A byte array containing the results of encoding the specified set of characters</returns>
        private static byte[] ConvertStringToBytes(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        /// <summary>
        /// Decodes a specified number of bytes starting at a specified address into a string.
        /// </summary>
        /// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
        /// <returns>A string that contains the results of decoding the specified sequence of bytes.</returns>
        private static string ConvertBytesToString(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }

        #endregion

        #endregion
    }
}

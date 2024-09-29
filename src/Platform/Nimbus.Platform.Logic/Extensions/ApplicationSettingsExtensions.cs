using Microsoft.Extensions.Options;

using Nimbus.Platform.Domain.Options;

namespace Nimbus.Platform.Logic.Extensions
{
    /// <summary>
    /// A collection of extensions for the application settings.
    /// </summary>
    public static class ApplicationSettingsExtensions
    {
        /// <summary>
        /// Tries to get the <paramref name="key"/> application setting from the provided <paramref name="settings"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// The type of value to get from the application settings.
        /// </typeparam>
        /// <param name="settings">
        /// The application settings to get a setting from.
        /// </param>
        /// <param name="key">
        /// The key of the setting to get.
        /// </param>
        /// <returns>
        /// The <typeparamref name="TValue"/> from the application settings if it exists, <c>default</c> otherwise.
        /// </returns>
        public static TValue? GetSetting<TValue>(this IOptions<ApplicationSettings<TValue>> settings, string key)
        {
            if (!settings.KeyExists(key))
            {
                return default;
            }

            return settings.Value[key];
        }

        /// <summary>
        /// Checks if the <paramref name="key"/> exists for the <paramref name="settings"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// The value stored in the <paramref name="settings"/>.
        /// </typeparam>
        /// <param name="settings">
        /// The application settings to check.
        /// </param>
        /// <param name="key">
        /// The <paramref name="settings"/> key to check for.
        /// </param>
        /// <returns>
        /// <c>true</c> if the <paramref name="key"/> exists in the <paramref name="settings"/>,
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool KeyExists<TValue>(this IOptions<ApplicationSettings<TValue>> settings, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            return settings.Value.ContainsKey(key);
        }
    }
}

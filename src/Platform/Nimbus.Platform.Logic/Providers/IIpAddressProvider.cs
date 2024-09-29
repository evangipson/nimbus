using System.Net;

namespace Nimbus.Platform.Logic.Providers
{
    /// <summary>
    /// A provider that interacts with an <see cref="IPAddress"/>.
    /// </summary>
    public interface IIpAddressProvider
    {
        /// <summary>
        /// Gets the local public <see cref="IPAddress"/> using <see cref="Dns"/>.
        /// <para>
        /// Will throw an <see cref="InvalidOperationException"/> if the <see cref="IPAddress"/>
        /// can not be found.
        /// </para>
        /// </summary>
        /// <returns>
        /// The local public <see cref="IPAddress"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException"></exception>
        IPAddress GetPublicIpAddress();
    }
}

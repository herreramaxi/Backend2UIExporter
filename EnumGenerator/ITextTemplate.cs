using System;

namespace Backend2UIExporter
{
    public interface ITextTemplate
    {
        /// <summary>
        /// Generate the output text of the transformation.
        /// </summary>
        /// <returns>
        /// Throws <see cref="NotImplementedException"/>.
        /// After build, it should be overridden by the implementation.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Throws when the default implementation is called.
        /// </exception>
        string TransformText() => throw new NotImplementedException();
    }
}

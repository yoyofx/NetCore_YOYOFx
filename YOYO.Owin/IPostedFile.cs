using System.IO;

namespace YOYO.Owin
{
    /// <summary>
    /// Represents a file uploaded over HTTP.
    /// </summary>
    internal interface IPostedFile
    {
        /// <summary>
        /// Gets the size of an uploaded file, in bytes.
        /// </summary>
        /// <returns>
        /// The file length, in bytes.
        /// </returns>
        int ContentLength { get; }

        /// <summary>
        /// Gets the MIME content type of a file sent by a client.
        /// </summary>
        /// <returns>
        /// The MIME content type of the uploaded file.
        /// </returns>
        string ContentType { get; }

        /// <summary>
        /// Gets the field name this file is associated with within the form.
        /// </summary>
        string FieldName { get; }

        /// <summary>
        /// Gets the fully qualified name of the file on the client.
        /// </summary>
        /// <returns>
        /// The name of the client's file, including the directory path.
        /// </returns>
        string FileName { get; }

        /// <summary>
        /// Gets a <see cref="T:System.IO.Stream"/> object that points to an uploaded file to prepare for reading the contents of the file.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.IO.Stream"/> pointing to a file.
        /// </returns>
        Stream InputStream { get; }

        //todo: Support ContentRange
    }
}
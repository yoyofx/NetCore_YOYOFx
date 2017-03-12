using System;
using System.Collections.ObjectModel;

namespace YOYO.AspNetCore.Owin
{
    /// <summary>
    /// Represents the HTTP Status Code returned by a Handler.
    /// </summary>
    /// <remarks>Has an implicit cast from <see cref="int"/>.</remarks>
    public class Status : IEquatable<Status>
    {
        private readonly int _httpStatusCode;
        private readonly string _httpStatusDescription;
        private readonly string _locationHeader;

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> struct.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="httpStatusDescription">The HTTP status description.</param>
        /// <param name="locationHeader">Redirection Url</param>
        public Status(int httpStatusCode, string httpStatusDescription = null, string locationHeader = null) {
            _httpStatusCode = httpStatusCode;
            _httpStatusDescription = httpStatusDescription;
            _locationHeader = locationHeader;
        }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        public int Code {
            get { return _httpStatusCode; }
        }

        /// <summary>
        /// Gets the HTTP status description.
        /// </summary>
        public string Description {
            get { return _httpStatusDescription; }
        }

        public bool IsError {
            get { return _httpStatusCode >= 400 && _httpStatusCode <= 599; }
        }

        /// <summary>
        /// Gets a value indicating whether this Status represents success.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this Status represents success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess {
            get { return _httpStatusCode >= 200 && _httpStatusCode <= 299; }
        }

        public string LocationHeader {
            get { return _locationHeader; }
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Status other) {
            if (other == null) {
                return false;
            }
            return _httpStatusCode == other._httpStatusCode;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (obj.GetType() != typeof(Status)) {
                return false;
            }
            return Equals((Status)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() {
            return _httpStatusCode;
        }

        public string ToHttp11StatusLine() {
            return string.Format("HTTP/1.1 {0} {1}\r\n", _httpStatusCode, _httpStatusDescription);
        }

        /// <summary>
        /// Returns an HTTP formatted representation of the <see cref="Status"/>.
        /// </summary>
        /// <returns>
        /// E.g. <c>200 OK</c> or <c>404 Not Found</c>.
        /// </returns>
        public override string ToString() {
            return string.Format("{0} {1}", Code, Description);
        }

        private static readonly StatusLookup Lookup = new StatusLookup();

        public static class Is
        {
            static Is() {
                //200s
                Lookup.Add(OK);
                Lookup.Add(Created);
                Lookup.Add(Accepted);
                Lookup.Add(NonAuthoritativeInformation);
                Lookup.Add(NoContent);
                Lookup.Add(ResetContent);
                Lookup.Add(PartialContent);

                //300s
                Lookup.Add(NotModified);

                //400s
                Lookup.Add(BadRequest);
                Lookup.Add(Conflict);
                Lookup.Add(Forbidden);
                Lookup.Add(NotFound);
                Lookup.Add(Gone);
                Lookup.Add(UnsupportedMediaType);

                //500s
                Lookup.Add(InternalServerError);
                Lookup.Add(NotImplemented);
            }

            /// <summary>
            /// Indicated requerst accepted for processing, but the processing has not been completed.
            /// </summary>
            public static readonly Status Accepted = new Status(202, "Accepted");

            /// <summary>
            /// Indicates that the request cannot be fulfilled due to bad syntax.
            /// </summary>
            public static readonly Status BadRequest = new Status(400, "Bad Request");

            /// <summary>
            /// Indicates that a PUT or POST request conflicted with an existing resource.
            /// </summary>
            public static readonly Status Conflict = new Status(409, "Conflict");

            /// <summary>
            /// Indicates that a request was processed successfully and a new resource was created.
            /// </summary>
            public static readonly Status Created = new Status(201, "Created");

            /// <summary>
            /// Indicates that the request was a valid request, but the server is refusing to respond to it.
            /// </summary>
            public static readonly Status Forbidden = new Status(403, "Forbidden");

            /// <summary>
            /// Indicates that the resource requested is no longer available and will not be available again.
            /// </summary>
            public static readonly Status Gone = new Status(410, "Gone");

            /// <summary>
            /// Indicates that everything is horrible, and you should hide in a cupboard until it's all over.
            /// </summary>
            public static readonly Status InternalServerError = new Status(500, "Internal Server Error");

            /// <summary>
            /// Nothing to see here.
            /// </summary>
            public static readonly Status NoContent = new Status(204, "No Content");

            public static readonly Status NonAuthoritativeInformation = new Status(203, "Non-Authoritative Information");

            /// <summary>
            /// Indicates that the requested resource could not be found.
            /// </summary>
            public static readonly Status NotFound = new Status(404, "Not Found");

            public static readonly Status NotImplemented = new Status(501, "Not Implemented");

            /// <summary>
            /// Not modified since last request. Using headers If-Modified-Since or If-Match
            /// </summary>
            public static readonly Status NotModified = new Status(304, "Not Modified");

            /// <summary>
            /// The basic "everything's OK" status.
            /// </summary>
            public static readonly Status OK = new Status(200, "OK");

            public static readonly Status PartialContent = new Status(206, "Partial Content");

            public static readonly Status ResetContent = new Status(205, "Reset Content");

            /// <summary>
            /// Indicates that the request entity has a media type which the server or resource does not support.
            /// </summary>
            public static readonly Status UnsupportedMediaType = new Status(415, "Unsupported Media Type");

            /// <summary>
            /// Indicated requerst accepted for processing, but the processing has not been completed. The
            /// location is the URL used to check it's status.
            /// </summary>
            public static Status AcceptedRedirect(string location) {
                return new Status(202, "Accepted", location);
            }

            /// <summary>
            /// Indicates that a request was processed successfully and a new resource was created.
            /// </summary>
            /// <param name="location">The redirect location.</param>
            /// <returns></returns>
            public static Status CreatedRedirect(string location) {
                return new Status(201, "Created", location);
            }

            /// <summary>
            /// A redirect to another resource, but telling the client to continue to use this URI for future requests.
            /// </summary>
            public static Status Found(string location) {
                return new Status(302, "Found", location);
            }

            /// <summary>
            /// A redirect to another resource, telling the client to use the new URI for all future requests.
            /// </summary>
            public static Status MovedPermanently(string location) {
                return new Status(301, "Moved Permanently", location);
            }

            /// <summary>
            /// A redirect to another resource, commonly used after a POST operation to prevent refreshes.
            /// </summary>
            public static Status SeeOther(string location) {
                return new Status(303, "See Other", location);
            }

            /// <summary>
            /// A Temporary redirect, e.g. for a login page.
            /// </summary>
            public static Status TemporaryRedirect(string location) {
                return new Status(307, "Temporary Redirect", location);
            }

            public static Status UseProxy(string location) {
                return new Status(305, "Use Proxy", location);
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Status left, Status right) {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Status left, Status right) {
            return !(left == right);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="Status"/>.
        /// </summary>
        /// <param name="httpStatus">The HTTP status code.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Status(int httpStatus) {
            return Lookup.Contains(httpStatus) ? Lookup[httpStatus] : new Status(httpStatus);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32" /> to <see cref="Status" />.
        /// </summary>
        /// <param name="source">The string source.</param>
        /// <returns>A <see cref="Status"/> object for the specified status.</returns>
        /// <example>
        /// Status status = 404 + "Not Found";
        /// </example>
        /// <exception cref="System.InvalidCastException"></exception>
        public static implicit operator Status(string source) {
            try {
                return new Status(int.Parse(source.Substring(0, 3)),
                                  source.Substring(3)
                                        .Trim());
            }
            catch (Exception) {
                throw new InvalidCastException(
                    "Status can only be implicitly cast from an integer, or a string of the format 'nnnSss...s', e.g. '404Not Found'.");
            }
        }

        private class StatusLookup : KeyedCollection<int, Status>
        {
            protected override int GetKeyForItem(Status item) {
                return item.Code;
            }
        }
    }
}
﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNetCore.Authentication
{
    /// <summary>
    /// Contains the result of an Authenticate call
    /// </summary>
    public class HandleRequestResult : AuthenticateResult
    {
        /// <summary>
        /// Indicates that stage of authentication was directly handled by
        /// user intervention and no further processing should be attempted.
        /// </summary>
        public bool Handled { get; private set; }

        /// <summary>
        /// Indicates that the default authentication logic should be
        /// skipped and that the rest of the pipeline should be invoked.
        /// </summary>
        public bool Skipped { get; private set; }

        /// <summary>
        /// Indicates that authentication was successful.
        /// </summary>
        /// <param name="ticket">The ticket representing the authentication result.</param>
        /// <returns>The result.</returns>
        public static new HandleRequestResult Success(AuthenticationTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }
            return new HandleRequestResult() { Ticket = ticket };
        }

        /// <summary>
        /// Indicates that there was a failure during authentication.
        /// </summary>
        /// <param name="failure">The failure exception.</param>
        /// <returns>The result.</returns>
        public static new HandleRequestResult Fail(Exception failure)
        {
            return new HandleRequestResult() { Failure = failure };
        }

        /// <summary>
        /// Indicates that there was a failure during authentication.
        /// </summary>
        /// <param name="failureMessage">The failure message.</param>
        /// <returns>The result.</returns>
        public static new HandleRequestResult Fail(string failureMessage)
        {
            return new HandleRequestResult() { Failure = new Exception(failureMessage) };
        }

        /// <summary>
        /// Indicates that there was no information returned for this authentication scheme.
        /// </summary>
        /// <returns>The result.</returns>
        public static new HandleRequestResult None()
        {
            return new HandleRequestResult() { Nothing = true };
        }

        /// <summary>
        /// Discontinue all processing for this request and return to the client.
        /// The caller is responsible for generating the full response.
        /// </summary>
        /// <returns>The result.</returns>
        public static HandleRequestResult Handle()
        {
            return new HandleRequestResult() { Handled = true };
        }

        /// <summary>
        /// Discontinue processing the request in the current handler.
        /// </summary>
        /// <returns>The result.</returns>
        public static HandleRequestResult SkipRequest()
        {
            return new HandleRequestResult() { Skipped = true };
        }
    }
}

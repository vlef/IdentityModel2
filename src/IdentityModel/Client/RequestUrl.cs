﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityModel.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace IdentityModel.Client
{
    /// <summary>
    /// Helper class for creating authorize request URLs
    /// </summary>
    public class RequestUrl
    {
        private readonly string _baseUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestUrl"/> class.
        /// </summary>
        /// <param name="baseUrl">The authorize endpoint.</param>
        public RequestUrl(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// Creates URL based on key/value input pairs.
        /// </summary>
        /// <param name="values">The values (either as a Dictionary of string/string or as a type with properties).</param>
        /// <returns></returns>
        public string Create(object values)
        {
            var dictionary = ValuesHelper.ObjectToDictionary(values);
            if (dictionary == null || !dictionary.Any())
            {
                return _baseUrl;
            }

            var qs = string.Join("&", dictionary.Select(kvp => string.Format("{0}={1}", WebUtility.UrlEncode(kvp.Key), WebUtility.UrlEncode(kvp.Value))).ToArray());
            return string.Format("{0}?{1}", _baseUrl, qs);
        }
    }
}
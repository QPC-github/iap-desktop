﻿//
// Copyright 2020 Google LLC
//
// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.
//

using Google.Solutions.IapDesktop.Application.Services.Authorization;
using System;

namespace Google.Solutions.IapDesktop.Extensions.Shell.Views.Credentials
{
    internal static class AuthorizationExtensions
    {
        public static string SuggestWindowsUsername(this IAuthorization authorization)
        {
            try
            {
                return SamAccountName.FromGoogleEmailAddress(authorization.Email);
            }
            catch (ArgumentException)
            {
                // Such an email should never surface, but revert
                // to using the local Windows username then.
                return Environment.UserName;
            }
        }
    }
}

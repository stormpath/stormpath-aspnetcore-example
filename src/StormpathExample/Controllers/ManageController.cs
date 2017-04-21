// <copyright file="ManageController.cs" company="Stormpath, Inc.">
// Copyright (c) 2016 Stormpath, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stormpath.Owin.Abstractions;

namespace StormpathExample.Controllers
{
    // This API controller is protected and requires the user to be logged in.
    // For authorization policies, see the comments in Startup.
    [Authorize]
    public class ManageController : Controller
    {
        private readonly ICompatibleOktaAccount _account;

        public ManageController(Lazy<ICompatibleOktaAccount> account)
        {
            // Stormpath request objects injected via DI
            _account = account.Value;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}

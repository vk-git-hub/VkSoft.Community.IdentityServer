/*
 Copyright (c) 2026 VkSoft.Community - https://github.com/vk-git-hub/VkSoft.Community.IdentityServer/

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code and license this software can be found 

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.
*/

using IdentityServer10.Models;

namespace IdentityServer10.EntityFramework.Mappers
{
    public static class IdentityResourceMappers
    {
        public static Models.IdentityResource ToModel(this Entities.IdentityResource entity)
        {
            if (entity == null) return null;

            return new Models.IdentityResource
            {
                Enabled = entity.Enabled,
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Description = entity.Description,
                Required = entity.Required,
                Emphasize = entity.Emphasize,
                ShowInDiscoveryDocument = entity.ShowInDiscoveryDocument,
                UserClaims = entity.UserClaims == null
                    ? new HashSet<string>()
                    : new HashSet<string>(entity.UserClaims.Select(x => x.Type)),
                Properties = entity.Properties == null
                    ? new Dictionary<string, string>()
                    : entity.Properties.ToDictionary(x => x.Key, x => x.Value)
            };
        }

        public static Entities.IdentityResource ToEntity(this Models.IdentityResource model)
        {
            if (model == null) return null;

            return new Entities.IdentityResource
            {
                Enabled = model.Enabled,
                Name = model.Name,
                DisplayName = model.DisplayName,
                Description = model.Description,
                Required = model.Required,
                Emphasize = model.Emphasize,
                ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
                UserClaims = model.UserClaims?
                    .Select(x => new Entities.IdentityResourceClaim { Type = x })
                    .ToList(),
                Properties = model.Properties?
                    .Select(x => new Entities.IdentityResourceProperty { Key = x.Key, Value = x.Value })
                    .ToList()
            };
        }
    }
}

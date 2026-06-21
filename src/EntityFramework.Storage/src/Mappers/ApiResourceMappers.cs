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
    public static class ApiResourceMappers
    {
        public static Models.ApiResource ToModel(this Entities.ApiResource entity)
        {
            if (entity == null) return null;

            return new Models.ApiResource
            {
                Enabled = entity.Enabled,
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Description = entity.Description,
                ShowInDiscoveryDocument = entity.ShowInDiscoveryDocument,
                AllowedAccessTokenSigningAlgorithms = AllowedSigningAlgorithmsConverter.ConvertToCollection(entity.AllowedAccessTokenSigningAlgorithms),
                ApiSecrets = entity.Secrets?
                    .Select(ToModel)
                    .ToHashSet() ?? new HashSet<Secret>(),
                Scopes = entity.Scopes == null
                    ? new HashSet<string>()
                    : new HashSet<string>(entity.Scopes.Select(x => x.Scope)),
                UserClaims = entity.UserClaims == null
                    ? new HashSet<string>()
                    : new HashSet<string>(entity.UserClaims.Select(x => x.Type)),
                Properties = entity.Properties == null
                    ? new Dictionary<string, string>()
                    : entity.Properties.ToDictionary(x => x.Key, x => x.Value)
            };
        }

        public static Entities.ApiResource ToEntity(this Models.ApiResource model)
        {
            if (model == null) return null;

            return new Entities.ApiResource
            {
                Enabled = model.Enabled,
                Name = model.Name,
                DisplayName = model.DisplayName,
                Description = model.Description,
                ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
                AllowedAccessTokenSigningAlgorithms = AllowedSigningAlgorithmsConverter.ConvertToString(model.AllowedAccessTokenSigningAlgorithms),
                Secrets = model.ApiSecrets?
                    .Select(ToEntity)
                    .ToList(),
                Scopes = model.Scopes?
                    .Select(x => new Entities.ApiResourceScope { Scope = x })
                    .ToList(),
                UserClaims = model.UserClaims?
                    .Select(x => new Entities.ApiResourceClaim { Type = x })
                    .ToList(),
                Properties = model.Properties?
                    .Select(x => new Entities.ApiResourceProperty { Key = x.Key, Value = x.Value })
                    .ToList()
            };
        }

        private static Models.Secret ToModel(Entities.ApiResourceSecret src)
        {
            var dest = new Models.Secret();
            dest.Description = src.Description;
            dest.Value = src.Value;
            dest.Expiration = src.Expiration;
            dest.Type = src.Type ?? "SharedSecret";
            return dest;
        }

        private static Entities.ApiResourceSecret ToEntity(Models.Secret src)
        {
            return new Entities.ApiResourceSecret
            {
                Description = src.Description,
                Value = src.Value,
                Expiration = src.Expiration,
                Type = src.Type
            };
        }
    }
}

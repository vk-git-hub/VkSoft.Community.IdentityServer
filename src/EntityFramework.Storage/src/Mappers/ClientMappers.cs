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
    public static class ClientMappers
    {
        public static Models.Client ToModel(this Entities.Client entity)
        {
            if (entity == null) return null;

            return new Models.Client
            {
                Enabled = entity.Enabled,
                ClientId = entity.ClientId,
                ProtocolType = entity.ProtocolType,
                RequireClientSecret = entity.RequireClientSecret,
                ClientName = entity.ClientName,
                Description = entity.Description,
                ClientUri = entity.ClientUri,
                LogoUri = entity.LogoUri,
                RequireConsent = entity.RequireConsent,
                AllowRememberConsent = entity.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = entity.AlwaysIncludeUserClaimsInIdToken,
                RequirePkce = entity.RequirePkce,
                AllowPlainTextPkce = entity.AllowPlainTextPkce,
                RequireRequestObject = entity.RequireRequestObject,
                AllowAccessTokensViaBrowser = entity.AllowAccessTokensViaBrowser,
                FrontChannelLogoutUri = entity.FrontChannelLogoutUri,
                FrontChannelLogoutSessionRequired = entity.FrontChannelLogoutSessionRequired,
                BackChannelLogoutUri = entity.BackChannelLogoutUri,
                BackChannelLogoutSessionRequired = entity.BackChannelLogoutSessionRequired,
                AllowOfflineAccess = entity.AllowOfflineAccess,
                IdentityTokenLifetime = entity.IdentityTokenLifetime,
                AccessTokenLifetime = entity.AccessTokenLifetime,
                AuthorizationCodeLifetime = entity.AuthorizationCodeLifetime,
                ConsentLifetime = entity.ConsentLifetime,
                AbsoluteRefreshTokenLifetime = entity.AbsoluteRefreshTokenLifetime,
                SlidingRefreshTokenLifetime = entity.SlidingRefreshTokenLifetime,
                UpdateAccessTokenClaimsOnRefresh = entity.UpdateAccessTokenClaimsOnRefresh,
                EnableLocalLogin = entity.EnableLocalLogin,
                IncludeJwtId = entity.IncludeJwtId,
                AlwaysSendClientClaims = entity.AlwaysSendClientClaims,
                ClientClaimsPrefix = entity.ClientClaimsPrefix,
                PairWiseSubjectSalt = entity.PairWiseSubjectSalt,
                UserSsoLifetime = entity.UserSsoLifetime,
                UserCodeType = entity.UserCodeType,
                DeviceCodeLifetime = entity.DeviceCodeLifetime,
                RefreshTokenUsage = (TokenUsage)entity.RefreshTokenUsage,
                RefreshTokenExpiration = (TokenExpiration)entity.RefreshTokenExpiration,
                AccessTokenType = (AccessTokenType)entity.AccessTokenType,
                AllowedGrantTypes = entity.AllowedGrantTypes?
                    .Select(x => x.GrantType).ToList() ?? new List<string>(),
                RedirectUris = entity.RedirectUris?
                    .Select(x => x.RedirectUri).ToHashSet() ?? new HashSet<string>(),
                PostLogoutRedirectUris = entity.PostLogoutRedirectUris?
                    .Select(x => x.PostLogoutRedirectUri).ToHashSet() ?? new HashSet<string>(),
                AllowedScopes = entity.AllowedScopes?
                    .Select(x => x.Scope).ToHashSet() ?? new HashSet<string>(),
                IdentityProviderRestrictions = entity.IdentityProviderRestrictions?
                    .Select(x => x.Provider).ToHashSet() ?? new HashSet<string>(),
                AllowedCorsOrigins = entity.AllowedCorsOrigins?
                    .Select(x => x.Origin).ToHashSet() ?? new HashSet<string>(),
                AllowedIdentityTokenSigningAlgorithms = AllowedSigningAlgorithmsConverter.ConvertToCollection(entity.AllowedIdentityTokenSigningAlgorithms),
                ClientSecrets = entity.ClientSecrets?
                    .Select(ToModel)
                    .ToHashSet() ?? new HashSet<Secret>(),
                Claims = entity.Claims?
                    .Select(x => new ClientClaim(x.Type, x.Value, ClaimValueTypes.String))
                    .ToHashSet() ?? new HashSet<ClientClaim>(),
                Properties = entity.Properties == null
                    ? new Dictionary<string, string>()
                    : entity.Properties.ToDictionary(x => x.Key, x => x.Value)
            };
        }

        public static Entities.Client ToEntity(this Models.Client model)
        {
            if (model == null) return null;

            return new Entities.Client
            {
                Enabled = model.Enabled,
                ClientId = model.ClientId,
                ProtocolType = model.ProtocolType,
                RequireClientSecret = model.RequireClientSecret,
                ClientName = model.ClientName,
                Description = model.Description,
                ClientUri = model.ClientUri,
                LogoUri = model.LogoUri,
                RequireConsent = model.RequireConsent,
                AllowRememberConsent = model.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = model.AlwaysIncludeUserClaimsInIdToken,
                RequirePkce = model.RequirePkce,
                AllowPlainTextPkce = model.AllowPlainTextPkce,
                RequireRequestObject = model.RequireRequestObject,
                AllowAccessTokensViaBrowser = model.AllowAccessTokensViaBrowser,
                FrontChannelLogoutUri = model.FrontChannelLogoutUri,
                FrontChannelLogoutSessionRequired = model.FrontChannelLogoutSessionRequired,
                BackChannelLogoutUri = model.BackChannelLogoutUri,
                BackChannelLogoutSessionRequired = model.BackChannelLogoutSessionRequired,
                AllowOfflineAccess = model.AllowOfflineAccess,
                IdentityTokenLifetime = model.IdentityTokenLifetime,
                AccessTokenLifetime = model.AccessTokenLifetime,
                AuthorizationCodeLifetime = model.AuthorizationCodeLifetime,
                ConsentLifetime = model.ConsentLifetime,
                AbsoluteRefreshTokenLifetime = model.AbsoluteRefreshTokenLifetime,
                SlidingRefreshTokenLifetime = model.SlidingRefreshTokenLifetime,
                UpdateAccessTokenClaimsOnRefresh = model.UpdateAccessTokenClaimsOnRefresh,
                EnableLocalLogin = model.EnableLocalLogin,
                IncludeJwtId = model.IncludeJwtId,
                AlwaysSendClientClaims = model.AlwaysSendClientClaims,
                ClientClaimsPrefix = model.ClientClaimsPrefix,
                PairWiseSubjectSalt = model.PairWiseSubjectSalt,
                UserSsoLifetime = model.UserSsoLifetime,
                UserCodeType = model.UserCodeType,
                DeviceCodeLifetime = model.DeviceCodeLifetime,
                RefreshTokenUsage = (int)model.RefreshTokenUsage,
                RefreshTokenExpiration = (int)model.RefreshTokenExpiration,
                AccessTokenType = (int)model.AccessTokenType,
                AllowedGrantTypes = model.AllowedGrantTypes?
                    .Select(x => new Entities.ClientGrantType { GrantType = x })
                    .ToList(),
                RedirectUris = model.RedirectUris?
                    .Select(x => new Entities.ClientRedirectUri { RedirectUri = x })
                    .ToList(),
                PostLogoutRedirectUris = model.PostLogoutRedirectUris?
                    .Select(x => new Entities.ClientPostLogoutRedirectUri { PostLogoutRedirectUri = x })
                    .ToList(),
                AllowedScopes = model.AllowedScopes?
                    .Select(x => new Entities.ClientScope { Scope = x })
                    .ToList(),
                IdentityProviderRestrictions = model.IdentityProviderRestrictions?
                    .Select(x => new Entities.ClientIdPRestriction { Provider = x })
                    .ToList(),
                AllowedCorsOrigins = model.AllowedCorsOrigins?
                    .Select(x => new Entities.ClientCorsOrigin { Origin = x })
                    .ToList(),
                AllowedIdentityTokenSigningAlgorithms = AllowedSigningAlgorithmsConverter.ConvertToString(model.AllowedIdentityTokenSigningAlgorithms),
                ClientSecrets = model.ClientSecrets?
                    .Select(ToEntity)
                    .ToList(),
                Claims = model.Claims?
                    .Select(x => new Entities.ClientClaim { Type = x.Type, Value = x.Value })
                    .ToList(),
                Properties = model.Properties?
                    .Select(x => new Entities.ClientProperty { Key = x.Key, Value = x.Value })
                    .ToList()
            };
        }

        private static Models.Secret ToModel(Entities.ClientSecret src)
        {
            var dest = new Models.Secret();
            dest.Description = src.Description;
            dest.Value = src.Value;
            dest.Expiration = src.Expiration;
            dest.Type = src.Type ?? "SharedSecret";
            return dest;
        }

        private static Entities.ClientSecret ToEntity(Models.Secret src)
        {
            return new Entities.ClientSecret
            {
                Description = src.Description,
                Value = src.Value,
                Expiration = src.Expiration,
                Type = src.Type
            };
        }
    }
}

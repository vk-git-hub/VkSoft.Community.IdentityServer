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
    public static class PersistedGrantMappers
    {
        public static PersistedGrant ToModel(this Entities.PersistedGrant entity)
        {
            if (entity == null) return null;

            return new PersistedGrant
            {
                Key = entity.Key,
                Type = entity.Type,
                SubjectId = entity.SubjectId,
                SessionId = entity.SessionId,
                ClientId = entity.ClientId,
                Description = entity.Description,
                CreationTime = entity.CreationTime,
                Expiration = entity.Expiration,
                ConsumedTime = entity.ConsumedTime,
                Data = entity.Data
            };
        }

        public static Entities.PersistedGrant ToEntity(this PersistedGrant model)
        {
            if (model == null) return null;

            return new Entities.PersistedGrant
            {
                Key = model.Key,
                Type = model.Type,
                SubjectId = model.SubjectId,
                SessionId = model.SessionId,
                ClientId = model.ClientId,
                Description = model.Description,
                CreationTime = model.CreationTime,
                Expiration = model.Expiration,
                ConsumedTime = model.ConsumedTime,
                Data = model.Data
            };
        }

        public static void UpdateEntity(this PersistedGrant model, Entities.PersistedGrant entity)
        {
            entity.Key = model.Key;
            entity.Type = model.Type;
            entity.SubjectId = model.SubjectId;
            entity.SessionId = model.SessionId;
            entity.ClientId = model.ClientId;
            entity.Description = model.Description;
            entity.CreationTime = model.CreationTime;
            entity.Expiration = model.Expiration;
            entity.ConsumedTime = model.ConsumedTime;
            entity.Data = model.Data;
        }
    }
}

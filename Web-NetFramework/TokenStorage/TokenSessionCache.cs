using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace Web_NetFramework.TokenStorage
{
    public class TokenSessionCache
    {
        protected HttpContextBase HttpContext = null;
        protected static ReaderWriterLockSlim locker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        protected string KeyID = string.Empty;
        protected string CacheID = string.Empty;

        protected TokenCache Cache = new TokenCache();

        

        public TokenSessionCache(string keyID, HttpContextBase httpContext)
        {
            KeyID = keyID;
            CacheID = KeyID + "_TokenCache";
            HttpContext = httpContext;
            Load();
        }

        public TokenCache GetMsalCacheInstance()
        {
            Cache.SetBeforeAccess(BeforeAccessNotification);
            Cache.SetAfterAccess(AfterAccessNotification);
            Load();
            return Cache;
        }
        public void SaveUserStateValue(string state)
        {
            locker.EnterWriteLock();
            HttpContext.Session[HttpContext + "_state"] = state;
            locker.ExitWriteLock();
        }
        public string ReadUserStateValue()
        {
            string state = string.Empty;
            locker.EnterReadLock();
            state = (string)HttpContext.Session[HttpContext + "_state"];
            locker.ExitReadLock();
            return state;
        }
        public void Persist()
        {
            locker.EnterWriteLock();
            Cache.HasStateChanged = false;
            HttpContext.Session[CacheID] = Cache.Serialize();
            locker.ExitWriteLock();
        }
        public void Load()
        {
            locker.EnterReadLock();
            Cache.Deserialize((byte[])HttpContext.Session[CacheID]);
            locker.ExitReadLock();
        }
        public void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            Load();
        }
        public void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            if (Cache.HasStateChanged)
            {
                Persist();
            }
        }

    }
}
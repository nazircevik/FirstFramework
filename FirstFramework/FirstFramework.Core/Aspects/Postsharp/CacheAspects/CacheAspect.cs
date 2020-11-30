using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FirstFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
namespace FirstFramework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;
        public CacheAspect(Type cachetype,int cacheByMinute=60)
        {
            _cacheByMinute = cacheByMinute;
            _cacheType = cachetype;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if(typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)
            {
                throw new Exception("Wrong CAche MAnager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            
            base.RuntimeInitialize(method);
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name,
                args.Method.Name);
            var arguments = args.Arguments.ToList();
            var key = string.Format("{0}({1})",methodName,string.Join(",",arguments.Select(x=>x!=null?x.ToString():"null")));
         

            if(_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.GetT<object>(key);

            }
            base.OnInvoke(args);
            _cacheManager.Add(key, args.ReturnValue, _cacheByMinute);
        }
    }
}

using System;
using Utilities;
using System.Linq;
using StackExchange.Redis;
using System.Collections.Generic;

namespace Cache
{
	public class RedisCache
	{
		private readonly ConnectionMultiplexer _redis;
		public RedisCache(string connString)
		{
			_redis = ConnectionMultiplexer.Connect(connString);
		}

		/// <summary>
		/// 获取Key
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <returns></returns>
		public T Get<T>(string key)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				return db.StringGet(key).ToString().JsonToObject<T>();
			}
		}

		/// <summary>
		/// 设置Key
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Set<T>(string key, T value)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				return db.StringSet(key, value.ToJson());
			}
		}

		/// <summary>
		/// 是否存在Key
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool ExistsKey(string key)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				return db.KeyExists(key);
			}
		}

		/// <summary>
		/// 数字累加
		/// </summary>
		/// <param name="key"></param>
		/// <param name="number"></param>
		/// <returns></returns>
		public double IncDouble(string key, double number)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				return db.StringIncrement(key, number);
			}
		}

		/// <summary>
		/// 删除Key
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool DeleteKey(string key)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				return db.KeyDelete(key);
			}
		}

		/// <summary>
		/// 批量删除Key
		/// </summary>
		/// <param name="keys"></param>
		/// <returns></returns>
		public long DeleteKey(params string[] keys)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				var that = keys.Select(x => new RedisKey().Append(x));
				return db.KeyDelete(that.ToArray());
			}
		}

		/// <summary>
		/// 字符串累加
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public long IncString(string key, string value)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				return db.StringAppend(key, value);
			}
		}

		/// <summary>
		/// 重命名Key
		/// </summary>
		/// <param name="key"></param>
		/// <param name="newKey"></param>
		/// <returns></returns>
		public bool KeyRename(string key, string newKey)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				return db.KeyRename(key, newKey);
			}
		}

		/// <summary>
		/// 获取Hash所有值
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <returns></returns>
		public List<T> GetHashAll<T>(string key)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				var arr = db.HashKeys(key);
				return (from item in arr where !item.IsNullOrEmpty select item.ToString().JsonToObject<T>()).ToList();
			}
		}

		/// <summary>
		/// 获取Hash中的单个key的值
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="hasField">has字段</param>
		/// <returns></returns>
		public T GetHashKey<T>(string key, string hasField)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				if (string.IsNullOrWhiteSpace(key) ||
					string.IsNullOrWhiteSpace(hasField))
				{
					return default(T);
				}
				var value = db.HashGet(key, hasField);
				return !value.IsNullOrEmpty ? value.ToString().JsonToObject<T>() : default(T);
			}
		}

		/// <summary>
		/// 获取Hash中的多个值
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="hashFields">has值</param>
		/// <returns></returns>
		public List<T> GetHashKey<T>(string key, List<RedisValue> hashFields)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				var result = new List<T>();
				if (key.IsNullOrEmpty() ||
					hashFields.Count <= 0)
				{
					return result;
				}
				var value = db.HashGet(key, hashFields.ToArray());
				result.AddRange(from item in value where !item.IsNullOrEmpty select item.ToString().JsonToObject<T>());
				return result;
			}
		}

		/// <summary>
		/// 设置Hash表
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="list"></param>
		/// <param name="hashFields">list中每个item的关键字段(比如Id)</param>
		public void SetHash<T>(string key, List<T> list, Func<T, string> hashFields)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				var listHashEntry = new List<HashEntry>();
				foreach (var item in list)
				{
					var json = item.ToJson();
					listHashEntry.Add(new HashEntry(hashFields(item), json));
				}
				db.HashSet(key, listHashEntry.ToArray());
			}
		}

		/// <summary>
		/// 累加到Hash表 // todo 有bug
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="item"></param>
		public void IncHash<T>(string key, T item)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				db.HashIncrement(key, item.ToJson());
			}
		}

        /// <summary>
        /// 批量累加到Hash表 // todo 有bug
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="list"></param>
        public void IncHash<T>(string key, List<T> list)
		{
			using (_redis)
			{
				var db = _redis.GetDatabase();
				foreach (var item in list)
				{
					db.HashIncrement(key, item.ToJson());
				}
			}
		}
	}
}

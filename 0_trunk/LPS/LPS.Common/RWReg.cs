using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace LPS
{
    /// <summary>
    /// 注册表读写帮助类
    /// </summary>
    internal class RWReg
    {
        private static readonly string DefaultKey = "河南烟草收购系统";

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="defualtValue">默认值</param>
        /// <param name="unDecrypt">是否需要解密</param>
        /// <returns></returns>
        public static int GetInt32(string subName, string keyName, object defualtValue = null, bool unDecrypt = false)
        {
            return Converter.ToInt32(GetValue(subName, keyName, defualtValue, unDecrypt));
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="key">注册表顶级节点</param>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="defualtValue">默认值</param>
        /// <param name="unDecrypt">是否需要解密</param>
        /// <returns></returns>
        public static int GetInt32(RegistryKey key, string subName, string keyName, object defualtValue = null, bool unDecrypt = false)
        {
            return Converter.ToInt32(GetValue(key, subName, keyName, defualtValue, unDecrypt));
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="defualtValue">默认值</param>
        /// <param name="unDecrypt">是否需要解密</param>
        /// <returns></returns>
        public static double GetDouble(string subName, string keyName, object defualtValue = null, bool unDecrypt = false)
        {
            return Converter.ToDouble(GetValue(Registry.CurrentUser, subName, keyName, defualtValue, unDecrypt));
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="key">注册表顶级节点</param>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="defualtValue">默认值</param>
        /// <param name="unDecrypt">是否需要解密</param>
        /// <returns></returns>
        public static double GetDouble(RegistryKey key, string subName, string keyName, object defualtValue = null, bool unDecrypt = false)
        {
            return Converter.ToDouble(GetValue(key, subName, keyName, defualtValue, unDecrypt));
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="defualtValue">默认值</param>
        /// <param name="unDecrypt">是否需要解密</param>
        /// <returns></returns>
        public static bool GetBoolean(string subName, string keyName, object defualtValue = null, bool unDecrypt = false)
        {
            return Converter.ToBoolean(GetValue(Registry.CurrentUser, subName, keyName, defualtValue, unDecrypt));
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="key">注册表顶级节点</param>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="defualtValue">默认值</param>
        /// <param name="unDecrypt">是否需要解密</param>
        /// <returns></returns>
        public static bool GetBoolean(RegistryKey key, string subName, string keyName, object defualtValue = null, bool unDecrypt = false)
        {
            return Converter.ToBoolean(GetValue(key, subName, keyName, defualtValue, unDecrypt));
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="defualtValue">默认值</param>
        /// <param name="unDecrypt">是否需要解密</param>
        /// <returns></returns>
        public static string GetString(string subName, string keyName, object defualtValue = null, bool unDecrypt = false)
        {
            return (string)GetValue(Registry.CurrentUser, subName, keyName, defualtValue, unDecrypt);
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="key">注册表顶级节点</param>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="defualtValue">默认值</param>
        /// <param name="unDecrypt">是否需要解密</param>
        /// <returns></returns>
        public static string GetString(RegistryKey key, string subName, string keyName, object defualtValue = null, bool unDecrypt = false)
        {
            return (string)GetValue(key, subName, keyName, defualtValue, unDecrypt);
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="defualtValue">默认值</param>
        /// <param name="unDecrypt">是否需要解密</param>
        /// <returns></returns>
        public static object GetValue(string subName, string keyName, object defualtValue = null, bool unDecrypt = false)
        {
            return GetValue(Registry.CurrentUser, subName, keyName, defualtValue, unDecrypt);
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="key">注册表顶级节点</param>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="defualtValue">默认值</param>
        /// <param name="unDecrypt">是否需要解密</param>
        /// <returns></returns>
        public static object GetValue(RegistryKey key, string subName, string keyName, object defualtValue = null, bool unDecrypt = false)
        {
            using (var rootKey = key)
            {
                using (var subKey = rootKey.OpenSubKey(subName))
                {
                    if (null == subKey)
                    {
                        return defualtValue;
                    }
                    if (!unDecrypt)
                    {
                        var result = subKey.GetValue(keyName, null);
                        if (null != result)
                        {
                            return AES.Decrypt(result.ToString(), DefaultKey);
                        }
                        return defualtValue;
                    }
                    else
                    {
                        return subKey.GetValue(keyName, defualtValue);
                    }
                }
            }
        }
        
        /// <summary>
        /// 设置注册表值
        /// </summary>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="value">值</param>
        /// <param name="unEncrypt">是否加密</param>
        public static void SetValue(string subName, string keyName, object value, bool unEncrypt = false)
        {
            SetValue(Registry.CurrentUser, subName, keyName, value, unEncrypt);
        }

        /// <summary>
        /// 设置注册表值
        /// </summary>
        /// <param name="key">注册表顶级节点</param>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        /// <param name="value">值</param>
        /// <param name="unEncrypt">是否加密</param>
        public static void SetValue(RegistryKey key, string subName, string keyName, object value, bool unEncrypt = false)
        {
            using (var rootKey = Registry.LocalMachine)
            {
                using (var subKey = rootKey.OpenSubKey(subName, true))
                {
                    if (null == subKey)
                    {
                        using (var newSubKey = rootKey.CreateSubKey(subName))
                        {
                            if (!unEncrypt)
                        {
                            if (null != value)
                            {
                                newSubKey.SetValue(keyName, AES.Encrypt(value.ToString(), DefaultKey));
                            }
                            else
                            {
                                newSubKey.SetValue(keyName, value);
                            }
                        }
                        else
                        {
                            subKey.SetValue(keyName, value);
                        }
                        }
                    }
                    else
                    {
                        if (!unEncrypt)
                        {
                            if (null != value)
                            {
                                subKey.SetValue(keyName, AES.Encrypt(value.ToString(), DefaultKey));
                            }
                            else
                            {
                                subKey.SetValue(keyName, value);
                            }
                        }
                        else
                        {
                            subKey.SetValue(keyName, value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 移除注册表
        /// </summary>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        public static void RemoveKey(string subName, string keyName)
        {
            RemoveKey(Registry.CurrentUser, subName, keyName);
        }

        /// <summary>
        /// 移除注册表
        /// </summary>
        /// <param name="key">注册表顶级节点</param>
        /// <param name="subName">注册表路径</param>
        /// <param name="keyName">键</param>
        public static void RemoveKey(RegistryKey key, string subName, string keyName)
        {
            using (var rootKey = key)
            {
                using (var subKey = rootKey.OpenSubKey(subName, true))
                {
                    if (null != subKey)
                    {
                        try
                        {
                            subKey.DeleteValue(keyName);
                        }
                        catch { }
                    }
                }
            }
        }
    }
}

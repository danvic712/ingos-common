//-----------------------------------------------------------------------
// <copyright file= "PropertyChangeTrackingExtensions.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2020/2/5 21:40:35
// Modified by:
// Description:
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp.Core
{
    public static class PropertyChangeTrackingExtensions
    {
        /// <summary>
        /// 获取类属性数据变化记录
        /// </summary>
        /// <typeparam name="T">监听的类类型</typeparam>
        /// <param name="oldObj">包含原始值的类</param>
        /// <param name="newObj">变更属性值后的类</param>
        /// <param name="propertyName">指定的属性名称</param>
        /// <returns></returns>
        public static IEnumerable<PropertyChangelog<T>> GetPropertyLogs<T>(this T oldObj, T newObj, string propertyName = null)
        {
            IList<PropertyChangelog<T>> changelogs = new List<PropertyChangelog<T>>();

            // 1、获取需要添加数据变更记录的属性信息
            //
            IList<PropertyInfo> properties = new List<PropertyInfo>();

            // PropertyChangeTracking 特性的类型
            var attributeType = typeof(PropertyChangeTrackingAttribute);

            // 对应的类中包含的属性信息
            var classProperties = typeof(T).GetProperties();

            // 获取类中需要添加变更记录的属性信息
            //
            bool flag = Attribute.IsDefined(typeof(T), attributeType);

            foreach (var i in classProperties)
            {
                // 获取当前属性添加的特性信息
                var attributeInfo = (PropertyChangeTrackingAttribute)i.GetCustomAttribute(attributeType);

                // 类未添加特性，并且该属性也未添加特性
                if (!flag && attributeInfo == null)
                    continue;

                // 类添加特性，该属性未添加特性
                if (flag && attributeInfo == null)
                    properties.Add(i);

                // 不管类有没有添加特性，只要类中的属性添加特性，并且 Ignore 为 false
                if (attributeInfo != null && !attributeInfo.Ignore)
                    properties.Add(i);
            }

            // 2、判断指定的属性数据是否发生变更
            //
            foreach (var property in properties)
            {
                var oldValue = property.GetValue(oldObj) ?? "";
                var newValue = property.GetValue(newObj) ?? "";

                if (oldValue.Equals(newValue))
                    continue;

                // 获取当前属性在页面上显示的名称
                //
                var attributeInfo = (PropertyChangeTrackingAttribute)property.GetCustomAttribute(attributeType);
                string displayName = attributeInfo == null ? property.Name
                    : attributeInfo.DisplayName;

                changelogs.Add(new PropertyChangelog<T>(property.Name, displayName, oldValue.ToString(), newValue.ToString()));
            }

            return string.IsNullOrEmpty(propertyName) ? changelogs
                : changelogs.Where(i => i.PropertyName.Equals(propertyName));
        }
    }
}
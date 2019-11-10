//-----------------------------------------------------------------------
// <copyright file= "Address.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/10 11:03:41
// Modified by:
// Description:
//-----------------------------------------------------------------------

namespace Sample.Domain.AggregateModels
{
    public class Address
    {
        /// <summary>
        /// ctor
        /// </summary>
        private Address()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="street">街道地址</param>
        /// <param name="city">城市</param>
        /// <param name="province">省份</param>
        /// <param name="zipCode">邮编</param>
        public Address(string street, string city, string province, string zipCode)
        {
            Street = street;
            City = city;
            Province = province;
            ZipCode = zipCode;
        }

        #region Attrbites

        /// <summary>
        /// 街道地址
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; private set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode { get; private set; }

        #endregion Attrbites
    }
}
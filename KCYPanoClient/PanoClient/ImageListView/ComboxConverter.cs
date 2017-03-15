using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PanoClient.ImageListView
{
    /// <summary>
    /// 一.自定义一个特性类ListAttribute,提供下拉列表值:
    /// </summary>
    public class ListAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string[] _lst;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        public ListAttribute(string[] lst)
        {
            //初始化列表值  
            _lst = lst;
        }
    }
    /// <summary>
    /// 二.特性转换器ComboxConverter 
    /// </summary>
    public class ComboxConverter : ExpandableObjectConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ListAttribute listAttribute = (ListAttribute)context.PropertyDescriptor.Attributes[typeof(ListAttribute)];
            StandardValuesCollection vals = new TypeConverter.StandardValuesCollection(listAttribute._lst);
            return vals;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }
    }
}

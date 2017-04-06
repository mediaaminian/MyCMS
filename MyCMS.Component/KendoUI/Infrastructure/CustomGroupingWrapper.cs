namespace Kendo.Mvc.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using MyCMS.Component.KendoUI.Resources;

    /// <exclude/>
    /// <excludetoc/>
    internal interface IGridCustomGroupingWrapper
    {
        IEnumerable GroupedEnumerable { get; }
    }

    internal class CustomGroupingWrapper<T> : IEnumerable<T>, IGridCustomGroupingWrapper
    {
        public virtual IEnumerable GroupedEnumerable { get; private set; }

        public CustomGroupingWrapper(IEnumerable groupedEnumerable)
        {
            GroupedEnumerable = groupedEnumerable;
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {            
            throw new InvalidOperationException(Exceptions.YouCannotCallBindToWithoutCustomBinding);            
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion        
    }
}

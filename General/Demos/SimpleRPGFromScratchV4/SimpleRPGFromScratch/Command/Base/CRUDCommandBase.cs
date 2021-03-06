﻿using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.Base;
using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.Command.Base
{
    /// <summary>
    /// Basis-implementation af Command-klasse for CRUD-operationer.
    /// For disse operationer antages det, at vi altid har brug for:
    /// 1) En reference til et Catalog-objekt
    /// 2) En reference til et PageViewModel-objekt
    /// </summary>
    /// <typeparam name="T">Typen af domæne-objekter i Catalog-objektet</typeparam>
    /// <typeparam name="TDataViewModel">Typen af DVM-objekter i PVM-objektet</typeparam>
    public abstract class CRUDCommandBase<T, TDataViewModel> : CommandBase
        where TDataViewModel : IDataViewModel<T>
        where T : IDomainClass
    {
        protected ICatalog<T> _catalog;
        protected IPageViewModel<TDataViewModel> _pageViewModel;

        protected CRUDCommandBase(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel)
        {
            _catalog = catalog;
            _pageViewModel = pageViewModel;
        }

        /// <summary>
        /// CRUD-commands kan kun udføres, når ItemDetails refererer til et objekt. 
        /// </summary>
        /// <returns></returns>
        protected override bool CanExecute()
        {
            return (_pageViewModel.ItemDetails != null) && (_pageViewModel.ItemDetails.DataObject() != null);
        }
    }
}